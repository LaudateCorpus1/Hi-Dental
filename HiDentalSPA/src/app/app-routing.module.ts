import { NgModule } from '@angular/core';
import { RouterModule, Routes, PreloadAllModules } from '@angular/router';


import { Layout_ROUTES } from './layouts/layout.routes';
import { LayoutComponent } from './layouts/layout.component';
import { AuthGuard } from './shared/guard/auth.guard';

const appRoutes: Routes = [
    {
        path: '',
        redirectTo: '/dashboard/home',
        pathMatch: 'full',
    },
      { 
        path: '', 
        component: LayoutComponent,
        canActivate:[AuthGuard],
        children: Layout_ROUTES 
    },
  
];

@NgModule({
    imports: [
        RouterModule.forRoot(appRoutes, { 
            preloadingStrategy: PreloadAllModules,
            anchorScrolling: 'enabled',
            scrollPositionRestoration: 'enabled' 
        })
    ],
    exports: [
        RouterModule
    ]
})

export class AppRoutingModule {
}