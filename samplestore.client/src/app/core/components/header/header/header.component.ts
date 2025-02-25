import { Component } from '@angular/core';

import { slideDownAnimation } from './header.animations';

@Component({
  selector: 'app-header',
  standalone: false,
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss',
  animations: [slideDownAnimation],
})
export class HeaderComponent {
  isMenuOpen = false;

  readonly marqueeLines = [
    'WEAR STYLE',
    '2 DAY DELIVERY FOR POLAND & UK',
    'COMPLEMENTARY SHIPPING ON ORDERS OVER $300',
  ];
  readonly separator = '•';
  
  getMarqueeLines(): string[] {
    return this.marqueeLines.flatMap(line => [line, this.separator]);
  }

  toggleMenu() {
    this.isMenuOpen = !this.isMenuOpen;
  }
}
