import {HttpClient} from '@angular/common/http';
import {Component} from '@angular/core';
import {UrlGeneratorService} from "../../services/url-generator.service";
import {environment} from '../../../../environments/environment';
import {forkJoin} from 'rxjs';

interface MenuItem {
  id: string;
  name: string;
  parentId?: string;
  url: string;
}

@Component({
  selector: 'app-header-menu',
  standalone: false,
  templateUrl: './header-menu.component.html',
  styleUrl: './header-menu.component.scss'
})

export class HeaderMenuComponent {
  private readonly apiUrl = environment.apiUrl;
  private readonly menuItemsUrlPrefix: string = '/collections';
  private readonly displaySectionCount: number = 3;
  
  collections: MenuItem[] = [];
  categories: MenuItem[] = [];
  displayGroups: MenuItem[][] = [];
  
  constructor(private http: HttpClient,
              private urlGeneratorService: UrlGeneratorService) {
  }
  
  ngOnInit() {
    this.loadData();
  }
  
  private loadData() {
    forkJoin({
      collections: this.http.get<MenuItem[]>(`${this.apiUrl}/collections`),
      categories: this.http.get<MenuItem[]>(`${this.apiUrl}/categories`),
    }).subscribe({
      next: ({collections, categories}) => {
        this.collections = collections;
        this.categories = categories;
        this.groupCategories(this.displaySectionCount);
        this.generateUrls();
      },
      error: (err) => {
        console.warn('Fetch data error:', err);
      },
    });
  }
  
  private generateUrls(): void {
    this.collections.forEach(item => item.url = this.generateUrl(item, true));
    this.categories.forEach(item => item.url = this.generateUrl(item));
  }
  
  /**
   * Generates a URL for a given menu item.
   *
   * @param {MenuItem} item - The menu item for which the URL is to be generated.
   * @param {boolean} [isCollection=false] - A flag indicating if the item is part of a collection. Default is false.
   * @returns {string} The generated URL based on the item and collection flag.
   */
  generateUrl(item: MenuItem, isCollection: boolean = false): string {
    isCollection ?
      console.log('collection urls Generate') :
      console.log('categories urls Generate');
    
    const urlParts = [this.menuItemsUrlPrefix];
    
    if (!isCollection && item.parentId) {
      const parentCategoryName = this.getCategoryNameById(item.parentId);
      urlParts.push(this.urlGeneratorService.generate(parentCategoryName));
    }
    
    urlParts.push(this.urlGeneratorService.generate(item.name));
    
    return urlParts.join('/');
  }
  
  private getCategoryNameById(id: string): string {
    return this.categories.find((category) => category.id === id)?.name || '';
  }
  
  private groupCategories(sectionsToDisplayCount: number) {
    const groupedByParent: MenuItem[][] = []; // Jagged array with structure [parent, ...parent_childs]
    const map: Record<string, MenuItem[]> = {};
    
    // Group categories by parentId
    this.categories.forEach(category => {
      if (!category.parentId) {
        // If root category, directly add to result
        groupedByParent.push([category]);
      } else {
        // Store in map if it has parent
        if (!map[category.parentId]) {
          map[category.parentId] = [];
        }
        map[category.parentId].push(category);
      }
    });
    
    // Add child categories to their respective parent categories
    groupedByParent.forEach(group => {
      const parentId: string = group[0].id;
      if (map[parentId]) {
        group.push(...map[parentId]);
      }
    });
    
    // Sort groups by the number of children (desc)
    groupedByParent.sort((a, b) => b.length - a.length);
    
    // Merge the smallest groups into the last section
    if (groupedByParent.length > sectionsToDisplayCount) {
      groupedByParent[sectionsToDisplayCount - 1] =
        groupedByParent[sectionsToDisplayCount - 1].concat(...groupedByParent.slice(sectionsToDisplayCount));
      
      this.displayGroups = groupedByParent;
    }
  }
}
