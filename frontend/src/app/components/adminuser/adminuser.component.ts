import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { HeaderComponent } from '../header/header.component';
import { FooterComponent } from '../footer/footer.component';
@Component({
  selector: 'app-adminuser',
  imports: [HeaderComponent,FooterComponent],
  templateUrl: './adminuser.component.html',
  styleUrl: './adminuser.component.css'
})
export class AdminuserComponent {
  constructor(private router: Router) {}
  navigateTo(route: string){
    this.router.navigate([route]);
   }
}
