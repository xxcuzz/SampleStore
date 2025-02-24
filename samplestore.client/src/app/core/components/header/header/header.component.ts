import { Component } from '@angular/core';

@Component({
  selector: 'app-header',
  standalone: false,
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent {
  readonly lines = ['WEAR STYLE', 
    '•',
    '2 DAY DELIVERY FOR POLAND & UK',
    '•', 
    'COMPLEMENTARY SHIPPING ON ORDERS OVER $300',
    '•'];
}
