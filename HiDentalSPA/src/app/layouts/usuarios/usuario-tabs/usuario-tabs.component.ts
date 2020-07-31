import { Component, OnInit, ViewChild } from '@angular/core';
import { UsuarioFormularioComponent } from '../usuario-formulario/usuario-formulario.component';
import { PermisosTreeViewComponent } from '../permisos-tree-view/permisos-tree-view.component';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-usuario-tabs',
  templateUrl: './usuario-tabs.component.html',
  styleUrls: ['./usuario-tabs.component.css']
})
export class UsuarioTabsComponent implements OnInit {
  @ViewChild('tree', { static: false }) child: PermisosTreeViewComponent;
  @ViewChild('form', { static: false }) form: UsuarioFormularioComponent;
  UsuarioID: string;
  textAccion = 'Nuevo usuario';
  constructor(public  router: Router, public route: ActivatedRoute,) { }

  ngOnInit() {
   this.UsuarioID = this.route.snapshot.paramMap.get('id');
    if (this.UsuarioID !==  null || this.UsuarioID !== '0' ) {
       this.textAccion = 'Editando usuario';
    } 
  }
  MostrarMensajeDeErrorConexionServidor() {
    // tslint:disable-next-line: max-line-length
    // this.library.showToast("Error al conectar con el servidor", { classname: 'bg-danger text-light', icon: "fas fa-exclamation-triangle" });
}

 MostrarMensajeDeErrorInterno(error: string) {
  //  this.library.showToast("Error interno: " + error, { classname: 'bg-danger text-light', icon: "fas fa-exclamation-triangle" });
}

 MostrarMensajeOperacionRealizada(mensaje: string = "Operación realizada.") {
   // this.library.showToast(mensaje, { classname: 'bg-success text-white ', icon: "fas fa-check-square" });
}
}
