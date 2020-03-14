import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsuariosComponent } from './usuarios.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UsuariosRoutingModule } from './usuarios.routing.module';
import { UsuarioListadoComponent } from './usuario-listado/usuario-listado.component';

@NgModule({
  imports: [
    CommonModule,
    UsuariosRoutingModule,
    ReactiveFormsModule.withConfig({ warnOnNgModelWithFormControl: 'never' }),
    FormsModule,
  ],
  declarations: [UsuariosComponent,UsuarioListadoComponent],

})
export class UsuariosModule { }
