import { Component, OnInit } from '@angular/core';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;

  submitForm(): void {
      // tslint:disable-next-line: forin
      for (const i in this.loginForm.controls) {
          this.loginForm.controls[ i ].markAsDirty();
          this.loginForm.controls[ i ].updateValueAndValidity();
      }
  }

  constructor(private fb: FormBuilder) {
  }

  ngOnInit(): void {
      this.loginForm = this.fb.group({
          userName: [ null, [ Validators.required ] ],
          password: [ null, [ Validators.required ] ]
      });
  }
}
