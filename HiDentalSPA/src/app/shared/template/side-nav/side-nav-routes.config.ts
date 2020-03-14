import { SideNavInterface } from '../../interfaces/side-nav.type';
export const ROUTES: SideNavInterface[] = [
    {
        path: '',
        title: 'Dashboard',
        iconType: 'nzIcon',
        iconTheme: 'outline',
        icon: 'dashboard',
        submenu: [
            { 
                path: '',
                title: 'Level 1', 
                iconType: '', 
                icon: '',
                iconTheme: '',
                submenu: [
                    {
                        path: '',
                        title: 'Level 2',
                        iconType: 'nzIcon',
                        iconTheme: 'outline',
                        icon: 'layout',
                        submenu: []
                    }    
                ] 
            }
        ]
    },
    {
        path: '',
        title: 'Citas',
        iconType: 'nzIcon',
        iconTheme: 'outline',
        icon: 'schedule',
        submenu: [
      
        ]
    },
    {
        path: '',
        title: 'Pacientes',
        iconType: 'nzIcon',
        iconTheme: 'outline',
        icon: 'team',
        submenu: [
      
        ]
    },
    {
        path: '',
        title: 'Consultas',
        iconType: 'nzIcon',
        iconTheme: 'outline',
        icon: 'file-search',
        submenu: [
      
        ]
    },
    {
        path: '',
        title: 'Tratamientos',
        iconType: 'nzIcon',
        iconTheme: 'outline',
        icon: 'medicine-box',
        submenu: [
      
        ]
    },
    {
        path: '',
        title: 'Servicios',
        iconType: 'nzIcon',
        iconTheme: 'outline',
        icon: 'medicine-box',
        submenu: [
      
        ]
    },
    {
        path: '',
        title: 'Reportes',
        iconType: 'nzIcon',
        iconTheme: 'outline',
        icon: 'file',
        submenu: [
            { 
                path: '',
                title: 'Level 1', 
                iconType: '', 
                icon: '',
                iconTheme: '',
                submenu: [
                    {
                        path: '',
                        title: 'Level 2',
                        iconType: 'nzIcon',
                        iconTheme: 'outline',
                        icon: 'layout',
                        submenu: []
                    }    
                ] 
            }
        ]
    },
    {
        path: '/usuarios',
        title: 'usuarios',
        iconType: 'nzIcon',
        iconTheme: 'outline',
        icon: 'user',
        submenu: [
      
        ]
    },
]    