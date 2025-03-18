import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable,tap } from 'rxjs';
import { Router } from '@angular/router';
import { encode } from 'punycode';
import { jwtDecode } from 'jwt-decode';
@Injectable({
 providedIn: 'root' // Provided globally
})
export class AuthService {
  

  private apiUrl ='https://localhost:44339/api' ;
 
  constructor(private http: HttpClient, private route:Router) {}
 
  /** Register a new user */
  register(userData: any) {
    return this.http.post(`${this.apiUrl}/register`, userData);
  }
 
  /** Login method */
  login(credentials: { email: string; password: string }) {
    console.log(credentials,"credentials");
    return this.http.post(`${this.apiUrl}/Admin/login?email=${encodeURIComponent(credentials.email)}&password=${encodeURIComponent(credentials.password)}`,{});
 
  }
  loginu(credentials: { email: string; password: string }) {
    console.log(credentials,"credentials");
    return this.http.post(`${this.apiUrl}/Auth/login`, credentials);
 
  }
    isAuthorized(allowedRoles: string[]): boolean {
    return allowedRoles.includes(this.getRole() || '');
  }
 
 
  /** Store user authentication token */
  storeToken(token: string) {
    localStorage.setItem('authToken', token);
  }
 
  /** Get stored authentication token */
  getToken(): string | null {
    return localStorage.getItem('authToken');
  }
 
  /** Check if user is logged in */
  isLoggedIn(): boolean {
    return this.getToken() !== null;
  }
 
  /** Logout user */
  logout() {
    localStorage.clear();
    this.route.navigateByUrl('/login');
  }
 
   getRole(): string | null {
    return localStorage.getItem('role');
  }
  getUserDetails(): any {
    const token = this.getToken();
    if (token) {
      return jwtDecode(token);
    }
    return null;
  }

    private storeUserData(token: string, role: string) {
    localStorage.setItem('authToken', token);
    localStorage.setItem('userRole', role);
  }
}