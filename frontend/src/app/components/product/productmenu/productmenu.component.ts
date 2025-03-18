import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { SidebarComponent } from '../../sidebar/sidebar.component';

@Component({
  selector: 'app-productmenu',
  imports: [SidebarComponent],
  templateUrl: './productmenu.component.html',
  styleUrl: './productmenu.component.css'
})
export class ProductmenuComponent {
  constructor(private router:Router){}
  navigateTo(path: string) {
      this.router.navigate([path]);
    }
}
