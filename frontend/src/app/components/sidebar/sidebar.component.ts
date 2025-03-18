import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AdminsbComponent } from '../adminsb/adminsb.component';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-sidebar',
  imports: [FormsModule,CommonModule],
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.css'
})
export class SidebarComponent implements OnInit {
  isAdmin: boolean = false;
  username: string = '';
  email: string = '';
  role: string = '';
  showUserDetails: boolean = false;
  // constructor(private router:Router,private route: ActivatedRoute,){}
  constructor(private router:Router,private route: ActivatedRoute){}
  navigateTo(path: string) {
    if (path === '') {
      alert('You have been successfully logged out');
    }
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