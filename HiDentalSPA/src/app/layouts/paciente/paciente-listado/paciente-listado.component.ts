import { Component, OnInit, TemplateRef } from '@angular/core';
import { TableService } from 'src/app/shared/services/table.service';
import { BaseService } from 'src/app/shared/services/HTTPClient/base.service';
import { NzNotificationService } from 'ng-zorro-antd';

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

  constructor(private tableSvc: TableService, public base: BaseService) { }

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

}
