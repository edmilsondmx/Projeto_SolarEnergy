import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { IUnidades } from 'src/app/models/interface';
import { AlertasService } from 'src/app/services/alertas.service';
import { SolarEnergyApiService } from 'src/app/services/SolarEnergyApi.service';
import { UnidadesService } from 'src/app/services/unidades.service';

@Component({
  selector: 'pro-editar-unid',
  templateUrl: './editar-unid.component.html',
  styleUrls: ['./editar-unid.component.scss']
})
export class EditarUnidComponent implements OnInit {

  constructor(
    private router:Router,
    public unidadeService:UnidadesService,
    public alertasService:AlertasService,
    private serviceTitle:Title,
    public solarEnergyService:SolarEnergyApiService
  ) { }

  ngOnInit(): void {
    this.serviceTitle.setTitle('Solar Energy - Editar');
  }


  //método que chama as funções de salvar a edição do service, alerta e direciona para a página de lista de unidades
  salvarAlteracao(id:number){
    this.solarEnergyService.putUnidade(id, this.solarEnergyService.novaUnidade)
    .subscribe();
    //this.unidadeService.salvarEdicao(id);
    this.alertasService.alertaEdicaoSalva();
    this.router.navigate(['/unidades'])
  }

}
