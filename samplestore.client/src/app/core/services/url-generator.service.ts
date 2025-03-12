import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UrlGeneratorService {

  constructor() { }
  
  // Converts string to lowercase, replaces spaces with hyphens
  generate(name: string): string {
    return name.toLowerCase().replace(/\s+/g, '-');
  }
}
