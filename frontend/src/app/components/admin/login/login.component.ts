import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule,FormControl,FormGroup,Validators,ReactiveFormsModule } from '@angular/forms';
import { HeaderComponent } from '../../header/header.component';
import { FooterComponent } from '../../footer/footer.component';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../../services/auth.service';
import { HttpClient } from '@angular/common/http';
import {jwtDecode} from 'jwt-decode';
@Component({
  selector: 'app-login-admin',
  imports: [HeaderComponent,FooterComponent,ReactiveFormsModule,CommonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent1 {
  loginForm: FormGroup;
  loginData: any = {};
  constructor(private router: Router,private authService: AuthService,private http:HttpClient) {
    this.loginForm = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required, Validators.minLength(6)]),
    });
  }

  loginObj:any={
    email:'',
    password:''
  }
  ngOnInit(): void {
    
  }
  navigateTo(path: string) {
    this.router.navigate([path]);
  }
  onLogin() {
    if (this.loginForm.valid) {
      console.log(this.loginForm.value, "this.loginForm.value");
 
      this.authService.login(this.loginForm.value).subscribe(
        (response: any) => {
          console.log(response, "Login Success");
          console.log(response.token);
 
          if (response.token) {
            this.authService.storeToken(response.token);
            // console.log(response);
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
            localStorage.setItem('role',role); // Store user role
            alert("Admin Login Success");
            this.router.navigate(['adminatv'],{ queryParams: { username, email, role } });
          }
        },
        (error:any) => {
          alert("Invalid Credentials, Please try again");
          console.error(error, "Login Failed");
        }
      );
    }
  }
 
  /** Redirect user based on role */
  // private redirectUser(role: string) {
  //   if (role === 'Admin') {
  //     console.log('Admin');
  //     this.router.navigate(['outofstock']);
  //   } else if (role === 'User') {
  //     console.log('Customer');
  //     this.router.navigate(['/raise-ticket']);
  //   } else {
  //     this.router.navigate(['/login']);
  //   }
  // }
  }

