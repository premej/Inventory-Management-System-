import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { SidebarComponent } from '../../sidebar/sidebar.component';
import { PurchasemenuComponent } from '../purchasemenu/purchasemenu.component';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-purchasegetallsuppliers',
  imports: [SidebarComponent,PurchasemenuComponent,CommonModule,FormsModule],
  templateUrl: './purchasegetallsuppliers.component.html',
  styleUrl: './purchasegetallsuppliers.component.css'
})
export class PurchasegetallsuppliersComponent {
  // suppliersList: any[] = [];
  // newSupplier: any = {
  //   name: '',
  //   phoneNumber: '',
  //   email: ''
  // };
  // showAddSupplierForm: boolean = false;
  // editSupplier: any = null;
  // updatedSupplier: any = null;


  // constructor(private http: HttpClient) {}

  // ngOnInit(): void {
  //   this.getSuppliers();
  // }

  // getSuppliers() {
  //   this.http.get("https://localhost:44339/api/Purchase/Suppliers").subscribe(
  //     (res: any) => {
  //       console.log('API Response:', res);
  //       if (res) {
  //         this.suppliersList = res;
  //         console.log('Suppliers List:', this.suppliersList);
  //       }
  //     },
  //     (error) => {
  //       console.error('Error fetching suppliers data', error);
  //     }
  //   );
  // }

  // onAddSupplier() {
  //   this.http.post("https://localhost:44339/api/Purchase/AddSupplier", this.newSupplier).subscribe(
  //     (res: any) => {
  //       alert("Supplier added successfully");
  //       this.getSuppliers(); // Refresh the list
  //       this.newSupplier = { name: '', phoneNumber: '', email: '' }; // Reset the form
  //       this.showAddSupplierForm = false; // Hide the form
  //     },
  //     (error) => {
  //       console.error('Error adding supplier', error);
  //       alert("Error adding supplier");
  //     }
  //   );
  // }

  // onEditSupplier(supplier: any) {
  //   this.editSupplier = { ...supplier };
  //    // Clone the supplier object
  //    console.log(this.editSupplier);
  //    this.updatedSupplier = {
  //     name: this.editSupplier.supplierName,
  //     phoneNumber: this.editSupplier.phoneNumber,
  //     email: this.editSupplier.email
  //   };
  //   console.log(this.updatedSupplier);
  // }

  // onUpdateSupplier() {
  //   this.http.put(`https://localhost:44339/api/Purchase/UpdateSupplier/${this.editSupplier.id}`,this.updatedSupplier).subscribe(
  //     (res: any) => {
  //       alert("Supplier updated successfully");
  //       this.getSuppliers(); // Refresh the list
  //       this.editSupplier = null; // Clear the edit form
  //     },
  //     (error) => {
  //       console.error('Error updating supplier', error);
  //       alert("Error updating supplier");
  //     }
  //   );
  // }

  // onDeleteSupplier(id: number) {
  //   this.http.delete(`https://localhost:44339/api/Purchase/DeleteSupplier/${id}`).subscribe(
  //     (res: any) => {
  //       alert("Supplier deleted successfully");
  //       this.getSuppliers(); // Refresh the list
  //     },
  //     (error) => {
  //       console.error('Error deleting supplier', error);
  //       alert("Error deleting supplier");
  //     }
  //   );
  // }
  suppliersList: any[] = [];
  newSupplier: any = {
    name: '',
    phoneNumber: '',
    email: ''
  };
  showAddSupplierForm: boolean = false;
  editSupplier: any = null;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getSuppliers();
  }

  getSuppliers() {
    this.http.get("https://localhost:44339/api/Purchase/Suppliers").subscribe(
      (res: any) => {
        console.log('API Response:', res);
        if (res) {
          this.suppliersList = res;
          console.log('Suppliers List:', this.suppliersList);
        }
      },
      (error) => {
        console.error('Error fetching suppliers data', error);
      }
    );
  }

  onAddSupplier() {
    this.http.post("https://localhost:44339/api/Purchase/AddSupplier", this.newSupplier).subscribe(
      (res: any) => {
        alert("Supplier added successfully");
        this.getSuppliers(); // Refresh the list
        this.newSupplier = { name: '', phoneNumber: '', email: '' }; // Reset the form
        this.showAddSupplierForm = false; // Hide the form
      },
      (error) => {
        console.error('Error adding supplier', error);
        alert("Error adding supplier");
      }
    );
  }

  onEditSupplier(supplier: any) {
    this.editSupplier = { ...supplier }; // Clone the supplier object
  }

  onUpdateSupplier() {
    // Transform the editSupplier object to match the expected format
    const updatedSupplier = {
      name: this.editSupplier.supplierName,
      phoneNumber: this.editSupplier.phoneNumber,
      email: this.editSupplier.email
    };

    this.http.put(`https://localhost:44339/api/Purchase/UpdateSupplier/${this.editSupplier.id}`, updatedSupplier).subscribe(
      (res: any) => {
        alert("Supplier updated successfully");
        this.getSuppliers(); // Refresh the list
        this.editSupplier = null; // Clear the edit form
      },
      (error) => {
        console.error('Error updating supplier', error);
        alert("Error updating supplier");
      }
    );
  }

  onDeleteSupplier(id: number) {
    this.http.delete(`https://localhost:44339/api/Purchase/DeleteSupplier/${id}`).subscribe(
      (res: any) => {
        alert("Supplier deleted successfully");
        this.getSuppliers(); // Refresh the list
      },
      (error) => {
        console.error('Error deleting supplier', error);
        alert("Error deleting supplier");
      }
    );
  }
}
