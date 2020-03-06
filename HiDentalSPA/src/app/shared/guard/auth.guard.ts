import {Injectable} from '@angular/core';
import {Router, ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot} from '@angular/router';

@Injectable({
    providedIn: 'root'
})
export class AuthGuard implements CanActivate {

    constructor(private router: Router) { }

    canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot) {

        // if (localStorage.getItem('currentUser')) {
        //     return true;
        // }
        // this.router.navigate(['authentication/login-1'], { queryParams: { returnUrl: state.url }});
        // return false;

        return true;
    }
}
