import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { SidebarComponent } from '../../sidebar/sidebar.component';
import { ProductmenuComponent } from '../productmenu/productmenu.component';

@Component({
  selector: 'app-setminquantity',
  imports: [FormsModule,CommonModule,SidebarComponent,ProductmenuComponent],
  templateUrl: './setminquantity.component.html',
  styleUrl: './setminquantity.component.css'
})
export class SetminquantityComponent {
  product: any = {
    productName: null,
    minQuantity: null
  };

  constructor(private http: HttpClient) {}

  setMinQuantity() {
    if (this.product.productName && this.product.minQuantity) {
      const url = `https://localhost:44339/api/Product/SetMinQuantity?productName=${this.product.productName}&minQuantity=${this.product.minQuantity}`;
      this.http.put(url, {}).subscribe(
        (res: any) => {
          alert(`Minimum Quantity for ${this.product.productName} has been changed to ${this.product.minQuantity}`);
          console.log('Set Min Quantity Response:', res);
          this.product = { productName: '', maxQuantity: null };
          // Handle success response
        },
        (error) => {
          alert('Product is not found');
          console.error('Error setting min quantity', error);
          // Handle error response
        }
      );
    } else {
      console.error('Product ID and Min Quantity are required');
    }
  }
}
