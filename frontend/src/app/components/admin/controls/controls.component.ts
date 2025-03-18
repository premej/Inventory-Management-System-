import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
// import { SidebarComponent } from '../../sidebar/sidebar.component';
import { ActivatedRoute, Router } from '@angular/router';
@Component({
  selector: 'app-controls',
  imports: [CommonModule,FormsModule],
  templateUrl: './controls.component.html',
  styleUrl: './controls.component.css'
})
export class ControlsComponent {
  username: string = '';
  email: string = '';
  role: string = '';
  showUserDetails: boolean = false;
  constructor(private router:Router,private route: ActivatedRoute){}
  navigateTo(path: string) {
    this.router.navigate([path]);
  }
  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.username = localStorage.getItem('username') || '';
      this.email = localStorage.getItem('email') || '';
      this.role = localStorage.getItem('role') || '';
      console.log('User Details:', this.username, this.email, this.role);
    });
  }
  toggleUserDetails() {
    this.showUserDetails = !this.showUserDetails;
  }
}
