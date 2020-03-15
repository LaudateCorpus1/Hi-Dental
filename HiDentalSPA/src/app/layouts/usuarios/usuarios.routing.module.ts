import { Routes, RouterModule } from '@angular/router';
import { UsuariosComponent } from './usuarios.component';
import { UsuarioListadoComponent } from './usuario-listado/usuario-listado.component';
import { NgModule } from '@angular/core';
import { UsuarioTabsComponent } from './usuario-tabs/usuario-tabs.component';

const routes: Routes = [
  {  path: '', component: UsuariosComponent,
     children: [
       {path: '', component: UsuarioListadoComponent},
       {path: 'usuario/:id', component: UsuarioTabsComponent},
     ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class UsuariosRoutingModule { }
