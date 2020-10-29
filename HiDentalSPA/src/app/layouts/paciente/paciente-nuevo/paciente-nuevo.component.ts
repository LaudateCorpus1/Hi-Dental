import { Component, OnInit, Input, Output } from '@angular/core';
import { NzModalRef, ModalButtonOptions } from 'ng-zorro-antd/modal';
import { FormBuilder, FormControl, Validators, FormGroup } from '@angular/forms';
import { NzModalService, UploadFile } from 'ng-zorro-antd';
import { BaseService } from 'src/app/shared/services/HTTPClient/base.service';
import { Paciente } from 'src/app/shared/Models/Paciente/paciente';

@Component({
  selector: 'app-paciente-nuevo',
  templateUrl: './paciente-nuevo.component.html',
  styleUrls: ['./paciente-nuevo.component.css']
})
export class PacienteNuevoComponent implements OnInit {

  @Input() title?: string;
  @Input() subtitle?: string;
  @Output() modalActual: NzModalRef;

  isLoading: boolean = false;
  tabIndice: number = 0;
  nombrecompleto: string = 'Nuevo Paciente';
  edad: string = '.. ';

  datosPesonalesGrupo!: FormGroup;

  constructor(private modal: NzModalRef, private fb: FormBuilder, public base: BaseService) {

    this.isLoading = false;
    this.modalActual = modal;

    this.datosPesonalesGrupo = this.fb.group({
      nombre: [null, [Validators.required]],
      apellido: [null, [Validators.required]],
      genero: ['0'],
      fechanacimiento: [null, [Validators.required]],
      cedula: [null],
      direccion: [null, [Validators.required]],
      direccionoficina: [null],
      email: [null, [Validators.email]],   
      ocupacion: [null],
      referidopor: [null],
      telefono1_Prefix: ['+1'],
      telefono1: [null, [Validators.required]],
      telefono2_Prefix: ['+1'],
      telefono2: [null],
      nota: [null],
    });
  }

  ngOnInit(): void { }

  tabCambioEvento(indice: number): void { this.tabIndice = indice; }

  enviarFormulario(): void {
    for (const i in this.datosPesonalesGrupo.controls) {
      this.datosPesonalesGrupo.controls[i].markAsDirty();
      this.datosPesonalesGrupo.controls[i].updateValueAndValidity();
    }

    if (!this.datosPesonalesGrupo.invalid) // si los datos personales son validos
    {
      this.isLoading = true;

      let pacienteNuevo = new Paciente();
      pacienteNuevo.names = this.datosPersonales.nombre.value;
      pacienteNuevo.lastNames = this.datosPersonales.apellido.value;
      pacienteNuevo.identificationCard = this.datosPersonales.cedula.value;
      pacienteNuevo.address = this.datosPersonales.direccion.value;
      pacienteNuevo.addressOffice = this.datosPersonales.direccionoficina.value;
      pacienteNuevo.photo = 'default url';                                                    //definir
      pacienteNuevo.gender = Number.parseInt(this.datosPersonales.genero.value + '', 10);
      pacienteNuevo.email = this.datosPersonales.email.value;
      pacienteNuevo.occupation = this.datosPersonales.ocupacion.value;
      pacienteNuevo.referredBy = this.datosPersonales.referidopor.value;
      pacienteNuevo.phoneNumber = this.datosPersonales.telefono1_Prefix.value + ' ' + this.datosPersonales.telefono1.value;
      pacienteNuevo.workPhoneNumber = this.datosPersonales.telefono2_Prefix.value + ' ' + this.datosPersonales.telefono2.value;
      pacienteNuevo.birthDate = this.datosPersonales.fechanacimiento.value;
      pacienteNuevo.medicalAlert = false;                                                     //definir
      pacienteNuevo.dentalBranchId = '10BC7128-FD62-4412-0DE6-08D86BFB3810';
      pacienteNuevo.note = this.datosPersonales.nota.value;

      console.log(pacienteNuevo);

      //this.guardar(pacienteNuevo);
    }
  }


  guardar(paciente: Paciente) {

  }



  cancelar(): void {
    this.modal.destroy();
  }























  get datosPersonales() { return this.datosPesonalesGrupo.controls; }

}
