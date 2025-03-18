import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { SidebarComponent } from '../../sidebar/sidebar.component';
import { StockmenuComponent } from '../stockmenu/stockmenu.component';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-review-inventory',
  imports: [CommonModule,StockmenuComponent,SidebarComponent,FormsModule],
  templateUrl: './review-inventory.component.html',
  styleUrl: './review-inventory.component.css'
})
export class ReviewInventoryComponent {
  stockList: any[]= [];
  newPrice: number = 0;
  selectedProductId: number | null = null;
  isModalOpen: boolean = false;
  constructor(private http: HttpClient){

  }
  ngOnInit(): void {
    this.getStock();
  }

  getStock() {
    this.http.get("https://localhost:44339/api/Stock/review_inventory").subscribe(
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
  openModal(item: any) {
    this.selectedProductId = item.productId;
    this.newPrice = item.price;
    this.isModalOpen = true;
  }

  closeModal() {
    this.isModalOpen = false;
    this.selectedProductId = null;
    this.newPrice = 0;
  }

  submitPriceUpdate() {
    if (this.selectedProductId !== null) {
      console.log('Updating price for product:', this.selectedProductId, 'New Price:', this.newPrice);
      const url = `https://localhost:44339/api/Product/UpdateStockPriceById?productId=${this.selectedProductId}&newPrice=${this.newPrice}`;
      this.http.put(url, {}).subscribe(
        (res) => {
          console.log('Price updated successfully', res);
          this.closeModal();
          this.getStock(); // Refresh the stock list
        },
        (error) => {
          console.error('Error updating price', error);
        }
      );
    }
  }
}
