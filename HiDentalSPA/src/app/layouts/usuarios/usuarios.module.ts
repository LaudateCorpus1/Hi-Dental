import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsuariosComponent } from './usuarios.component';
import { FormsModule, ReactiveFormsModule, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { UsuariosRoutingModule } from './usuarios.routing.module';
import { UsuarioListadoComponent } from './usuario-listado/usuario-listado.component';
import { NgZorroAntdModule, NZ_I18N, en_US } from 'ng-zorro-antd';
import { ThemeConstantService } from 'src/app/shared/services/theme-constant.service';
import { SharedModule } from 'src/app/shared/shared.module';
import { TableService } from 'src/app/shared/services/table.service';
import { UsuarioTabsComponent } from './usuario-tabs/usuario-tabs.component';
import { PermisosTreeViewComponent } from './permisos-tree-view/permisos-tree-view.component';
import { UsuarioFormularioComponent } from './usuario-formulario/usuario-formulario.component';

@NgModule({
  imports: [
  
    CommonModule,
  
    SharedModule,
    UsuariosRoutingModule,
    NgZorroAntdModule,
    ReactiveFormsModule.withConfig({ warnOnNgModelWithFormControl: 'never' }),

 
  ],

  declarations: [UsuariosComponent, UsuarioListadoComponent, UsuarioTabsComponent,UsuarioFormularioComponent,PermisosTreeViewComponent],
      providers: [
        { 
            provide: NZ_I18N,
            useValue: en_US, 
        },
        TableService,
        ThemeConstantService
    ],
    exports: [
      
  ],

})
export class UsuariosModule { }
