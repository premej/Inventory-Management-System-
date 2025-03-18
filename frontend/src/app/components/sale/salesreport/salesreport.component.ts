import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { SidebarComponent } from '../../sidebar/sidebar.component';
import { SalesmenuComponent } from '../salesmenu/salesmenu.component';

@Component({
  selector: 'app-salesreport',
  imports: [CommonModule,FormsModule,SidebarComponent,SalesmenuComponent],
  templateUrl: './salesreport.component.html',
  styleUrl: './salesreport.component.css'
})
export class SalesreportComponent implements OnInit{
  salesList: any[] = [];
  filteredSales: any[] = [];
  fromDate: string = "";
  toDate: string = "";

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.loadSales();
  }

  loadSales() {
    this.http.get("https://localhost:44339/api/Sales/SalesHistory").subscribe((res: any) => {
      this.salesList = res;
      this.filteredSales = this.salesList; // Initialize filteredSales with all sales
    });
  }

  filterSales() {
    if (this.fromDate && this.toDate) {
      const formattedFromDate = this.convertToISOFormat(this.fromDate);
      const formattedToDate = this.convertToISOFormat(this.toDate);
      const url = `https://localhost:44339/api/Sales/SalesReport?startDate=${formattedFromDate}&endDate=${formattedToDate}&period=daily`;
      this.http.get(url).subscribe(
        (res: any) => {
          this.filteredSales = res;
        },
        (error) => {
          console.error('Error fetching filtered sales data', error);
        }
      );
    } else {
      this.filteredSales = this.salesList; // If no date range is selected, show all sales
    }
  }

  convertToISOFormat(dateString: string): string {
    const [year, month, day] = dateString.split('-');
    return `${year}-${month}-${day}`;
  }
}
