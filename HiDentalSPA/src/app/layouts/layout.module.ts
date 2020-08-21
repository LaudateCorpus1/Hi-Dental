import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutComponent } from './layout.component';
import { LayoutRoutingModule } from './layout-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { ThemeConstantService } from '../shared/services/theme-constant.service';
import { TableService } from '../shared/services/table.service';
import { TemplateModule } from '../shared/template/template.module';

 
@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    TemplateModule,
  ],

  declarations: [LayoutComponent, LayoutRoutingModule],
  providers: [
    ThemeConstantService,
    TableService
]
})
export class LayoutModule { }
 