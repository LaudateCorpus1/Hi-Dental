import { Component, OnInit } from '@angular/core';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BaseService } from '../shared/services/HTTPClient/base.service';
import { first } from 'rxjs/operators';
import { AuthenticationService } from '../shared/services/authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers: [AuthenticationService]
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  loading = false;
  submitted = false;
  returnUrl: string; 
  error = '';
  submitForm(): void {
      // tslint:disable-next-line: forin
      for (const i in this.loginForm.controls) {
          this.loginForm.controls[ i ].markAsDirty();
          this.loginForm.controls[ i ].updateValueAndValidity();
      }
  // stop here if form is invalid
      if (this.loginForm.invalid) {
    return;
  }
      this.loginSubmit();
  }

  constructor(private fb: FormBuilder,
              public route: ActivatedRoute,
              public router: Router,
              public service: BaseService,
              public authenticationService: AuthenticationService
    ) {
  }

  ngOnInit(): void {
      this.loginForm = this.fb.group({
          userName: [ null, [ Validators.required ] ],
          password: [ null, [ Validators.required ] ]
      });
  }
  get f() { return this.loginForm.controls; }
  loginSubmit() {
    this.submitted = true;
    this.loading = true;
    //let res = this.authenticationService.login(this.f.username.value, this.f.password.value)
    this.authenticationService.login(this.f.userName.value, this.f.password.value)
      .pipe(first())
      .subscribe(
        data => {
          if (data && data.token) {
            this.loading = false;
            this.router.navigateByUrl('/dashboard/home');
          } else {

            this.loading = false;
            this.loginForm.reset();
           // tslint:disable-next-line: max-line-length
           // this.library.showToast(data.errores[0].toString(), { classname: 'bg-danger text-light', icon: "fas fa-exclamation-triangle" });
            this.router.navigateByUrl('/login');
          }
        },
        error => {
        // tslint:disable-next-line: max-line-length
        //  this.library.showToast("Error interno! Mensaje: " + error, { classname: 'bg-danger text-light', icon: "fas fa-exclamation-triangle" });
          this.error = error;
          this.loading = false;
          console.log(error);
        });
  }
}
