import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { PurchasemenuComponent } from '../purchasemenu/purchasemenu.component';
import { SidebarComponent } from '../../sidebar/sidebar.component';
@Component({
  selector: 'app-purchasereport',
  imports: [CommonModule,FormsModule,PurchasemenuComponent,SidebarComponent],
  templateUrl: './purchasereport.component.html',
  styleUrl: './purchasereport.component.css'
})
export class PurchasereportComponent {
  purchaseList: any[] = [];
  filteredPurchases: any[] = [];
  fromDate: string="";
  toDate: string="";

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.loadPurchases();
  }

  loadPurchases() {
    this.http.get("https://localhost:44339/api/Purchase/PurchaseHistory").subscribe((res: any) => {
      this.purchaseList = res;
      this.filteredPurchases = this.purchaseList; // Initialize filteredPurchases with all purchases
    });
  }

  filterPurchases() {
    if (this.fromDate && this.toDate) {
      const formattedFromDate = this.convertToISOFormat(this.fromDate);
      const formattedToDate = this.convertToISOFormat(this.toDate);
      const url = `https://localhost:44339/api/Purchase/PurchaseReport?startDate=${this.fromDate}&endDate=${this.toDate}&period=daily`;
      this.http.get(url).subscribe(
        (res: any) => {
          this.filteredPurchases = res;
        },
        (error) => {
          console.error('Error fetching filtered purchase data', error);
        }
      );
    } else {
      this.filteredPurchases = this.purchaseList; // If no date range is selected, show all purchases
    }
  }
  convertToISOFormat(dateString: string): string {
    const [day, month, year] = dateString.split('/');
    return `${year}-${month}-${day}`;
  }
}
