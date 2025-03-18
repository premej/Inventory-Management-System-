import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { SidebarComponent } from '../../sidebar/sidebar.component';
import { ProductmenuComponent } from '../productmenu/productmenu.component';

@Component({
  selector: 'app-updateprice',
  imports: [FormsModule,SidebarComponent,ProductmenuComponent],
  templateUrl: './updateprice.component.html',
  styleUrl: './updateprice.component.css'
})
export class UpdatepriceComponent {
  product: any = {
    id: null,
    amount: null
  };

  constructor(private http: HttpClient) {}

  updateProductPrice() {
    if (this.product.id && this.product.amount) {
      const url = `https://localhost:44339/api/Product/UpdateStockPriceById?productId=${this.product.id}&newPrice=${this.product.amount}`;
      this.http.post(url, {}).subscribe(
        (res: any) => {
          console.log('Update Product Price Response:', res);
          // Handle success response
        },
        (error) => {
          console.error('Error updating product price', error);
          // Handle error response
        }
      );
    } else {
      console.error('Product ID and New Amount are required');
    }
  }
}
