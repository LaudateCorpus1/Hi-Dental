import { Routes } from '@angular/router';

export const Layout_ROUTES: Routes = [
    {
        path: 'dashboard',
        loadChildren: () => import('../dashboard/dashboard.module').then(m => m.DashboardModule),
    } ,
    {
        path: 'agenda',
        data: {
            title: 'citas',
        },
        loadChildren: () => import('../layouts/agenda/agenda.module').then(m => m.AgendaModule),
    },
    {
        path: 'pacientes',
        data: {
            title: 'pacientes',
        },
        loadChildren: () => import('../layouts/paciente/paciente.module').then(m => m.PacienteModule),
    },

    {
        path: 'usuarios',
        data: {
            title: 'usuarios',
        },
        loadChildren: () => import('../layouts/usuarios/usuarios.module').then(m => m.UsuariosModule),
    },
    {
        path: 'oficinas',
        data: {
            title: 'oficinas',
        },
        loadChildren: () => import('../layouts/oficinas/oficinas.module').then(m => m.OficinasModule),
    },
      {
        path: 'sucursales',
        data: {
            title: 'sucursales',
        },
        loadChildren: () => import('../layouts/sucursales/sucursales.module').then(m => m.SucursalesModule),
    }

];
