import { Component, OnInit } from '@angular/core';
import { TableService } from 'src/app/shared/services/table.service';
import { BaseService, DataApi } from 'src/app/shared/services/HTTPClient/base.service';
import { Usuarios, UserFilterParams, UsuariosViewModel } from 'src/app/shared/Models/usuarios/usuarios';
import { NzNotificationService } from 'ng-zorro-antd';

@Component({
  selector: 'app-usuario-listado',
  templateUrl: './usuario-listado.component.html',
  styleUrls: ['./usuario-listado.component.css']
})
export class UsuarioListadoComponent implements OnInit {

  constructor(
    private tableSvc: TableService,
    public base: BaseService,
    private notification: NzNotificationService) {
  }
  search: any;
  displayData = [];
  usuarios: UsuariosViewModel[] = [];
  Cargando = true;
  ordersList = [
      {
          id: 5331,
          name: 'Erin Gonzales',
          Email: 'eringGonzales@gmail.com',
          avatar: 'assets/images/avatars/thumb-1.jpg',
          date: '8 May 2019',
          typeuser: 'Doctor',
          status: 'approved',
          checked : false
      },
      {
          id: 5375,
          name: 'Darryl Day',
          email: 'eringGonzales@gmail.com',
          avatar: 'assets/images/avatars/thumb-2.jpg',
          date: '6 May 2019',
          typeuser: 'Doctor',
          status: 'approved',
          checked : false
      },
      {
          id: 5762,
          name: 'Marshall Nichols',
          email: 'eringGonzales@gmail.com',
          avatar: 'assets/images/avatars/thumb-3.jpg',
          date: '1 May 2019',
          typeuser: 'Doctor',
          status: 'approved',
          checked : false
      },
      {
          id: 5865,
          name: 'Virgil Gonzales',
          email: 'eringGonzales@gmail.com',
          avatar: 'assets/images/avatars/thumb-4.jpg',
          date: '28 April 2019',
          typeuser: 'Doctor',
          status: 'pending',
          checked : false
      },
      {
          id: 5213,
          name: 'Nicole Wyne',
          email: 'eringGonzales@gmail.com',
          avatar: 'assets/images/avatars/thumb-5.jpg',
          date: '28 April 2019',
          typeuser: 'Doctor',
          status: 'approved',
          checked : false
      },
      {
          id: 5311,
          name: 'Riley Newman',
          email: 'eringGonzales@gmail.com',
          avatar: 'assets/images/avatars/thumb-6.jpg',
          date: '19 April 2019',
          typeuser: 'Doctor',
          status: 'rejected',
          checked : false
      },

      {
          id: 5390,
          name: 'Pamela Wanda',
          email: 'eringGonzales@gmail.com',
          avatar: 'assets/images/avatars/thumb-7.jpg',
          date: '16 April 2019',
          typeuser: 'Doctor',
          status: 'pending',
          checked : false
      },

      {
          id: 5291,
          name: 'Victor Terry',
          email: 'eringGonzales@gmail.com',
          avatar: 'assets/images/avatars/thumb-9.jpg',
          date: '10 April 2019',
          typeuser: 'Doctor',
          status: 'approved',
          checked : false
      },

  ];

  pageIndex = 1;
  pageSize = 7;
  total = 0;

  readonly params = new  UserFilterParams();



  ngOnInit(): void {
    this.refreshParameters();
    this.getUsuarios();
  }



  currentPageDataChange($event: Array<{ 
    id:number;
    names: string;
    lastNames:string;
    userName:string;
    createAt:string;
    state:number;
    createdBy:string;
    creationType:string;
    email:string;
    phoneNumber:string;
    emailConfirmed:boolean;
    userDetail:string;
    dentalBranchId:string;
    dentalBranch:string;
  }>): void {
      this.usuarios = $event;
    // this.refreshStatus();
  }
getUsuarios(reset: boolean = false){
  if (reset) {
    this.pageIndex = 1;
  }
this.refreshParameters();
this.base.getAll<UsuariosViewModel>(DataApi.Usuarios,'GetAll',this.params).subscribe(x => {
     this.usuarios = x.entities;
     this.total= x.total;
     this.Cargando=false;
     console.log(x)
}, error => {
  this.Cargando=false;
   console.log(error);
});
}
refreshParameters(){
  this.Cargando=true;
  this.params.id='';
  this.params.Page = this.pageIndex;
  this.params.QuantityByPage = this.pageSize;
  this.params.names=this.search == undefined ? '' : this.search;
  this.params.dentalBranchId='14bc4f39-e716-49ce-9fd3-08d82a82fbe0';
  // this.params.lastNames=this.search == undefined ? '' : this.search;
  // this.params.indentityDocument=this.search == undefined ? '' : this.search;
}
deleteUsuario(idusuario) {
  console.log(idusuario);
  this.Cargando = true;
  this.base.DoDelete(DataApi.Usuarios, 'Remove', { 'id': idusuario }).subscribe(x => {
    if (x) {
      this.notification.success('Usuario', 'usuario eliminado correctamente',{});
      this.getUsuarios();
    }
    this.Cargando = false;
  }, error => {
    console.log(error);
    this.notification.error('Usuario', 'Ha ocurrido un error!', {});
    this.Cargando = false;
  });

}



}
