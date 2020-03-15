import { Routes } from '@angular/router';

export const Layout_ROUTES: Routes = [
    {
        path: 'dashboard',
        loadChildren: () => import('../dashboard/dashboard.module').then(m => m.DashboardModule),
        
    } ,
    
    {
        path: 'usuarios',
        data: {
            title: 'usuarios ',
        },
        loadChildren: () => import('../layouts/usuarios/usuarios.module').then(m => m.UsuariosModule),
    
        
    } 
];