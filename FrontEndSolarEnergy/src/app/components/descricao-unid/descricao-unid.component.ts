import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IGeracao, IUnidades } from 'src/app/models/interface';
import { SolarEnergyApiService } from 'src/app/services/SolarEnergyApi.service';

@Component({
  selector: 'pro-descricao-unid',
  templateUrl: './descricao-unid.component.html',
  styleUrls: ['./descricao-unid.component.scss']
})
export class DescricaoUnidComponent implements OnInit {

  descricaoUnidade!:IUnidades;
  geracoesUnidade!:Observable<IGeracao[]>;
  qtdGeracoes:number = 0;

  constructor( private solarEnergyService:SolarEnergyApiService) { }

  ngOnInit(): void {
    this.mostrarGeracoes()
  }

  mostrarGeracoes(){
    this.descricaoUnidade = this.solarEnergyService.descricaoUnidade;
    this.geracoesUnidade = this.solarEnergyService.getGeracoesByUnidadeId(this.descricaoUnidade?.id)
    
    this.geracoesUnidade.subscribe((result:IGeracao[]) => {
      this.qtdGeracoes = result.length;
    })
    
  }

}
