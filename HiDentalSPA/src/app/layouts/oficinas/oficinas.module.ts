import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OficinasComponent } from './oficinas.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { NgZorroAntdModule, NZ_I18N, en_US } from 'ng-zorro-antd';
import { ReactiveFormsModule } from '@angular/forms';
import { OficinasRoutingModule } from './oficinas.routing.module';
import { OficinaListadoComponent } from './oficina-listado/oficina-listado.component';
import { OficinaFormularioComponent } from './oficina-formulario/oficina-formulario.component';
import { TableService } from 'src/app/shared/services/table.service';
import { ThemeConstantService } from 'src/app/shared/services/theme-constant.service';

@NgModule({
  imports: [
  
    CommonModule,
    OficinasRoutingModule,
    SharedModule,
    NgZorroAntdModule,
    
    ReactiveFormsModule.withConfig({ warnOnNgModelWithFormControl: 'never' }),

 
  ],

  declarations: [OficinasComponent, OficinaListadoComponent, OficinaFormularioComponent],
  providers: [
    { 
        provide: NZ_I18N,
        useValue: en_US, 
    },
    TableService,
    ThemeConstantService
],
})
export class OficinasModule { }
