import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { SidebarComponent } from '../../sidebar/sidebar.component';
import { TransactionmenuComponent } from '../transactionmenu/transactionmenu.component';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-productwisetransaction',
  imports: [CommonModule,FormsModule,SidebarComponent,TransactionmenuComponent],
  templateUrl: './productwisetransaction.component.html',
  styleUrl: './productwisetransaction.component.css'
})
export class ProductwisetransactionComponent {
  productTransactions: any[] = [];
  productId: number=0;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {}

  getProductTransactions() {
    if (this.productId) {
      this.http.get(`https://localhost:44339/api/Transaction/ProductWiseTransactions/${this.productId}`).subscribe(
        (res: any) => {
          console.log('API Response:', res);
          if (res) {
            this.productTransactions = res;
            console.log('Product Transactions:', this.productTransactions);
          }
        },
        (error) => {
          alert('Product transactions not found');
          console.error('Error fetching product transactions', error);
        }
      );
    }
  }
}
