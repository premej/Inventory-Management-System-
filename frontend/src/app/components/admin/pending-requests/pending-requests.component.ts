import { Component } from '@angular/core';
import { SidebarComponent } from '../../sidebar/sidebar.component';
import { ControlsComponent } from '../controls/controls.component';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-pending-requests',
  imports: [ControlsComponent,CommonModule,FormsModule],
  templateUrl: './pending-requests.component.html',
  styleUrl: './pending-requests.component.css'
})
export class PendingRequestsComponent {
  pendingRequests: any[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getPendingRequests();
  }

  getPendingRequests() {
    this.http.get("https://localhost:44339/api/Admin/Pending-request").subscribe(
      (res: any) => {
        console.log('API Response:', res);
        if (res) {
          this.pendingRequests = res;
          console.log('Pending Requests:', this.pendingRequests);
        }
      },
      (error) => {
        console.error('Error fetching pending requests data', error);
      }
    );
  }

  approveRequest(request: any) {
    const url = `https://localhost:44339/api/Admin/approve/${request.id}?approve=true`;
    this.http.post(url, {}).subscribe(
      (res: any) => {
        console.log('Approve Response:', res);
        this.getPendingRequests(); // Refresh the list after approval
      },
      (error) => {
        console.error('Error approving request', error);
      }
    );
  }
}
