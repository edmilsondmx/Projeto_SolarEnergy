import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, CanActivateChild, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate, CanActivateChild {

  constructor(private router:Router){}

  canActivateChild(childRoute: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | boolean {
    const token = window.localStorage.getItem('token');
    if(token != null){
      return true;
    } else {
      alert('Você não tem permissão para ver esta página, faça o login!')
      this.router.navigate(['']);
      return false;
    }
  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    const token = window.localStorage.getItem('token');
    if(token != null){
      return true;
    } else {
      alert('Você não tem permissão para ver esta página, faça o login!')
      this.router.navigate(['']);
      return false;
    }
  }
  
}
