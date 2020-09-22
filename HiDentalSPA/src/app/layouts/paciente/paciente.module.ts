import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PacienteComponent } from './paciente.component';
import { SharedModule } from 'src/app/shared/shared.module';
import {  NZ_I18N, en_US } from 'ng-zorro-antd';
import { ReactiveFormsModule } from '@angular/forms';
import { PacienteTabsComponent } from './paciente-tabs/paciente-tabs.component';
import { PacienteListadoComponent } from './paciente-listado/paciente-listado.component';
import { TableService } from 'src/app/shared/services/table.service';
import { ThemeConstantService } from 'src/app/shared/services/theme-constant.service';
import { PacienteRoutingModule } from './paciente.routing.module';


import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzCardModule } from 'ng-zorro-antd/card';
import { NzAvatarModule } from 'ng-zorro-antd/avatar';
import { NzRateModule } from 'ng-zorro-antd/rate';
import { NzBadgeModule } from 'ng-zorro-antd/badge';
import { NzProgressModule } from 'ng-zorro-antd/progress';
import { NzRadioModule } from 'ng-zorro-antd/radio';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzDropDownModule } from 'ng-zorro-antd/dropdown';
import { NzTimelineModule } from 'ng-zorro-antd/timeline';
import { NzTabsModule } from 'ng-zorro-antd/tabs';
import { NzTagModule } from 'ng-zorro-antd/tag';
import { NzListModule } from 'ng-zorro-antd/list';
import { NzCalendarModule } from 'ng-zorro-antd/calendar';
import { NzToolTipModule } from 'ng-zorro-antd/tooltip';
import { NzCheckboxModule } from 'ng-zorro-antd/checkbox';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzModalModule } from 'ng-zorro-antd/modal';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzSpinModule } from 'ng-zorro-antd/spin';
import { NzNotificationServiceModule } from 'ng-zorro-antd/notification';
import { NzSelectModule } from 'ng-zorro-antd/select';
import { NzUploadModule } from 'ng-zorro-antd/upload';

const antdModule = [
  NzButtonModule,
  NzCardModule,
  NzAvatarModule,
  NzRateModule,
  NzBadgeModule,
  NzProgressModule,
  NzRadioModule,
  NzTableModule,
  NzDropDownModule,
  NzTimelineModule,
  NzTabsModule,
  NzTagModule,
  NzListModule,
  NzCalendarModule,
  NzToolTipModule,
  NzCheckboxModule,
  NzSpinModule,
  NzModalModule,
  NzInputModule,
  NzFormModule,
  NzNotificationServiceModule,
  NzSelectModule,
  NzUploadModule
];

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    antdModule,
    PacienteRoutingModule,
    ReactiveFormsModule.withConfig({ warnOnNgModelWithFormControl: 'never' }),
  ],
  schemas: [ CUSTOM_ELEMENTS_SCHEMA ],
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
