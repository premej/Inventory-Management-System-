import { Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { HomeComponent } from './components/home/home.component';
import { RegisterComponent } from './components/user/register/register.component';
import { LoginComponent } from './components/user/login/login.component';
import { AboutComponent } from './components/about/about.component';
import { AdminuserComponent } from './components/adminuser/adminuser.component';
import { LoginComponent1 } from './components/admin/login/login.component';
import { ContactusComponent } from './components/contactus/contactus.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { PendingRequestsComponent } from './components/admin/pending-requests/pending-requests.component';
import { ApprovedUsersComponent } from './components/admin/approved-users/approved-users.component';
import { ControlsComponent } from './components/admin/controls/controls.component';
import { ReviewInventoryComponent } from './components/stock/review-inventory/review-inventory.component';
import { GetunderstockComponent } from './components/stock/getunderstock/getunderstock.component';
import { GetoverstockComponent } from './components/stock/getoverstock/getoverstock.component';
import { OutofstockComponent } from './components/stock/outofstock/outofstock.component';
import { StockmenuComponent } from './components/stock/stockmenu/stockmenu.component';
import { PurchasemenuComponent } from './components/purchase/purchasemenu/purchasemenu.component';
import { SalesmenuComponent } from './components/sale/salesmenu/salesmenu.component';
import { TransactionmenuComponent } from './components/transaction/transactionmenu/transactionmenu.component';
import { ProductmenuComponent } from './components/product/productmenu/productmenu.component';
import { AlltransactionsComponent } from './components/transaction/alltransactions/alltransactions.component';
import { ProductwisetransactionComponent } from './components/transaction/productwisetransaction/productwisetransaction.component';
import { GetallcategoriesComponent } from './components/product/getallcategories/getallcategories.component';
import { NewProductComponent } from './components/product/new-product/new-product.component';
import { SetmaxquantityComponent } from './components/product/setmaxquantity/setmaxquantity.component';
import { SetminquantityComponent } from './components/product/setminquantity/setminquantity.component';
import { UpdatepriceComponent } from './components/product/updateprice/updateprice.component';
import { PurchasegetallsuppliersComponent } from './components/purchase/purchasegetallsuppliers/purchasegetallsuppliers.component';
import { NewpurchaseComponent } from './components/purchase/newpurchase/newpurchase.component';
import { PurchasehistoryComponent } from './components/purchase/purchasehistory/purchasehistory.component';
import { PurchasereportComponent } from './components/purchase/purchasereport/purchasereport.component';
import { NewsaleComponent } from './components/sale/newsale/newsale.component';
import { SaleshistoryComponent } from './components/sale/saleshistory/saleshistory.component';
import { SalesreportComponent } from './components/sale/salesreport/salesreport.component';
import { GetallcustomersComponent } from './components/sale/getallcustomers/getallcustomers.component';
import { AdminsbComponent } from './components/adminsb/adminsb.component';
import { AdminatvComponent } from './components/adminatv/adminatv.component';

export const routes: Routes = [
 { path: '', component: HomeComponent },
 { path: 'register', component: RegisterComponent },
 { path: 'login', component: LoginComponent },
 { path: 'login1', component: LoginComponent1 },
 {path:'logreg',component:AdminuserComponent},
 { path: 'about', component: AboutComponent },
 {path:'contactus',component:ContactusComponent},
 {path:'sidebar',component:SidebarComponent},
 {path:'pendingreq',component:PendingRequestsComponent},
 {path:'approvedusers',component:ApprovedUsersComponent},
 {path:'controls',component:ControlsComponent},
 {path:'reviewinventory',component:ReviewInventoryComponent},
 {path:'understock',component:GetunderstockComponent},
 {path:'overstock',component:GetoverstockComponent},
 {path:'outofstock',component:OutofstockComponent},
 {path:'stockmenu',component:StockmenuComponent},
 {path:'productmenu',component:ProductmenuComponent},
 {path:'purchasemenu',component:PurchasemenuComponent},
 {path:'salesmenu',component:SalesmenuComponent},
 {path:'transactionmenu',component:TransactionmenuComponent},
 {path:'alltransactions',component:AlltransactionsComponent},
 {path:'producttxn',component:ProductwisetransactionComponent},
{path:'getallcategories',component:GetallcategoriesComponent},
{path:'newproduct',component:NewProductComponent},
{path:'setmaxquantity',component:SetmaxquantityComponent},
{path:'setminquantity',component:SetminquantityComponent},
{path:'updateprice',component:UpdatepriceComponent},
{path:'getallsuppliers',component:PurchasegetallsuppliersComponent},
{path:'newpurchase',component:NewpurchaseComponent},
{path:'purchasehistory',component:PurchasehistoryComponent},
{path:'purchasereport',component:PurchasereportComponent},
{path:'newsale',component:NewsaleComponent},
{path:'saleshistory',component:SaleshistoryComponent},
{path:'salesreport',component:SalesreportComponent},
{path:'getallcustomers',component:GetallcustomersComponent},
{path:'adminsb',component:AdminsbComponent},
{path:'adminatv',component:AdminatvComponent},
 {path:'**',redirectTo:''},
];
