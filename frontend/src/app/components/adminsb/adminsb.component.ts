import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-adminsb',
  imports: [],
  templateUrl: './adminsb.component.html',
  styleUrl: './adminsb.component.css'
})
export class AdminsbComponent {
  constructor(private router:Router){}
  navigateTo(path: string) {
      this.router.navigate([path]);
    }
  
}
