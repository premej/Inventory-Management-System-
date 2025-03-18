import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { SidebarComponent } from '../../sidebar/sidebar.component';
import { SalesmenuComponent } from '../salesmenu/salesmenu.component';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-getallcustomers',
  imports: [SidebarComponent,SalesmenuComponent,CommonModule,FormsModule],
  templateUrl: './getallcustomers.component.html',
  styleUrl: './getallcustomers.component.css'
})
export class GetallcustomersComponent {
  customersList: any[] = [];
  newCustomer: any = {
    name: '',
    phoneNumber: '',
    email: ''
  };
  showAddCustomerForm: boolean = false;
  editCustomer: any = null;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getCustomers();
  }

  getCustomers() {
    this.http.get("https://localhost:44339/api/Sales/Customers").subscribe(
      (res: any) => {
        console.log('API Response:', res);
        if (res) {
          this.customersList = res;
          console.log('Customers List:', this.customersList);
        }
      },
      (error) => {
        console.error('Error fetching customers data', error);
      }
    );
  }

  onAddCustomer() {
    this.http.post("https://localhost:44339/api/Sales/AddCustomer", this.newCustomer).subscribe(
      (res: any) => {
        alert("Customer added successfully");
        this.getCustomers(); // Refresh the list
        this.newCustomer = { name: '', phoneNumber: '', email: '' }; // Reset the form
        this.showAddCustomerForm = false; // Hide the form
      },
      (error) => {
        console.error('Error adding customer', error);
        alert("Error adding customer");
      }
    );
  }

  onEditCustomer(customer: any) {
    this.editCustomer = { ...customer }; // Clone the customer object
  }

  onUpdateCustomer() {
    // Transform the editCustomer object to match the expected format
    const updatedCustomer = {
      name: this.editCustomer.customerName,
      phoneNumber: this.editCustomer.phoneNumber,
      email: this.editCustomer.email
    };

    this.http.put(`https://localhost:44339/api/Sales/UpdateCustomer/${this.editCustomer.id}`, updatedCustomer).subscribe(
      (res: any) => {
        alert("Customer updated successfully");
        this.getCustomers(); // Refresh the list
        this.editCustomer = null; // Clear the edit form
      },
      (error) => {
        console.error('Error updating customer', error);
        alert("Error updating customer");
      }
    );
  }

  onDeleteCustomer(id: number) {
    this.http.delete(`https://localhost:44339/api/Sales/DeleteCustomer/${id}`).subscribe(
      (res: any) => {
        alert("Customer deleted successfully");
        this.getCustomers(); // Refresh the list
      },
      (error) => {
        console.error('Error deleting customer', error);
        alert("Error deleting customer");
      }
    );
  }
}
