import { Component, OnInit } from '@angular/core';
import { Validators, FormControl, FormBuilder, FormGroup, ValidationErrors } from '@angular/forms';
import { Observable, Observer } from 'rxjs';
import { BaseService, Combobox, DataApi } from 'src/app/shared/services/HTTPClient/base.service';
import { Router, ActivatedRoute } from '@angular/router';
import { UserAuth, UserDetail, UserViewModel } from 'src/app/shared/Models/usuarios/usuarios';

@Component({
  selector: 'usuario-formulario',
  templateUrl: './usuario-formulario.component.html',
  styleUrls: ['./usuario-formulario.component.css']
})
export class UsuarioFormularioComponent implements OnInit {

  formulario: FormGroup;
  UsuarioID: string;
  loadingButton = false;
  usuario:UserViewModel;

  //ComboBoxDentalBranches
  loadingDentalBranches: boolean;
  comboboxDentalBranches: Combobox[] = [];
  dentalBranchSeletedForm: Combobox = null;
 // dentalBranchSeletedFilter: Combobox = { code: '', grupoID: null, title: 'Todas las sucursales', Group: null };
 
  //ComboBoxUserTypes:
  loadingUserTypes: boolean;
  comboboxUserTypes: Combobox[] = [];
  UserTypeSeletedForm: Combobox = null;


  editLoading: boolean;

 

  constructor(private fb: FormBuilder,public base: BaseService,
    public route: ActivatedRoute, public  router: Router) {
  }

  ngOnInit(): void {
    this.CreateForm();
  
    this.UsuarioID = this.route.snapshot.paramMap.get('id');
    if (this.UsuarioID !==  null && this.UsuarioID !=='0' ) {
         this.GetToEdit();
      
    } 
    this.getComboBoxDentalBranchs();
    this.getComboBoxUserTypes();
}
//Pendiente por terminar
getComboBoxDentalBranchs() {
    this.loadingDentalBranches=true;
    this.base.getAll<Combobox>(DataApi.ComboBox, 'DentalBranchs', null).subscribe(x => {
      this.comboboxDentalBranches = x;
      this.loadingDentalBranches=false;
      //console.log(this.comboboxDentalBranches);
    }, error => {
      console.log(error);
      this.loadingDentalBranches=false;
    })

  }
  getComboBoxUserTypes() {
    this.loadingUserTypes=true;
    this.base.getAll<Combobox>(DataApi.ComboBox, 'UserTypes', null).subscribe(x => {
      this.comboboxUserTypes = x;
      this.loadingUserTypes=false;
      //console.log(this.comboboxDentalBranches);
    }, error => {
      console.log(error);
      this.loadingUserTypes=false;
    })

  }



GetToEdit(){
  this.editLoading=true;
  this.base.GetOne<UserViewModel>(DataApi.Usuarios, 'GetById', { 'id': this.UsuarioID }).subscribe(x => {
    this.usuario = x;
    console.log(this.usuario)
    this.formulario.setValue({
      formLayout: ['vertical'],
      id: this.usuario.id,
      userDetailId: this.usuario.userDetail.id,
      userName: this.usuario.userName,
      names: this.usuario.names,
      lastnames: this.usuario.lastNames,
      password: 'sdsdasdasdhbewqbkjq',
      checkPassword: 'sdsdasdasdhbewqbkjq',
      phoneNumber:this.usuario.phoneNumber,
      gender:this.usuario.userDetail.gender,
      identityDocument: this.usuario.userDetail.identityDocument,
      description:this.usuario.userDetail.description,
      userTypeId:this.usuario.userDetail.userTypeId,
      dentalBranchId:this.usuario.dentalBranchId
    });
    this.editLoading = false;
  }, error => {
    console.log(error);
    this.editLoading = false;
  })
 }


CreateForm() {
    this.formulario = this.fb.group({
        formLayout: [ 'vertical' ],
        id    : [ null ],
        userDetailId: [ null ],
        // esto es email
        userName    : [ null, [ Validators.required ] ],
        names    : [ null, [ Validators.required ] ],
        lastnames    : [ null, [ Validators.required ]],
        password    : [ null, [ Validators.required ]],
        checkPassword    : [ null, [ Validators.required ]],

        phoneNumber    : [ null, [ Validators.required ]],

        gender    : [ null, [ Validators.required ]],
        identityDocument    : [ null, [ Validators.required ]],
        description    : [ null],
        userTypeId: [ null, [ Validators.required ]],
        dentalBranchId: [ null, [ Validators.required ]],


    });
}

get f(){return this.formulario.controls;}
beforeOnsubmitForm(): void {
  // tslint:disable-next-line: forin
  for (const i in this.formulario.controls) {
      this.formulario.controls[ i ].markAsDirty();
      this.formulario.controls[ i ].updateValueAndValidity();
  }

  if (this.formulario.invalid) {
    return;
  } else {
     this.onSubmitUserAuth();
  }
}

get isHorizontal(): boolean {
  return this.formulario.controls.formLayout && this.formulario.controls.formLayout.value === 'horizontal';
}

onSubmitUserAuth(){
    const userAuth = new UserAuth();
    userAuth.id = this.f.id.value;
    userAuth.userName = this.f.userName.value;
    userAuth.password = this.f.password.value;
    userAuth.lastNames = this.f.lastnames.value;
    userAuth.names = this.f.names.value;
    userAuth.phoneNumber = this.f.phoneNumber.value;
    userAuth.dentalBranchId = this.f.dentalBranchId.value;
    console.log(userAuth);
    this.createOrUpdateUserAuth(userAuth);
}
createOrUpdateUserAuth(userAuth: UserAuth) {
  this.loadingButton=true;
 if (userAuth.id !== null) {
    this.updateUserAuth(userAuth);
  }else{
    this.createUserAuth(userAuth);
  }
}
createUserAuth(userAuth: UserAuth){

  this.base.DoPost<any>(DataApi.Auth, 'create',
  {
    'userName': userAuth.userName,
    'password': userAuth.password,
    'names': userAuth.names,
    'lastNames': userAuth.lastNames,
    'phoneNumber': userAuth.phoneNumber,
     'dentalBranchId': userAuth.dentalBranchId
  }
).subscribe(x => {
  if (x) {
    this.f['id'].setValue(x.user.id);
     this.onSubmitUserDetail();

  }

}, error => {
  this.loadingButton = false;
  console.log(error);
});
}
updateUserAuth(userAuth: UserAuth){

  this.base.DoPut<any>(DataApi.Usuarios, 'update',
  {
    'id':userAuth.id,
    'userName': userAuth.userName,
    'names': userAuth.names,
    'lastNames': userAuth.lastNames,
    'phoneNumber': userAuth.phoneNumber,
     'dentalBranchId': userAuth.dentalBranchId
  }
).subscribe(x => {
  this.loadingButton = false;
  if (x) {
     this.onSubmitUserDetail();
  }

}, error => {
  this.loadingButton = false;
  console.log(error);
});
}





onSubmitUserDetail(){
  const userDetail = new UserDetail();
  userDetail.id = this.f.userDetailId.value;
  userDetail.identityDocument = this.f.identityDocument.value;
  userDetail.gender = this.f.gender.value;
  userDetail.userId = this.f.id.value;
  userDetail.userTypeId = this.UserTypeSeletedForm.code;
  this.updateUserDetail(userDetail);
}
// createOrUpdateUserDetail(userDetail: UserDetail){
//   if (userDetail.id !== null) {
//     this.updateUserDetail(userDetail);
//   }else{
//     this.createUserDetail(userDetail);
//   }
// }
createUserDetail(userDetail: UserDetail){

  this.base.DoPost<UserAuth>(DataApi.Usuarios, 'AddDetail',
  {
    'description': userDetail.description,
    'identityDocument': userDetail.identityDocument,
    'gender': userDetail.gender,
    'userTypeId': userDetail.userTypeId,
    'userId': userDetail.userId
  }
).subscribe(x => {
  this.loadingButton = false;
  if (x) {
     console.log(x);
  }

}, error => {
  this.loadingButton = false;
  console.log(error);
});
}

updateUserDetail(userDetail: UserDetail){
 console.log(userDetail);
  this.base.DoPut(DataApi.Usuarios, 'UpdateDetail',
  {
    'description': userDetail.description,
    'identityDocument': userDetail.identityDocument,
    'gender': userDetail.gender,
    'userTypeId': userDetail.userTypeId,
    'userId': userDetail.userId
  }).subscribe(x => {
    this.loadingButton = false;
    if (x) {
      console.log(x);
      this.router.navigateByUrl('/usuarios');
    }

  }, error => {
    this.loadingButton = false;

    console.log(error);
  })

}
}
