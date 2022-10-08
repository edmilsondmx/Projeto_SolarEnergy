import { HttpClient, HttpHeaders } from '@angular/common/http';
import { error } from '@angular/compiler/src/util';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AppConstants } from '../app-constants';
import { ILogin, IUser } from '../models/interface';
import { AlertasService } from './alertas.service';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  readonly solarEnergyApiUrl = "https://localhost:7268/api/";

  listUsers!:IUser[];

  usuario:IUser | undefined = {
    id:0,
    nome:"",
    email:"",
    role:""
  }

  constructor(
    private http:HttpClient,
    private router:Router,
    private alertasService:AlertasService
  ) { }

  login(user:ILogin){
    const headers = new HttpHeaders({'Content-Type' : 'application/json'});
    let token = this.http.post(AppConstants.baseLogin, JSON.stringify(user), {headers: headers})
      .subscribe((result) => {
      this.salvarTokenLocalStorage(result);
    },
      error => {
        console.error("Erro ao efetuar login");
        this.alertasService.alertaUserNaoEncontrado();
      }
    )
  }

  salvarTokenLocalStorage(result:Object)
  {
    let token = JSON.parse(JSON.stringify(result)).item1;
    let refreshToken = JSON.parse(JSON.stringify(result)).item2;

    localStorage.setItem("token", token);
    localStorage.setItem("refreshToken", refreshToken);
    this.router.navigate(['/dashboard']);
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
