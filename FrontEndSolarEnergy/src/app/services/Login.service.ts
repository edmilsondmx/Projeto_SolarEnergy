import { HttpClient, HttpEvent, HttpHandler, HttpHeaders, HttpRequest } from '@angular/common/http';
import { error } from '@angular/compiler/src/util';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { finalize, Observable, Subject } from 'rxjs';
import { AppConstants } from '../app-constants';
import { ILogin, IUser } from '../models/interface';
import { AlertasService } from './alertas.service';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  public loading = false;

  readonly solarEnergyApiUrl = "https://localhost:7268/api/";

  listUsers!:IUser[];

  usuario:IUser | undefined = {
    id:0,
    nome:"",
    email:"",
    password: "",
    role:0
  }

  constructor(
    private http:HttpClient,
    private router:Router,
    private alertasService:AlertasService,
  ) { }

  login(user:ILogin){
    const headers = new HttpHeaders({'Content-Type' : 'application/json'});
    return this.http.post(AppConstants.baseLogin, JSON.stringify(user), {headers: headers})
  }

  salvarTokenLocalStorage(result:Object)
  {
    let token = JSON.parse(JSON.stringify(result)).item1;
    let refreshToken = JSON.parse(JSON.stringify(result)).item2;
    let user = JSON.parse(JSON.stringify(result)).item3;

    localStorage.setItem("token", token);
    localStorage.setItem("refreshToken", refreshToken);
    localStorage.setItem("usuario", user);
    this.router.navigate(['/dashboard']);

    setTimeout(() => {
      this.limparLocalStorage();
    }, 648000000);
  }

  limparLocalStorage(){
    localStorage.clear();
  }

  /* devolverUsuario():Observable<IUser[]>{
    return this.http.get<IUser[]>(AppConstants.baseUsers)
  }

  buscarUsuario(user:ILogin){
    this.devolverUsuario().subscribe((result) => {
      this.listUsers = result;
    })
  } */
}
