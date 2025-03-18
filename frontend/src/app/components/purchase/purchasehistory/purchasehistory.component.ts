import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { PurchasemenuComponent } from '../purchasemenu/purchasemenu.component';
import { SidebarComponent } from '../../sidebar/sidebar.component';
@Component({
  selector: 'app-purchasehistory',
  imports: [CommonModule,FormsModule,PurchasemenuComponent,SidebarComponent],
  templateUrl: './purchasehistory.component.html',
  styleUrl: './purchasehistory.component.css'
})
export class PurchasehistoryComponent {
  purchaseList: any [] = [];

  constructor(private http: HttpClient) {

  }

  ngOnInit(): void {
    this.loadPurchase();
  }

  loadPurchase() {
    this.http.get("https://localhost:44339/api/Purchase/PurchaseHistory").subscribe((res:any) => {
      this.purchaseList = res;
    })
  }
}
