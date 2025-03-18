import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { SidebarComponent } from '../../sidebar/sidebar.component';
import { ProductmenuComponent } from '../productmenu/productmenu.component';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-getallcategories',
  imports: [SidebarComponent,ProductmenuComponent,CommonModule,FormsModule],
  templateUrl: './getallcategories.component.html',
  styleUrl: './getallcategories.component.css'
})
export class GetallcategoriesComponent {
  categoriesList: any[] = [];
  newCategory: any = {
    category_Name: ''
  };
  showAddCategoryForm: boolean = false;
  editCategory: any = null;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getCategories();
  }

  getCategories() {
    this.http.get("https://localhost:44339/api/Product/GetAllCategories").subscribe(
      (res: any) => {
        console.log('API Response:', res);
        if (res) {
          this.categoriesList = res;
          console.log('Categories List:', this.categoriesList);
        }
      },
      (error) => {
        console.error('Error fetching categories data', error);
      }
    );
  }

  onAddCategory() {
    console.log(this.newCategory);
    this.http.post("https://localhost:44339/api/Product/AddCategory", this.newCategory).subscribe(
      (res: any) => {
        alert("Category added successfully");
        this.getCategories(); // Refresh the list
        this.newCategory = { name: '' }; // Reset the form
        this.showAddCategoryForm = false; // Hide the form
      },
      (error) => {
        console.error('Error adding category', error);
        alert("Error adding category");
      }
    );
  }

  onEditCategory(category: any) {
    this.editCategory = { ...category }; 
    // Clone the category object
  }

  onUpdateCategory() {
    console.log(this.editCategory);
    this.http.put(`https://localhost:44339/api/Product/UpdateCategory/${this.editCategory.category_id}`, this.editCategory).subscribe(
      (res: any) => {
        alert("Category updated successfully");
        this.getCategories(); // Refresh the list
        this.editCategory = null; // Clear the edit form
      },
      (error) => {
        console.error('Error updating category', error);
        alert("Error updating category");
      }
    );
  }

  onDeleteCategory(id: number) {
    console.log(id);
    this.http.delete(`https://localhost:44339/api/Product/DeleteCategory/${id}`).subscribe(
      (res: any) => {
        alert("Category deleted successfully");
        this.getCategories(); // Refresh the list
      },
      (error) => {
        console.error('Error deleting category', error);
        alert("Error deleting category");
      }
    );
  }
}
