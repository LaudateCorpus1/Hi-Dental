import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutComponent } from './layout.component';
import { LayoutRoutingModule } from './layout-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { ThemeConstantService } from '../shared/services/theme-constant.service';
import { TableService } from '../shared/services/table.service';
import { FullCalendarModule } from '@fullcalendar/angular';
import dayGridPlugin from '@fullcalendar/daygrid'; // a plugin
import interactionPlugin from '@fullcalendar/interaction';
import timeGridPlugin from '@fullcalendar/timegrid';
import listPlugin from '@fullcalendar/list';
 
@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FullCalendarModule,
  ],
  declarations: [LayoutComponent,LayoutRoutingModule],
  providers: [
    ThemeConstantService,
    TableService
]
})
export class LayoutModule { }
 