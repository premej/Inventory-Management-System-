import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { SidebarComponent } from '../../sidebar/sidebar.component';
import { StockmenuComponent } from '../stockmenu/stockmenu.component';
@Component({
  selector: 'app-outofstock',
  imports: [CommonModule,StockmenuComponent,SidebarComponent],
  templateUrl: './outofstock.component.html',
  styleUrl: './outofstock.component.css'
})
export class OutofstockComponent {
  stockList: any[]= [];
  constructor(private http: HttpClient){

  }
  ngOnInit(): void {
    this.getStock();
  }

  getStock() {
    this.http.get("https://localhost:44339/api/Stock/GetOutOfStockProducts").subscribe(
      (res: any) => {
        console.log('API Response:', res);
        if (res) {
          this.stockList = res;
          console.log('Stock List:', this.stockList);
        } 
      },
      (error) => {
        console.error('Error fetching stock data', error);
      }
    );
  }
}
