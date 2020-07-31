import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutComponent } from './layout.component';
import { LayoutRoutingModule } from './layout-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { ThemeConstantService } from '../shared/services/theme-constant.service';
import { TableService } from '../shared/services/table.service';


@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    
  ],
  declarations: [LayoutComponent,LayoutRoutingModule],
  providers: [
    ThemeConstantService,
    TableService
]
})
export class LayoutModule { }
 