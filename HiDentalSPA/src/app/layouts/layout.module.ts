import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutComponent } from './layout.component';
import { LayoutRoutingModule } from './layout-routing.module';

@NgModule({
  imports: [
    CommonModule,
  ],
  declarations: [LayoutComponent,LayoutRoutingModule]
})
export class LayoutModule { }
 