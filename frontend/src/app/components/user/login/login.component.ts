import { Component } from '@angular/core';
import { FormControl,FormGroup,Validators,ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { HeaderComponent } from '../../header/header.component';
import { FooterComponent } from '../../footer/footer.component';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../../services/auth.service';
import { HttpClient } from '@angular/common/http';
import { jwtDecode } from 'jwt-decode';
@Component({
  selector: 'app-login',
  imports: [HeaderComponent,FooterComponent,ReactiveFormsModule,CommonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  loginForm: FormGroup;

  constructor(private router: Router,private authService: AuthService,private http:HttpClient) {
    this.loginForm = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required, Validators.minLength(6)]),
    });
  }

  onLogin() {
    if (this.loginForm.valid) {
      console.log(this.loginForm.value, "this.loginForm.value");
 
      this.authService.loginu(this.loginForm.value).subscribe(
        (response: any) => {
          console.log(response, "Login Success");
 
          if (response.token) {
            this.authService.storeToken(response.token);
            const decodedToken: any = jwtDecode(response.token);
            console.log('Decoded Token:', decodedToken);

            const username = decodedToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'];
            const email = decodedToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress'];
            const role = decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];

            console.log('Username:', username);
            console.log('Email:', email);
            console.log('Role:', role);
            localStorage.setItem('username',username);
            localStorage.setItem('email',email);
            localStorage.setItem('role',role);
            alert("User Login Success");
            this.router.navigate(['outofstock']);// Redirect based on role
          }
        },
        (error:any) => {
          alert("Invalid Credentials, Please try again or Register");
          console.error(error, "Login Failed");
        }
      );
    }
  }

  navigateTo(path: string) {
    this.router.navigate([path]);
  }
}
