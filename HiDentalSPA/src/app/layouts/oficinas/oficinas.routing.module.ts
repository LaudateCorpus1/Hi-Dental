import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';

import { OficinaListadoComponent } from './oficina-listado/oficina-listado.component';
import { OficinaFormularioComponent } from './oficina-formulario/oficina-formulario.component';
import { OficinasComponent } from './oficinas.component';

const routes: Routes = [
  {  path: '', component: OficinasComponent,
     children: [
       {path: '', component: OficinaListadoComponent},
       {path: 'oficina/:id', component: OficinaFormularioComponent},
     ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class OficinasRoutingModule { }
