import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { IUser } from 'src/app/models/interface';
import { AlertasService } from 'src/app/services/alertas.service';
import { CadastroService } from 'src/app/services/cadastro.service';
import { SolarEnergyApiService } from 'src/app/services/SolarEnergyApi.service';

@Component({
  selector: 'pro-cadastro.user',
  templateUrl: './cadastro.user.component.html',
  styleUrls: ['./cadastro.user.component.scss']
})
export class CadastroUserComponent implements OnInit {
  visualizar:boolean = false;

  newUser:IUser = {
    id: 0,
    nome: "",
    email: "",
    password: "",
    role: 2
  }

  constructor(
    private serviceTitle:Title,
    private router:Router,
    private solarEnergyApi:SolarEnergyApiService,
    private alertasService:AlertasService,
    private cadastroService:CadastroService) { }

  ngOnInit(): void {
    this.serviceTitle.setTitle('Solar Energy - SignUp');
  }

  cadastrar(){
    console.log(this.newUser)
    this.alertasService.loader();
    this.cadastroService.cadastrar(this.newUser);
  }

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
