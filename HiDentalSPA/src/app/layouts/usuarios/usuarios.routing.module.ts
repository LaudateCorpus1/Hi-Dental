import { Routes, RouterModule } from '@angular/router';
import { UsuariosComponent } from './usuarios.component';
import { UsuarioListadoComponent } from './usuario-listado/usuario-listado.component';
import { NgModule } from '@angular/core';

const routes: Routes = [
  {  path: '', component: UsuariosComponent,
     children: [
       {path: '', component: UsuarioListadoComponent},
     ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class UsuariosRoutingModule { }
