import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { Subscriber } from 'rxjs';
import { Observable } from 'rxjs/internal/Observable';
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
  public loading = false;

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
    this.loading = true;
    this.cadastroService.cadastrar(this.newUser)
    .subscribe((response) => {
      this.loading = false;
      this.router.navigate(['/login']);
    },
      error => {
        this.loading = false;
        console.error("Erro ao efetuar cadastro");
        this.alertasService.erroAoEfetuarCadastro();
      }
    )
  }

  onChange($event: any) {
    if ($event.target.files[0].size >= 10240000) {
      window.alert('tamanho não é permitido');
      $event.target.value = null;
    } else {
      const file = $event.target.files[0];
      this.convertToBase64(file);
    }
  }

  convertToBase64(file: File) {
    const imageTrasfer = new Observable((subscriber: Subscriber<any>) => {
      this.readFile(file, subscriber);
    });
    imageTrasfer.subscribe((d) => {
      console.log(d);
      this.newUser.image = imageTrasfer;
    });
  }

  readFile(file: File, subscriber: Subscriber<any>) {
    const filereader = new FileReader();
    filereader.readAsDataURL(file);

    filereader.onload = () => {
      subscriber.next(filereader.result);
      subscriber.complete();
    };
    filereader.onerror = (error) => {
      subscriber.error(error);
      subscriber.complete();
    };
  }

  visualizarSenha() {
    const senha = document.querySelector('#password') as HTMLInputElement;
    senha.type = this.visualizar ? 'password' : 'text';
    this.visualizar = !this.visualizar;
  }
}
