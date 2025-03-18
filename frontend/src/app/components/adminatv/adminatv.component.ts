import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FooterComponent } from '../footer/footer.component';
import { HeaderComponent } from '../header/header.component';

@Component({
  selector: 'app-adminatv',
  imports: [FooterComponent,HeaderComponent],
  templateUrl: './adminatv.component.html',
  styleUrl: './adminatv.component.css'
})
export class AdminatvComponent {
  constructor(private router:Router){}
  navigateTo(path: string) {
      this.router.navigate([path]);
    }
}
