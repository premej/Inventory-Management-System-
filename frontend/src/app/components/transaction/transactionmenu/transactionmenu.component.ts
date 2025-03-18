import { Component } from '@angular/core';
import { SidebarComponent } from '../../sidebar/sidebar.component';
import { Router } from '@angular/router';
@Component({
  selector: 'app-transactionmenu',
  imports: [SidebarComponent],
  templateUrl: './transactionmenu.component.html',
  styleUrl: './transactionmenu.component.css'
})
export class TransactionmenuComponent {
  constructor(private router:Router){}
  navigateTo(path: string) {
      this.router.navigate([path]);
    }
}
