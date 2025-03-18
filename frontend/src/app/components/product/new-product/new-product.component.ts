import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ProductmenuComponent } from '../productmenu/productmenu.component';
import { SidebarComponent } from '../../sidebar/sidebar.component';
@Component({
  selector: 'app-new-product',
  imports: [FormsModule,CommonModule,ProductmenuComponent,SidebarComponent],
  templateUrl: './new-product.component.html',
  styleUrl: './new-product.component.css'
})
export class NewProductComponent {
  product: any = {
    productName: '',
    product_detail: '',
    category_id: null,
    category_Name: '',
    amount: null
  };
  categories: any[] = [];

  constructor(private http: HttpClient) {}

  addNewProduct() {
    const url = 'https://localhost:44339/api/Product/NewProduct';
    this.http.post(url, this.product).subscribe(
      (res: any) => {
        alert("New Product has been added successfully");
        console.log('New Product Added:', res);
        this.product = {
          productName: null,
          product_detail: null,
          category_id: null,
          category_Name: null,
          amount: null
        };
        // Handle success response
      },
      (error) => {
        alert('Error adding new product');
        console.error('Error adding new product', error);
      }
    );
  }

  // checkCategories() {
  //   const url = 'https://localhost:44339/api/Product/GetAllCategories';
  //   this.http.get(url).subscribe(
  //     (res: any) => {
  //       this.categories = res;
  //       console.log('Categories:', this.categories);
  //     },
  //     (error) => {
  //       console.error('Error fetching categories', error);
  //     }
  //   );
  // }
  showCategoriesModal: boolean = false;
  checkCategories() {
    const url = 'https://localhost:44339/api/Product/GetAllCategories';
    this.http.get(url).subscribe(
      (res: any) => {
       this.categories=res;
        this.showCategoriesModal = true;
      },
      (error) => {
        console.error('Error fetching categories', error);
      }
    );
  }

  closeCategoriesModal() {
    this.showCategoriesModal = false;
  }
}

