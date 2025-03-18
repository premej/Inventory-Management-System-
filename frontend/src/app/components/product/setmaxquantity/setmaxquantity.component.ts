import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { SidebarComponent } from '../../sidebar/sidebar.component';
import { ProductmenuComponent } from '../productmenu/productmenu.component';
@Component({
  selector: 'app-setmaxquantity',
  imports: [FormsModule,CommonModule,SidebarComponent,ProductmenuComponent],
  templateUrl: './setmaxquantity.component.html',
  styleUrl: './setmaxquantity.component.css'
})
export class SetmaxquantityComponent {
  product: any = {
    productName: null,
    maxQuantity: null
  };

  constructor(private http: HttpClient) {}

  setMaxQuantity() {
    console.log(this.product);
    if (this.product.productName && this.product.maxQuantity) {
      const url = `https://localhost:44339/api/Product/SetMaxQuantity?productName=${this.product.productName}&maxQuantity=${this.product.maxQuantity}`;
      this.http.put(url,{}).subscribe(
        (res: any) => {
          alert(`Maximum Quantity for ${this.product.productName} has been changed to ${this.product.maxQuantity}`);
          console.log('Set Max Quantity Response:', res);
          // Handle success response
          this.product = { productName: null, maxQuantity: null };
        },
        (error) => {
          alert('Product is not found');
          console.error('Error setting max quantity', error);
          // Handle error response
        }
      );
    } else {
      console.error('Product ID and Max Quantity are required');
    }
  }
}
