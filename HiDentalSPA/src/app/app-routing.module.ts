import { NgModule } from '@angular/core';
import { RouterModule, Routes, PreloadAllModules } from '@angular/router';

import { FullLayoutComponent } from "./layouts/full-layout/full-layout.component";

import { FullLayout_ROUTES } from "./shared/routes/full-layout.routes";
import { CommonLayout_ROUTES } from "./shared/routes/common-layout.routes";
import { LayoutComponent } from './layouts/layout.component';
import { Layout_ROUTES } from './layouts/layout.routes';
import { AuthGuard } from './shared/guard/auth.guard';

const appRoutes: Routes = [
    {
        path: 'login', loadChildren: () => import('./login/login.module').then(m => m.LoginModule),
      },
          {
        path: '',
        redirectTo: '/dashboard/default',
        pathMatch: 'full',
    },

    { 
        path: '', 
        component: LayoutComponent,
        canActivate:[AuthGuard],
        children: Layout_ROUTES 
    },
  
    // {
    //     path: '', loadChildren: () => import('./layouts/layout.module').then(m => m.LayoutModule),
    //   },

];

@NgModule({ 
    imports: [
        RouterModule.forRoot(appRoutes, { 
            preloadingStrategy: PreloadAllModules,
            useHash: false,
            scrollPositionRestoration: 'enabled' 
        }),
    ],
    exports: [
        RouterModule
    ]
})

export class AppRoutingModule {
}