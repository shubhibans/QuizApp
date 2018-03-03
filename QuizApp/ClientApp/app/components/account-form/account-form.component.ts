import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserRegistration } from '../../Models/user-registration.interface';
import { UserServiceService } from '../../Services/user-service.service';

@Component({
    selector: 'app-account-form',
    templateUrl: './account-form.component.html',
    styleUrls: ['./account-form.component.css'],
    providers: [UserServiceService]
})
export class AccountFormComponent implements OnInit {

    errors: string;
    isRequesting: boolean;
    submitted: boolean = false;
    constructor(private userService: UserServiceService, private router: Router) { }

    ngOnInit() {
    }
    registerUser({ value, valid }: { value: UserRegistration, valid: boolean }) {
        this.submitted = true;
        this.isRequesting = true;
        this.errors = '';
        if (valid) {
            this.userService.register(value.email, value.password, value.firstName, value.lastName, value.location, value.company, value.role)
                .finally(() => this.isRequesting = false)
                .subscribe(
                result => {
                    if (result) {
                        this.router.navigate(['/login'], { queryParams: { brandNew: true, email: value.email } });
                    }
                },
                errors => this.errors = errors);
        }

    }
}
