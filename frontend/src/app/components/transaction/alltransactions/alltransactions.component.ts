import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { SidebarComponent } from '../../sidebar/sidebar.component';
import { TransactionmenuComponent } from '../transactionmenu/transactionmenu.component';
@Component({
  selector: 'app-alltransactions',
  imports: [SidebarComponent,TransactionmenuComponent,CommonModule],
  templateUrl: './alltransactions.component.html',
  styleUrl: './alltransactions.component.css'
})
export class AlltransactionsComponent {
  transactionsList: any[] = [];
  selectedTransaction: any = null;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getTransactions();
  }

  getTransactions() {
    this.http.get("https://localhost:44339/api/Transaction/usertransaction").subscribe(
      (res: any) => {
        console.log('API Response:', res);
        if (res) {
          this.transactionsList = res;
          console.log('Transactions List:', this.transactionsList);
        }
      },
      (error) => {
        console.error('Error fetching transactions data', error);
      }
    );
  }

}

// export class TransactionsComponent implements OnInit {
 
//   getTransactionDetails(productId: number) {
//     this.http.get(`https://localhost:44339/api/Transaction/product/${productId}`).subscribe(
//       (res: any) => {
//         console.log('Transaction Details:', res);
//         if (res) {
//           this.selectedTransaction = res;
//         }
//       },
//       (error) => {
//         console.error('Error fetching transaction details', error);
//       }
//     );
//   }
// }