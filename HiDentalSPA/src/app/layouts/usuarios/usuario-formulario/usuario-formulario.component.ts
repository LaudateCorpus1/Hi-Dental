import { Component, OnInit } from '@angular/core';
import { Validators, FormControl, FormBuilder, FormGroup, ValidationErrors } from '@angular/forms';
import { Observable, Observer } from 'rxjs';
import { BaseService } from 'src/app/shared/services/HTTPClient/base.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'usuario-formulario',
  templateUrl: './usuario-formulario.component.html',
  styleUrls: ['./usuario-formulario.component.css']
})
export class UsuarioFormularioComponent implements OnInit {

  validateForm: FormGroup;
  UsuarioID: string;
  LoadingButton = false;

  submitForm(): void {
      // tslint:disable-next-line: forin
      for (const i in this.validateForm.controls) {
          this.validateForm.controls[ i ].markAsDirty();
          this.validateForm.controls[ i ].updateValueAndValidity();
      }
  }

  get isHorizontal(): boolean {
      return this.validateForm.controls.formLayout && this.validateForm.controls.formLayout.value === 'horizontal';
  }

  constructor(private fb: FormBuilder,public base: BaseService,
    public route: ActivatedRoute, public  router: Router) {
  }

  ngOnInit(): void {
      this.CreateForm();
    this.UsuarioID = this.route.snapshot.paramMap.get('id');
    if (this.UsuarioID !==  null || '' ) {
        // this.GetToEdit();
        // this.GetTiposUsuarios();
    } else {
        this.router.navigateByUrl('/usuarios');
    }
}
CreateForm() {
    this.validateForm = this.fb.group({
        formLayout: [ 'vertical' ],
        names    : [ null, [ Validators.required ] ],
        lastnames    : [ null, [ Validators.required ]],
        email    : [ null, [ Validators.required ] ],
        password    : [ null, [ Validators.required ]],
        checkPassword    : [ null, [ Validators.required ]],
        identificationCard    : [ null, [ Validators.required ]],
        gender    : [ null, [ Validators.required ]],
        phoneNumber    : [ null, [ Validators.required ]],
        phoneNumberPrefix    : [ null, [ Validators.required ]],
        typeUser: [ null, [ Validators.required ]]


    });
    this.validateForm.controls.phoneNumberPrefix.setValue('+809');
}
}
