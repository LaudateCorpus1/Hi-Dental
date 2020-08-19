import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { User } from '../../interfaces/user.type';
import { BaseService, DataApi } from '../HTTPClient/base.service';
import { UserViewModel, UserAuthViewModel } from '../../Models/usuarios/usuarios';
import { Router, ActivatedRoute } from '@angular/router';


const USER_AUTH_API_URL = '/api-url';

@Injectable()
export class AuthenticationService {
    private currentUserSubject: BehaviorSubject<UserAuthViewModel>;
    public currentUser: Observable<UserAuthViewModel>;

    constructor(private http: HttpClient,public base:BaseService,   public route: ActivatedRoute,
        public router: Router) {
        this.currentUserSubject = new BehaviorSubject<UserAuthViewModel>(JSON.parse(localStorage.getItem('currentUser')));
        this.currentUser = this.currentUserSubject.asObservable();
    }

    public get currentUserValue(): UserAuthViewModel {
        return this.currentUserSubject.value;
    }
 
    login(username: string, password: string) {
       return this.base.DoPost<UserAuthViewModel>(DataApi.Auth, 'SigIn',
        {
          'userName': username,
          'password': password,

        }).pipe(map(user => {
            if (user && user.token) {
                localStorage.setItem('currentUser', JSON.stringify(user));
                this.currentUserSubject.next(user);
            }
            return user;
        }));
    }
  
    logout() {
        localStorage.removeItem('currentUser');
        this.currentUserSubject.next(null);
        this.router.navigateByUrl('/login');
    }
} 