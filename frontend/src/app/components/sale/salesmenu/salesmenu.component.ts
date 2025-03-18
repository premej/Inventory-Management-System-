import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { SidebarComponent } from '../../sidebar/sidebar.component';

@Component({
  selector: 'app-salesmenu',
  imports: [SidebarComponent],
  templateUrl: './salesmenu.component.html',
  styleUrl: './salesmenu.component.css'
})
export class SalesmenuComponent {
  constructor(private router:Router){}
  navigateTo(path: string) {
      this.router.navigate([path]);
    }
  
}
