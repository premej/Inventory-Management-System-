import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { SidebarComponent } from '../../sidebar/sidebar.component';
import { SalesmenuComponent } from '../salesmenu/salesmenu.component';

@Component({
  selector: 'app-saleshistory',
  imports: [FormsModule,CommonModule,SidebarComponent,SalesmenuComponent],
  templateUrl: './saleshistory.component.html',
  styleUrl: './saleshistory.component.css'
})
export class SaleshistoryComponent {
  salesList: any[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.loadSales();
  }

  loadSales() {
    this.http.get("https://localhost:44339/api/Sales/SalesHistory").subscribe((res: any) => {
      this.salesList = res;
    });
  }
}
