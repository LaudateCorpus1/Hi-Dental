import { Component, OnInit } from '@angular/core';
import { TableService } from 'src/app/shared/services/table.service';
import { BaseService, DataApi, Paginacion, PaginacionRequest } from 'src/app/shared/services/HTTPClient/base.service';
import { OficinasViewModel, OficinaFilterParams, Oficina } from 'src/app/shared/Models/Oficinas/oficinas';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { error } from 'protractor';
import { Usuarios } from 'src/app/shared/Models/usuarios/usuarios';
import { SucursalesViewModel, SucursalFilterParams } from 'src/app/shared/Models/Sucursales/sucursales';

@Component({
  selector: 'app-oficina-listado',
  templateUrl: './oficina-listado.component.html',
  styleUrls: ['./oficina-listado.component.css']
})
export class OficinaListadoComponent implements OnInit {
  
  idOficina:string;
   paginacion= new  PaginacionRequest;
   
   pageIndex = 1;
   pageSize = 7;
   total = 0;
   
  constructor(private tableSvc : TableService,public base:BaseService,private fb: FormBuilder,) {
  }
  
  textTitleModal= 'Nueva oficina';

  validateForm: FormGroup;

  isVisibleModalForm = false;
  isOkLoading = false;
  loadingButton: boolean;
  editLoading:boolean;

  isVisibleModal_ViewDentalBranches:boolean;
  listDentalBLoading:boolean;
  
  search : any;
  displayData = [];
  oficinas: OficinasViewModel[]= [];
  oficina: OficinasViewModel;
  Cargando = true;
 


//List sucursales by 
  pageIndexDB = 1;
  pageSizeDB = 7;
  totalDB = 0;

  displayDataDB = [];
  sucursales: SucursalesViewModel[] = [];
  CargandoDB = true;
  paramsDB = new SucursalFilterParams();
  OfficeId='';


params = new OficinaFilterParams();
  ngOnInit(): void {
  
    this.CreateForm();
    this.getOficinas();
  }


  submitForm(): void {
    
    // tslint:disable-next-line: forin
    for (const i in this.validateForm.controls) {
        this.validateForm.controls[ i ].markAsDirty();
        this.validateForm.controls[ i ].updateValueAndValidity();
    }
    if(this.validateForm.valid){
      this.loadingButton = true;

      let oficina = new Oficina();
      oficina.title = this.f.title.value;
      oficina.phoneNumber = this.f.phoneNumber.value;
      oficina.address = this.f.address.value;
      oficina.description = this.f.description.value;
      if(this.idOficina!=null){
        this.updateOficina(oficina)
      }else{
        this.saveOficina(oficina);
      }
 
    }
}


 saveOficina(oficina:Oficina){
  this.base.DoPost<Oficina>(DataApi.Sucursales,'create',
  {
     'description': oficina.description,
    'address': oficina.address,
    'title': oficina.title,
    'phoneNumber': oficina.phoneNumber,
    'isPrincipal':oficina.isPrincipal
    
  }
    ).subscribe(x=>{
      this.loadingButton = false;
        if(x){
           this.handleCancel();
           this.getOficinas();
        }

  }, error => {
    this.loadingButton = false;

    console.log(error);
  });
 }
 updateOficina(oficina:Oficina){
   this.base.DoPut(DataApi.Sucursales,'Update', 
    {
      'id':this.idOficina,
    'description': oficina.description,
   'address': oficina.address,
   'title': oficina.title,
   'phoneNumber': oficina.phoneNumber
 }).subscribe(x=>{
   this.idOficina=null;
   this.loadingButton = false;
   if(x){
      this.handleCancel();
      this.getOficinas();
   }

 },error=>{
  this.loadingButton = false;

   console.log(error);
 })
 }
  getOficinas(reset:boolean=false){
      if(reset){
        this.pageIndex=1;
       }
    this.refreshParameters();
    this.base.getAll<OficinasViewModel>(DataApi.Sucursales,'GetAll',this.params).subscribe(x => {
       this.total=x.total;
        this.oficinas = x.entities;
        this.Cargando=false;
        console.log(x)
    }, error => {
      this.Cargando=false;
      console.log(error);
    });
    }
  deleteOficina(idoficina){
    console.log(idoficina);
      this.base.DoDelete(DataApi.Sucursales,'Remove',{'id':idoficina}).subscribe(x=>{
        if(x){
          this.getOficinas();
        }
      },error=>{
        console.log(error);
      });

    }

  get f() { return this.validateForm.controls; }

  currentPageDataChange($event: Array<{ 
    id:number;
    title: string;
    address:string;
    phoneNumber:string;
    description:string;
    createAt:string;
    updateAt:string;
    state:number;
  }>): void {
      this.oficinas = $event;
    // this.refreshStatus();
  }
  currentPageDataChangeDB($event: Array<{
    id: number;
    title: string;
    address: string;
    phoneNumber: string;
    description: string;
    isPrincipal: boolean;
    officeName: string;
    createAt: string;
    updateAt: string;
    state: number;
    principalOfficeId: string;
  }>): void {
    this.sucursales = $event;
    // this.refreshStatus();
  }
refreshParameters(){
  this.Cargando=true;
  // this.params.lastNames=this.search == undefined ? '' : this.search;
  // this.params.indentityDocument=this.search == undefined ? '' : this.search;
  this.params.Page = this.pageIndex;
  this.params.QuantityByPage = this.pageSize;
  this.params.isPrincipal = true;
  // this.params.lastNames=this.search == undefined ? '' : th
}
refreshParametersDB(){
  this.Cargando=true;
  // this.params.lastNames=this.search == undefined ? '' : this.search;
  // this.params.indentityDocument=this.search == undefined ? '' : this.search;
  this.paramsDB.Page = this.pageIndexDB;
  this.paramsDB.QuantityByPage = this.pageSizeDB;
  this.paramsDB.principalOfficeId = this.OfficeId;
  // this.params.lastNames=this.search == undefined ? '' : th
}



CreateForm() {
  this.validateForm = this.fb.group({
      formLayout: [ 'vertical' ],
      title    : [ null, [ Validators.required ] ],
      address    : [ null, [ Validators.required ]],
      description    : [ null, [ Validators.required ] ],
      phoneNumber    : [ null, [ Validators.required ]],


  });
}
showModal(id): void {
  this.isVisibleModalForm = true;
  this.textTitleModal = 'Nueva oficina';

  if(id!=null){
    this.textTitleModal = 'Editando oficina';
    this.editLoading=true;

    this.idOficina=id;
      this.base.GetOne<Oficina>(DataApi.Sucursales,'GetById',{'id':id}).subscribe(x=>{
        this.oficina=x;
        this.validateForm.setValue({
          formLayout: [ 'vertical' ],
          title:this.oficina.title,
          address:this.oficina.address,
          description:this.oficina.description,
          phoneNumber:this.oficina.phoneNumber
        });
        this.editLoading=false;

      },error=>{
        console.log(error);
        this.editLoading=false;
      })
  }
}



handleOk(): void {
 
}

handleCancel(): void {
  this.isVisibleModalForm = false;
  this.clearForm();
}

showModal_ListDentalB(id): void
{
  this.isVisibleModal_ViewDentalBranches=true;
  this.getSucursales(false,id);
}

getSucursales(reset: boolean = false,id:string=null) {
  if (reset) {
    this.pageIndexDB = 1;
  }
  if(id!==null){
    this.OfficeId =id;
  }
  this.refreshParametersDB();
  this.base.getAll<SucursalesViewModel>(DataApi.Sucursales, 'GetAll', this.paramsDB).subscribe(x => {
    this.sucursales = x.entities;
    this.totalDB = x.total;
    this.CargandoDB = false;
    console.log(x);
  }, error => {
    this.CargandoDB = false;
    console.log(error);
  });
}


handleCancel_ListDentalB(): void {
  this.isVisibleModal_ViewDentalBranches = false;
  this.Cargando=false;
}
 clearForm(): void{
  this.validateForm.setValue({
    formLayout: [ 'vertical' ],
    title:'',
    address:'',
    description:'',
    phoneNumber:''
  });
 }

}
