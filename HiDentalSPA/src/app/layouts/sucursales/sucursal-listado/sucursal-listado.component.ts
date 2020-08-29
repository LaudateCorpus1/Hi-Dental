import { Component, OnInit } from '@angular/core';
import { SucursalesViewModel, SucursalFilterParams, Sucursal } from 'src/app/shared/Models/Sucursales/sucursales';
import { DataApi, BaseService, PaginacionRequest, Combobox } from 'src/app/shared/services/HTTPClient/base.service';
import { TableService } from 'src/app/shared/services/table.service';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { error } from 'protractor';
import { Oficina } from 'src/app/shared/Models/Oficinas/oficinas';
import { NzNotificationService } from 'ng-zorro-antd';

@Component({
  selector: 'app-sucursal-listado',
  templateUrl: './sucursal-listado.component.html',
  styleUrls: ['./sucursal-listado.component.css']
})
export class SucursalListadoComponent implements OnInit {

  constructor(
    private tableSvc: TableService,
    public base: BaseService,
    private fb: FormBuilder,
    private notification: NzNotificationService
    ) {
  }
  comboboxOficinas: Combobox[] = [];
  textTitleModal = 'Nueva sucursal';

  isHorizontal = false;


  oficinaSeletedForm: Combobox;
  oficinaSeletedFilter: Combobox = { code: '', grupoID: null, title: 'Todas las oficinas', Group: null };

  pageIndex = 1;
  pageSize = 7;
  total = 0;

  search: any;
  displayData = [];
  sucursales: SucursalesViewModel[] = [];
  Cargando = true;

  validateForm: FormGroup;
  isVisible = false;
  isOkLoading = false;

  loadingButton: boolean;
  editLoading: boolean;
  loadingDentalBranches: boolean;
  idSucursal: string;


  sucursal: SucursalesViewModel;
  isPrincipalChecked = false;
  params = new SucursalFilterParams();

  ngOnInit(): void {

    this.CreateForm();
    this.getComboBoxOficinas();
    this.refreshParameters();
    this.getSucursales();
  }



  currentPageDataChange($event: Array<{
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

  saveSucursal(sucursal: Sucursal) {
    this.base.DoPost<Sucursal>(DataApi.Sucursales, 'create',
      {
        'description': sucursal.description,
        'address': sucursal.address,
        'title': sucursal.title,
        'phoneNumber': sucursal.phoneNumber,
        'PrincipalOfficeId': sucursal.principalOfficeId,
        'isPrincipal': sucursal.isPrincipal
      }
    ).subscribe(x => {
      this.loadingButton = false;
      if (x) {
        this.notification.success('Sucursal', 'Se ha guardado correctamente', {});
        this.handleCancel();
        this.getSucursales();
      }

    }, error => {
      this.loadingButton = false;
      this.notification.error('Sucursal', 'Ha ocurrido un error!', {});
      console.log(error);
    });
  }
  updateSucursal(sucursal: Sucursal) {
    //this.idSucursal=null;

    this.base.DoPut(DataApi.Sucursales, 'Update',
      {
        'id': this.idSucursal,
        'description': sucursal.description,
        'address': sucursal.address,
        'title': sucursal.title,
        'phoneNumber': sucursal.phoneNumber,
        'PrincipalOfficeId': sucursal.principalOfficeId,
        'isPrincipal': sucursal.isPrincipal
      }).subscribe(x => {
        this.loadingButton = false;
        if (x) {
          this.handleCancel();
          this.notification.success('Sucursal', 'Se ha actualizado correctamente', {});
          this.getSucursales();
        }

      }, error => {
        this.loadingButton = false;
        this.notification.error('Sucursal', 'Ha ocurrido un error!', {});
        console.log(error);
      })
  }
  getSucursales(reset: boolean = false) {
    if (reset) {
      this.pageIndex = 1;
    }
    this.refreshParameters();
    this.base.getAll<SucursalesViewModel>(DataApi.Sucursales, 'GetAll', this.params).subscribe(x => {
      this.sucursales = x.entities;
      this.total = x.total;
      this.Cargando = false;
      console.log(x)
    }, error => {
      this.Cargando = false;
      console.log(error);
    });
  }

  deleteSucursal(idsucursal) {
    console.log(idsucursal);
    this.base.DoDelete(DataApi.Sucursales, 'Remove', { 'id': idsucursal }).subscribe(x => {
      if (x) {
        this.notification.success('Sucursal', 'Se ha eliminado correctamente', {});
        this.getSucursales();
      }
    }, error => {
      this.notification.error('Sucursal', 'Ha ocurrido un error!', {});
    });

  }
  getComboBoxOficinas() {
    this.loadingDentalBranches=true;
    this.base.getAll<Combobox>(DataApi.ComboBox, 'DentalBranchs', null).subscribe(x => {
      this.comboboxOficinas = x;
      this.comboboxOficinas.unshift(this.oficinaSeletedFilter);
      this.loadingDentalBranches=false;
      console.log(this.comboboxOficinas);
    }, error => {
      console.log(error);
      this.loadingDentalBranches=false;
    })

  }

  CreateForm() {
    this.validateForm = this.fb.group({
      formLayout: ['vertical'],
      title: [null, [Validators.required]],
      address: [null, [Validators.required]],
      description: [null, [Validators.required]],
      phoneNumber: [null, [Validators.required]],
      isPrincipal: [false, [Validators.required]],
      office: [null, [Validators.required]],
    });
  }
  submitForm(): void {

    // tslint:disable-next-line: forin
    for (const i in this.validateForm.controls) {
      this.validateForm.controls[i].markAsDirty();
      this.validateForm.controls[i].updateValueAndValidity();
    }
    if (this.validateForm.valid) {
      this.loadingButton = true;

      let sucursal = new Sucursal();
      sucursal.title = this.f.title.value;
      sucursal.phoneNumber = this.f.phoneNumber.value;
      sucursal.address = this.f.address.value;
      sucursal.description = this.f.description.value;
      sucursal.principalOfficeId = this.f.office.value;
      sucursal.isPrincipal = this.isPrincipalChecked;

      console.log(sucursal);
      console.log(this.idSucursal);
      if (this.idSucursal != null) {
        this.updateSucursal(sucursal);
      } else {
        this.saveSucursal(sucursal);
      }

    }
  }
  showModal(id): void {
    this.isVisible = true;
    this.textTitleModal = 'Nueva sucursal';
    if (id != null) {
      this.textTitleModal = 'Editando sucursal';
      this.editLoading = true;
      this.idSucursal = id;
      this.base.GetOne<SucursalesViewModel>(DataApi.Sucursales, 'GetById', { 'id': id }).subscribe(x => {
        this.sucursal = x;
        this.validateForm.setValue({
          formLayout: ['vertical'],
          title: this.sucursal.title,
          address: this.sucursal.address,
          description: this.sucursal.description,
          phoneNumber: this.sucursal.phoneNumber,
          isPrincipal: this.sucursal.isPrincipal,
          office: this.sucursal.principalOfficeId
        });
        this.editLoading = false;

      }, error => {
        console.log(error);
        this.editLoading = false;
      })
    }
  }

  handleOk(): void {

  }

  handleCancel(): void {
    this.isVisible = false;
    this.clearForm();
  }
  clearForm(): void {
    this.validateForm.setValue({
      formLayout: ['vertical'],
      title: null,
      address: null,
      description: null,
      phoneNumber: null,
      office: null,
      isPrincipal: false
    });
  }
  get f() { return this.validateForm.controls; }
  refreshParameters() {
    this.Cargando = true;
    this.params.principalOfficeId = this.oficinaSeletedFilter.code;
    this.params.Page = this.pageIndex;
    this.params.QuantityByPage = this.pageSize;
    // this.params.lastNames=this.search == undefined ? '' : this.search;
    // this.params.indentityDocument=this.search == undefined ? '' : this.search;
  }


}
