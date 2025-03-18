import { Component } from '@angular/core';
import { HeaderComponent } from '../../header/header.component';
import { FooterComponent } from '../../footer/footer.component';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { FormControl,FormGroup,Validators,ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-register',
  imports: [HeaderComponent,FooterComponent,ReactiveFormsModule,CommonModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  registerForm: FormGroup;

  constructor(private router: Router,private http:HttpClient) {
    this.registerForm = new FormGroup({
      username: new FormControl('', Validators.required),
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required, Validators.minLength(6)]),
    });
  }
  onSubmit() {
    if (this.registerForm.valid) {
      console.log('Registration Form Submitted!', this.registerForm.value);
      // this.router.navigate(['/login']);
      console.log(this.registerForm);
      const url = `https://localhost:44339/api/Auth/register?username=${this.registerForm.value.username}&password=${this.registerForm.value.password}&role=User&email=${this.registerForm.value.email}`;
    
    this.http.post(url, {}).subscribe(
      (res: any) => {
        alert('Registration Request has been sent for Admin Approval');
        this.router.navigate(['/register']); // Navigate to the same page
      },
      (error) => {
        console.error('Error during registration', error);
      }
    );
    }
  }
  navigateTo(path: string) {
    this.router.navigate([path]);
  }

}
