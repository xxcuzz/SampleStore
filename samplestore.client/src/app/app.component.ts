import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {

  constructor(private http: HttpClient) {}

  readonly lines = ['WEAR STYLE', 
    '•',
    '2 DAY DELIVERY FOR POLAND & UK',
    '•', 
    'COMPLEMENTARY SHIPPING ON ORDERS OVER $300',
    '•'];

  ngOnInit() { }

  title = 'samplestore.client';
}
