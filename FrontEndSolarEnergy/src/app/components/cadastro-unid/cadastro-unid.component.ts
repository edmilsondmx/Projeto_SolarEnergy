import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { IUnidades } from 'src/app/models/interface';
import { UnidadesComponent } from 'src/app/pages/unidades/unidades.component';
import { AlertasService } from 'src/app/services/alertas.service';
import { SolarEnergyApiService } from 'src/app/services/SolarEnergyApi.service';
import { UnidadesService } from 'src/app/services/unidades.service';

@Component({
  selector: 'pro-cadastro-unid',
  templateUrl: './cadastro-unid.component.html',
  styleUrls: ['./cadastro-unid.component.scss']
})
export class CadastroUnidComponent implements OnInit {

  novaUnidade:IUnidades = {
    id: 0,
    apelido: "",
    local: "",
    marca: "",
    modelo: "",
    isActive: false
  };

  constructor(
    public unidadeService:UnidadesService,
    public alertasService:AlertasService,
    private serviceTitle:Title,
    public solarEnergyService:SolarEnergyApiService,
    private router:Router) { }

  ngOnInit(): void {
    this.serviceTitle.setTitle('Solar Energy - Cadastrar');
  }

  //método que chama a função de cadastrar unidade e alerta
  adicionarUnidade(){
    /* this.unidadeService.cadastrarUnidade(); */
    this.solarEnergyService.postUnidade(this.novaUnidade).subscribe();
    this.router.navigate(['/unidades'])
    this.alertasService.alertaUnidadeAdicionada();
    //this.buscarUnidades()
  }

  //método que atualiza a lista de unidades
  buscarUnidades(){
    /* this.unidadeService.devolverUnidade()
    .subscribe((result:IUnidades[]) =>
    result) */
  }

}
