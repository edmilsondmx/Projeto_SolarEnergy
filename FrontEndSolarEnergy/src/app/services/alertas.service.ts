import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import Swal from 'sweetalert2';
import { UnidadesComponent } from '../pages/unidades/unidades.component';
import { SolarEnergyApiService } from './SolarEnergyApi.service';

@Injectable({
  providedIn: 'root',
})
export class AlertasService {
  constructor(private toastr: ToastrService) {}

  //alerta de unidade removida no json-server
  alertaUnidadeRemovida() {
    this.toastr.error('Unidade Removida!');
    /* Swal.fire({
      position: 'top',
      text: '❌ Unidade Removida!',
      width: 350,
      color: '#D82D56',
      background: '#f7d2db',
      showConfirmButton: false,
      timer: 700,
    }); */
  }
  //alerta de unidade adicionada no json-server
  alertaUnidadeAdicionada() {
    this.toastr.success('', 'Unidade adicionada com Sucesso!');
    /* Swal.fire({
      position: 'top',
      text: '✔️ Unidade adicionada com Sucesso!',
      width: 400,
      color: '#8DB51B',
      background: '#edf7d3',
      showConfirmButton: false,
      timer: 800,
    }); */
  }
  //alerta de unidade editada no json-server
  alertaEdicaoSalva() {
    this.toastr.success('', 'Alteração salva com sucesso!');
    /* Swal.fire({
      position: 'top',
      text: '✔️ Alteração salva com sucesso!',
      width: 400,
      color: '#8DB51B',
      background: '#edf7d3',
      showConfirmButton: false,
      timer: 800,
    }); */
  }
  //alerta data de geração ja feita no json-server
  alertaDataCadastrada() {
    this.toastr.warning('Data já cadastrada no sistema', 'Alerta!');
    /* Swal.fire({
      position: 'top',
      text: '❌ ERRO: Data já cadastrada no sistema',
      width: 350,
      color: '#D82D56',
      background: '#f7d2db',
      showConfirmButton: false,
      timer: 1000,
    }); */
  }
  //alerta de kw incluido no json-server
  alertaKwIncluido() {
    this.toastr.success('', 'Geração incluída com sucesso!');
    /* Swal.fire({
      position: 'top',
      text: '✔️ Geração incluída com sucesso!',
      width: 400,
      color: '#8DB51B',
      background: '#edf7d3',
      showConfirmButton: false,
      timer: 800,
    }); */
  }

  confirmacaoRemocao() {
    return Swal.fire({
      title: 'Tem certeza?',
      text: 'Você não será capaz de reverter isso!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#8DB51B',
      cancelButtonColor: '#D82D56',
      confirmButtonText: 'Sim, exclua!',
      cancelButtonText: 'Cancelar',
    });
  }

  alertaUserNaoEncontrado() {
    this.toastr.error('','Usuário não encontrado');
    /* Swal.fire({
      position: 'top',
      text: '❌ ERRO: Usuário não encontrado',
      width: 350,
      color: '#D82D56',
      background: '#f7d2db',
      showConfirmButton: false,
      timer: 5000
    }) */
  }

  erroAoEfetuarCadastro(){
    this.toastr.warning('','ERRO: Tente novamente!',{
      positionClass: 'toast-top-center',
    })
  }

  cadastroEfetuado(){
    this.toastr.success('','Cadastro efetuado!',{
      positionClass: 'toast-top-center',
    })
  }

  usuarioSemPermissao(){
    this.toastr.error('', 'ERRO: Usuário sem permissão!')
  }
}
