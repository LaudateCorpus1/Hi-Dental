import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PacienteComponent } from './paciente.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { NgZorroAntdModule, NZ_I18N, en_US } from 'ng-zorro-antd';
import { ReactiveFormsModule } from '@angular/forms';
import { PacienteTabsComponent } from './paciente-tabs/paciente-tabs.component';
import { PacienteListadoComponent } from './paciente-listado/paciente-listado.component';
import { TableService } from 'src/app/shared/services/table.service';
import { ThemeConstantService } from 'src/app/shared/services/theme-constant.service';
import { PacienteRoutingModule } from './paciente.routing.module';

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    PacienteRoutingModule,
    NgZorroAntdModule,
    ReactiveFormsModule.withConfig({ warnOnNgModelWithFormControl: 'never' }),
  ],
  declarations: [PacienteComponent, PacienteListadoComponent, PacienteTabsComponent],
  providers: [
    {
        provide: NZ_I18N,
        useValue: en_US,
    },
    TableService,
    ThemeConstantService
],
})
export class PacienteModule { }
