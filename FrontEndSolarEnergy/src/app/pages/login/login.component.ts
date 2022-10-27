import { HttpEvent, HttpHandler, HttpRequest } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { finalize, Observable, Subject } from 'rxjs';
import { ILogin } from 'src/app/models/interface';
import { AlertasService } from 'src/app/services/alertas.service';
import { LoginService } from 'src/app/services/Login.service';

@Component({
  selector: 'pro-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  public loading = false;

  //variável que faz a troca de mostrar ou esconder password
  visualizar:boolean = false;

  user:ILogin = {
    email: "",
    password: ""
  }

  constructor(
    private router:Router,
    private serviceTitle:Title,
    private loginService:LoginService,
    private alertasService:AlertasService) { }

  ngOnInit(): void {
    this.serviceTitle.setTitle('Solar Energy - Login');
  }

  public entrar(){
    this.loading = true;
    this.loginService.login(this.user)
      .subscribe((result) => {
        this.loading = false;
        this.loginService.salvarTokenLocalStorage(result);
      },
      error => {
        this.loading = false;
        console.error("Erro ao efetuar login");
        this.alertasService.alertaUserNaoEncontrado();
      }
      )
  }


  //método click que faz a navegação para o dashboard
  /* entrar(){
    this.buscarUsuario(this.user);
  } */

  //método para deixar a senha visível ou não
  visualizarSenha(){
    let senha = document.getElementById('password')
    if(this.visualizar){
      senha?.setAttribute('type', 'password');
    }else{
      senha?.setAttribute('type', 'text');
    }
    this.visualizar = !this.visualizar;
  }
}
