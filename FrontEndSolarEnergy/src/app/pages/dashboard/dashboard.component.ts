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

  listaUnidades!:Observable<IUnidades[]>;
  listaGeracao!:Observable<IGeracao[]>;

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

  buscarUnidades(){
    this.listaUnidades = this.solarEnergyService.getListUnidades();
    this.totalunidades();
    this.isActive();
    this.mediaEnergia();
  }

  totalunidades(){
    this.listaUnidades.subscribe((result) =>{
      this.totalDeUnidades = result.length
    })
  }

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

  
  mediaEnergia() {
    this.listaGeracao = this.solarEnergyService.getListGeracoes();
    this.listaGeracao.subscribe(result => {
      if (result.length) {
        const totalEnergia = result.reduce((soma, item) => (soma + item.kw), 0);
        this.mediaDeEnergia = totalEnergia / this.unidadesAtivas;
        this.mediaDeEnergia = this.unidadesAtivas
          ? this.mediaDeEnergia.toFixed(0)
          : 0;
      }
    });
  }

}
