import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Observable } from 'rxjs';
import { IGeracao, IUnidades } from 'src/app/models/interface';
import { SolarEnergyApiService } from 'src/app/services/SolarEnergyApi.service';
import { UnidadesService } from 'src/app/services/unidades.service';

@Component({
  selector: 'pro-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  //listas de unidades e gerações consumidas do Json-server
  listaUnidades!:Observable<IUnidades[]>;
  listaGeracao!:Observable<IGeracao[]>;

  //variáveis onde são guardados os valores dos cards do dashboard
  totalDeUnidades:number = 0;
  unidadesAtivas:number = 0;
  unidadesInativas:number = 0;
  mediaDeEnergia:number | string = 0


  constructor(
    private unidadeService:UnidadesService,
    private serviceTitle: Title,
    private solarEnergyService:SolarEnergyApiService) { }

  ngOnInit(): void {
    this.serviceTitle.setTitle('Solar Energy - Dashboard');
    this.buscarUnidades();
  }

  //método que chama a função de buscar as unidades do json-server
  buscarUnidades(){
    this.listaUnidades = this.solarEnergyService.getListUnidades();
    this.totalunidades();
    this.isActive();
    this.mediaEnergia();
    /* this.unidadeService.devolverUnidade()
    .subscribe((result:IUnidades[]) =>{
      this.listaUnidades = result;
      this.totalunidades();
      this.isActive();
      this.mediaEnergia();
    }) */
  }

  //método que inclui a quantidade de unidades da lista na variavel
  totalunidades(){
    this.listaUnidades.subscribe((result) =>{
      this.totalDeUnidades = result.length
    })
  }

  //método que verifica a quantidade de unidades ativa e inativa e guarda na variavel
  isActive(){
    this.listaUnidades.subscribe((result) => {
      result.forEach((item) => {
        if(item.isActive === true){
          this.unidadesAtivas += 1;
        } else{
          this.unidadesInativas += 1;
        }
      })
    }) 
  }

  //método que tira a média de kw das unidades e guarda na variavel, se não tiver nenhuma geração ainda, é retornado 0
  mediaEnergia(){
    this.listaGeracao = this.solarEnergyService.getListGeracoes();
    this.listaGeracao.subscribe((result) => {
      if(result.length){
        let totalEnergia = result.reduce((soma, item) => 
          (soma + item.kw), 0) / this.unidadesAtivas;
        if(this.unidadesAtivas == 0){
          this.mediaDeEnergia == 0;
        }else{
          this.mediaDeEnergia = totalEnergia.toFixed(0);
        }
      }
    })
    /* this.unidadeService.devolverGeracao()
    .subscribe((result:IGeracao[]) =>{
      this.listaGeracao = result;
      if(this.listaGeracao.length){
        let totalEnergia = this.listaGeracao.reduce((soma, item) => (soma + item.kw), 0) / this.unidadesAtivas;
        if(this.unidadesAtivas == 0){
          this.mediaDeEnergia = 0;
        } else{
          this.mediaDeEnergia = totalEnergia.toFixed(0);
        }
      }
    }) */
  }

}
