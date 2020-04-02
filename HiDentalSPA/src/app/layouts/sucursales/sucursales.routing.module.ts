import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { SucursalesComponent } from './sucursales.component';
import { SucursalListadoComponent } from './sucursal-listado/sucursal-listado.component';
import { SucursalFormularioComponent } from './sucursal-formulario/sucursal-formulario.component';


const routes: Routes = [
  {  path: '', component: SucursalesComponent,
     children: [
       {path: '', component: SucursalListadoComponent},
       {path: 'sucursal/:id', component: SucursalFormularioComponent},
     ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class SucursalesRoutingModule { }
