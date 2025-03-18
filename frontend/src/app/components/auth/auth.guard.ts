import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { log } from 'console';
 
@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router) {}
 
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    const allowedRoles = route.data['allowedRoles'] as string[];
    console.log(allowedRoles,"allowedRoles")
 
    if (this.authService.isLoggedIn() && this.authService.isAuthorized(allowedRoles)) {
      return true;
    }
 
    // Redirect to login if unauthorized
    this.router.navigate(['/login']);
    return false;
  }
}