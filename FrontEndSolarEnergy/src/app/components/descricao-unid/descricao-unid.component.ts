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
  userActive:string | null = localStorage.getItem("usuario");
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

  download(){
    const element:HTMLElement | null = document.getElementById("myElement");
    
    if(!element){
      console.error("Element not found!");
      return;
    }
    let table = "";
    let data = "";
    for (let child of Array.from(element.children)) {
      for (let filhos of Array.from(child.children)){
        table += filhos.textContent + "\n\n";
      }
      data = table + "\n";
    }
    
    let dataHora = new Date();
    data = data.replace(/Imprimir/g, "Impresso por:"+ this.userActive + "\n" + dataHora.toLocaleDateString("pt-BR", {
      day: "2-digit",
      month: "2-digit",
      year: "numeric",
      hour: "2-digit",
      minute: "2-digit",
      second: "2-digit"
    }));
    let fileName = this.descricaoUnidade.apelido;

    const blob = new Blob([data], { type: "text/plain" });


    const link = document.createElement("a");
    link.style.display = "none";
    document.body.appendChild(link);

    link.href = URL.createObjectURL(blob);

    link.setAttribute("download", fileName+".txt");

    link.click();

    document.body.removeChild(link);
  }

}
