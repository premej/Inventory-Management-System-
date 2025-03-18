import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { SidebarComponent } from '../../sidebar/sidebar.component';
@Component({
  selector: 'app-stockmenu',
  imports: [SidebarComponent],
  templateUrl: './stockmenu.component.html',
  styleUrl: './stockmenu.component.css'
})
export class StockmenuComponent {
  constructor(private router:Router){}
  navigateTo(path: string) {
      this.router.navigate([path]);
    }
}
