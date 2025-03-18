import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { SidebarComponent } from '../../sidebar/sidebar.component';

@Component({
  selector: 'app-purchasemenu',
  imports: [SidebarComponent],
  templateUrl: './purchasemenu.component.html',
  styleUrl: './purchasemenu.component.css'
})
export class PurchasemenuComponent {
  constructor(private router:Router){}
  navigateTo(path: string) {
      this.router.navigate([path]);
    }
}
