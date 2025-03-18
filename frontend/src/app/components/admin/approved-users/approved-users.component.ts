import { Component } from '@angular/core';
import { SidebarComponent } from '../../sidebar/sidebar.component';
import { ControlsComponent } from '../controls/controls.component';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-approved-users',
  imports: [ControlsComponent,CommonModule,FormsModule],
  templateUrl: './approved-users.component.html',
  styleUrl: './approved-users.component.css'
})
export class ApprovedUsersComponent {
  approvedUsers: any[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getApprovedUsers();
  }

  getApprovedUsers() {
    this.http.get("https://localhost:44339/api/Admin/approved-users").subscribe(
      (res: any) => {
        console.log('API Response:', res);
        if (res) {
          this.approvedUsers = res;
          console.log('Approved Users:', this.approvedUsers);
        }
      },
      (error) => {
        console.error('Error fetching approved users data', error);
      }
    );
  }

  removeUser(user:any) {
    const url = `https://localhost:44339/api/Admin/delete/${user.uSerId}`;
    this.http.delete(url).subscribe(
      (res: any) => {
        console.log('Remove Response:', res);
        this.getApprovedUsers(); // Refresh the list after removal
      },
      (error) => {
        console.error('Error removing user', error);
      }
    );
  }
}
