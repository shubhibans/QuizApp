import { Component, OnInit } from '@angular/core';
import { UserServiceService } from '../../Services/user-service.service';
import { Router } from '@angular/router';
import { Credentials } from '../../Models/credentials.interface';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent implements OnInit {

    errors: string;
    isRequesting: boolean;
    submitted: boolean = false;
    constructor(private userService: UserServiceService, private router: Router) { }

  ngOnInit() {
  }
  login({value, valid }:{value: Credentials, valid:boolean })
{
      this.submitted = true;
      this.isRequesting = true;
      this.errors = '';
      if (valid) {
          this.userService.login(value.email, value.password)
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
