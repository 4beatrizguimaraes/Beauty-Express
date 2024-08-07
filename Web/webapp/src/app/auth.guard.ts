import { ActivatedRouteSnapshot, CanActivateFn, Router, RouterStateSnapshot, UrlTree } from "@angular/router";
import { LoginService } from "./servicos/login.service";
import { inject, Injectable } from "@angular/core";
import { map, Observable } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class AuthGuard {

  constructor(private router: Router, private loginService: LoginService)   
 {}

  canActivate: CanActivateFn = (route: ActivatedRouteSnapshot, state: RouterStateSnapshot) :
  Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree => {
    return this.loginService.tokenValido().pipe(
      map(valido => {
        if (valido) {
          return true;
        } else {
          this.router.navigate(['/home']);
          return false;
        }
      })
    );
  }
}