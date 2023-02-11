import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { IUnidades } from 'src/app/models/interface';
import { AlertasService } from 'src/app/services/alertas.service';
import { SolarEnergyApiService } from 'src/app/services/SolarEnergyApi.service';
import { UnidadesService } from 'src/app/services/unidades.service';

@Component({
  selector: 'pro-unidades',
  templateUrl: './unidades.component.html',
  styleUrls: ['./unidades.component.scss']
})
export class UnidadesComponent implements OnInit {

  // page = 1;
  // pageSize = 20;
  // cardSize = 0;

  listaUnidades!:Observable<IUnidades[]>;

  constructor(
    private router:Router,
    private unidadeService:UnidadesService,
    private serviceTitle: Title,
    private alertasService:AlertasService,
    private solarEnergyService:SolarEnergyApiService
  ) { }

  ngOnInit(): void {
    this.serviceTitle.setTitle('Solar Energy - Unidades');
    this.buscarUnidades();
  }

  //método que busca as unidades no Banco de dados e adiciona na variavel
  buscarUnidades(){
    this.listaUnidades = this.solarEnergyService.getListUnidades();
    /* this.unidadeService.devolverUnidade()
    .subscribe((result:IUnidades[]) =>{
      this.listaUnidades = result;
    }) */
  }

  //método que chama a função de editar a unidade e faz a navegação para a pagina
  editarUnid(id:number){
    this.solarEnergyService.getByIdUnidade(id)
    .subscribe((result) => {
      this.solarEnergyService.novaUnidade = result
    });
    //this.unidadeService.editarUnidade(id)
    this.router.navigate(['unidades/editar-unidades']);
  }

  //método que chama a função de remover a unidade clicada, alerta e atualiza a lista
  removerUnid(id:number){
    this.alertasService.confirmacaoRemocao()
    .then((result) => {
      if (result.isConfirmed) {
        this.solarEnergyService.deleteUnidade(id).subscribe((ok) => {
          this.alertasService.alertaUnidadeRemovida();
          this.buscarUnidades();
        },
        (error) => {
          this.alertasService.usuarioSemPermissao();
        });
        
      }
    });
  }

  //método que direciona para a página de cadastro de unidades
  cadastroUnidades(){
    this.router.navigate(['unidades/cadastro-unidades']);
  }

  mostrarGeracoes(unidade:IUnidades){
    this.solarEnergyService.descricaoUnidade = unidade;
    this.router.navigate(['unidades/geracoes'])
  }
}
