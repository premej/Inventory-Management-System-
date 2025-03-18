import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { SidebarComponent } from '../../sidebar/sidebar.component';
import { SalesmenuComponent } from '../salesmenu/salesmenu.component';
import { Router } from '@angular/router';
@Component({
  selector: 'app-newsale',
  imports: [FormsModule,CommonModule,SidebarComponent,SalesmenuComponent],
  templateUrl: './newsale.component.html',
  styleUrl: './newsale.component.css'
})
export class NewsaleComponent {
  saleObj: any = {};
  productList: any[] = [];
  stockAvailability: number | null = null;

  constructor(private http: HttpClient,private router:Router){

  }
navigateTo(path: string) {
    this.router.navigate([path]);
  }

  ngOnInit(): void {
    this.getAllProduct();
  }

  getAllProduct() {
    this.http.get("https://localhost:44339/api/Stock/review_inventory").subscribe((res: any) => {
      this.productList = res;
    })
  }
  checkStock() {
    console.log(this.saleObj.productid);
    this.http.get("https://localhost:44339/api/Stock/GetStockByProductId?productId="+ this.saleObj.productid).subscribe((res: any) => {
      if(res==0) {
        console.log(res);
        alert("Stock Not Available");
        // this.saleObj.productId = 0;
        this.stockAvailability = 0;
      }
      else {
        this.stockAvailability = res;
      }
    },
      error=>{
        alert("Enter valid product id");
      })
  }
  onSave() {
    console.log(this.saleObj);
    this.http.post("https://localhost:44339/api/Sales/NewSale",this.saleObj).subscribe((res:any)=>{
      if(res) {
        alert("Sale Done Success");
        console.log(res.message);
      } 
    },
    error=>{
      alert("Enter valid product id");
    })
  }
}
