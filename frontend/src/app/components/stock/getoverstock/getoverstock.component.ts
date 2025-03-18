import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { SidebarComponent } from '../../sidebar/sidebar.component';
import { StockmenuComponent } from '../stockmenu/stockmenu.component';
@Component({
  selector: 'app-getoverstock',
  imports: [CommonModule,StockmenuComponent,SidebarComponent],
  templateUrl: './getoverstock.component.html',
  styleUrl: './getoverstock.component.css'
})
export class GetoverstockComponent {
  stockList: any[]= [];
  constructor(private http: HttpClient){

  }
  ngOnInit(): void {
    this.getStock();
  }

  getStock() {
    this.http.get("https://localhost:44339/api/Stock/GetOverStockProducts").subscribe(
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
