import { Component, OnInit, TemplateRef,ViewContainerRef } from '@angular/core';
import { TableService } from 'src/app/shared/services/table.service';
import { BaseService } from 'src/app/shared/services/HTTPClient/base.service';
import { NzNotificationService } from 'ng-zorro-antd';
import { NzModalRef, NzModalService, ModalButtonOptions } from 'ng-zorro-antd/modal';
import { PacienteNuevoComponent } from '../paciente-nuevo/paciente-nuevo.component';

@Component({
  selector: 'app-paciente-listado',
  templateUrl: './paciente-listado.component.html',
  styleUrls: ['./paciente-listado.component.css']
})
export class PacienteListadoComponent implements OnInit {
 

  search: any;
  displayData = [];
  pacientes: any[] = [];
  Cargando = true;


  pageIndex = 1;
  pageSize = 7;
  total = 0;

  isHorizontal = false;
  //readonly params= new  UserFilterParams();

  constructor(private tableSvc: TableService, public base: BaseService, private modal: NzModalService, private viewContainerRef: ViewContainerRef) { }

  ngOnInit() {
  }
  currentPageDataChange($event: Array<{
    id: number;
    names: string;
    lastNames: string;
    userName: string;
    createAt: string;
    state: number;
    createdBy: string;
    creationType: string;
    email: string;
    phoneNumber: string;
    emailConfirmed: boolean;
    userDetail: string;
    dentalBranchId: string;
    dentalBranch: string;
  }>): void {
      this.pacientes = $event;
    // this.refreshStatus();
  }
  getPacientes() {
    console.log('listado de pacientes');
  }


  crearNuevoPaciente(): void {
    const modal = this.modal.create({

      nzWidth: 1450,
      nzContent: PacienteNuevoComponent,
      nzViewContainerRef: this.viewContainerRef,
      // nzGetContainer: () => document.body,
      nzComponentParams: {
        title: 'Nuevo Paciente' 
      }, 

      nzFooter: null
      // nzFooter: [
      //   {
      //     label: 'Cancelar',
      //     type: 'default',
      //     onClick: modalComponent => {
      //       modalComponent.handleCancel(); 
      //     }
      //   },
      //   {
      //     label: 'Guardar',
      //     type: 'primary',
      //     loading :false,
      //     onClick(modalComponent)         
      //     {               
      //         let buttonRef: ModalButtonOptions<PacienteNuevoComponent> = this; 
      //         modalComponent.handleSave1(buttonRef);                 
      //     }          
      //   }        
      // ]
    }); 
 
  }//fin de CrearNuevoPaciente( )  

}
