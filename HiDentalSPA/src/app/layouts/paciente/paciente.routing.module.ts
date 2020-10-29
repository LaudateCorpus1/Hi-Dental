import { Routes, RouterModule } from '@angular/router';
import { PacienteComponent } from './paciente.component';
import { PacienteListadoComponent } from './paciente-listado/paciente-listado.component';
import { PacienteNuevoComponent } from './paciente-nuevo/paciente-nuevo.component';
import { PacienteTabsComponent } from './paciente-tabs/paciente-tabs.component';
import { NgModule } from '@angular/core';

const routes: Routes = [
  {  path: '', component: PacienteComponent,
     children: [
       {path: '', component: PacienteListadoComponent},
       {path: 'paciente/:id', data: {title: 'paciente'}, component: PacienteTabsComponent},
 
     ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule] 
})

export class PacienteRoutingModule { }
