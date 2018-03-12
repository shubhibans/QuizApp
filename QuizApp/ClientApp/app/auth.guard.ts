import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { UserServiceService } from './Services/user-service.service';


@Injectable()
export class AuthGuard implements CanActivate {
    constructor(private user: UserServiceService, private router: Router) { }

    canActivate() {

        if (!this.user.isLoggedIn()) {
           
            this.router.navigate(['/login']);
            return false;
        }

        return true;
    }
}