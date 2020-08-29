import { Component } from '@angular/core';
import { ThemeConstantService } from '../../services/theme-constant.service';
import { UserAuthViewModel } from '../../Models/usuarios/usuarios';
import { AuthenticationService } from '../../services/authentication.service';

@Component({
    selector: 'app-header',
    templateUrl: './header.component.html',
    providers:[AuthenticationService]
})

export class HeaderComponent{
    constructor( private themeService: ThemeConstantService,public authenticationService: AuthenticationService) {}

    searchVisible : boolean = false;
    quickViewVisible : boolean = false;
    isFolded : boolean;
    isExpand : boolean;
    currentUser:UserAuthViewModel;
    notificationList = [
        {
            title: 'You received a new message',
            time: '8 min',
            icon: 'mail',
            color: 'ant-avatar-' + 'blue'
        },
        {
            title: 'New user registered',
            time: '7 hours',
            icon: 'user-add',
            color: 'ant-avatar-' + 'cyan'
        },
        {
            title: 'System Alert',
            time: '8 hours',
            icon: 'warning',
            color: 'ant-avatar-' + 'red'
        },
        {
            title: 'You have a new update',
            time: '2 days',
            icon: 'sync',
            color: 'ant-avatar-' + 'gold'
        }
    ];

    ngOnInit(): void {
        this.themeService.isMenuFoldedChanges.subscribe(isFolded => this.isFolded = isFolded);
        this.themeService.isExpandChanges.subscribe(isExpand => this.isExpand = isExpand);
        this.currentUser=JSON.parse(localStorage.getItem('currentUser'));
        console.log(this.currentUser);
    }
    toggleFold() {
        this.isFolded = !this.isFolded;
        this.themeService.toggleFold(this.isFolded);
    }

    toggleExpand() {
        this.isFolded = false;
        this.isExpand = !this.isExpand;
        this.themeService.toggleExpand(this.isExpand);
        this.themeService.toggleFold(this.isFolded);
    }

    searchToggle(): void {
        this.searchVisible = !this.searchVisible;
    }

    quickViewToggle(): void {
        this.quickViewVisible = !this.quickViewVisible;
    }
    cerrarSesion(){
        this.authenticationService.logout();
    }
}
