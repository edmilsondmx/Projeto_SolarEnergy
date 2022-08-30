import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Observable } from 'rxjs';
import { IGeracao, IUnidades } from 'src/app/models/interface';
import { AlertasService } from 'src/app/services/alertas.service';
import { SolarEnergyApiService } from 'src/app/services/SolarEnergyApi.service';
import { UnidadesService } from 'src/app/services/unidades.service';

@Component({
  selector: 'pro-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.scss']
})
export class CadastroComponent implements OnInit {
  
  //variavel que avisa se alguma unidade foi selecionada ou não
  unidadeFoiSelecionada:boolean = true;

  //lista de unidades ativas e gerações consumidas do json-server
  listaUnidadesAtivas!:IUnidades[];
  listaGeracao!:IGeracao[];

  //objeto que guarda as informações da geração que estiver sendo feita
  novaGeracao:IGeracao = {
    id:0,
    data:"",
    kw: 0,
    unidadeId:0,
  }

  constructor(
    private unidadeService:UnidadesService,
    private alertasService:AlertasService,
    private serviceTitle:Title,
    private solarEnergyService:SolarEnergyApiService
  ) { }

  ngOnInit(): void {
    this.serviceTitle.setTitle('Solar Energy - Lançamento');
    this.buscarUnidadesAtivas();
    this.buscarGeracao();
  }
  
  //método que busca as unidades ativas e adicionas na variável
  buscarUnidadesAtivas(){
    this.solarEnergyService.getListUnidades()
    .subscribe((result) => {
       this.listaUnidadesAtivas = result.filter((item) => item.isActive == true)
    });
  }

  //metodo que chama a função de buscar as gerações no json-server e adiciona na variavel
  buscarGeracao(){
    this.solarEnergyService.getListGeracoes()
    .subscribe((result) => {
      this.listaGeracao = result;
    })
    /* this.unidadeService.devolverGeracao()
    .subscribe((result:IGeracao[]) =>{
      this.listaGeracao = result;
    }) */
  }

  //método que gera id para a nova geração, verifica se a unidade já tem a data cadastrada no json-server e senão, chama a função de cadastrar a nova geração
  cadastrarLancamento(){
    this.buscarGeracao();
    let dataJaCadastrada:boolean = this.listaGeracao.some((item) => item.data == this.novaGeracao.data && item.unidadeId == this.novaGeracao.unidadeId);
    if(dataJaCadastrada){
      this.alertasService.alertaDataCadastrada();
    } else{
      if(this.novaGeracao.unidadeId == 0){
        this.unidadeFoiSelecionada = false;
      } else {
        this.unidadeFoiSelecionada = true;
        this.solarEnergyService.postGeracao(this.novaGeracao).subscribe();
        this.alertasService.alertaKwIncluido();
      }
      this.buscarGeracao();
    }
  }

}
