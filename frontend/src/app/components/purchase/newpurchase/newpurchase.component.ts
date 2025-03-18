import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { SidebarComponent } from '../../sidebar/sidebar.component';
import { PurchasemenuComponent } from '../purchasemenu/purchasemenu.component';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-newpurchase',
  imports: [SidebarComponent,PurchasemenuComponent,CommonModule,FormsModule],
  templateUrl: './newpurchase.component.html',
  styleUrl: './newpurchase.component.css'
})
export class NewpurchaseComponent  {
  purchaseObj: any = {
    "supplierId":0,
    "productId": 0,
    "quantity": 0,
    "supplierName": "",
  };
  productList: any[] = [];

  constructor(private http: HttpClient,private router:Router){

  }
  ngOnInit(): void {
    this.getAllProduct();
  }
  navigateTo(path: string) {
    this.router.navigate([path]);
  }
  getAllProduct() {
    this.http.get("https://localhost:44339/api/Stock/review_inventory").subscribe((res: any) => {
      this.productList = res;
    })
  }
  onSave() {
    this.http.post("https://localhost:44339/api/Purchase/NewPurchase",this.purchaseObj).subscribe((res:any)=>{
      alert(res.message);
    },
    error=>{
      alert("Supplier or product does not exist")
    })
  }
}
