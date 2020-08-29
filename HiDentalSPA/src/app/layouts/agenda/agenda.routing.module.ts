import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { AgendaComponent } from './agenda.component';


const routes: Routes = [
  {  path: '', component: AgendaComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class AgendaRoutingModule { }
