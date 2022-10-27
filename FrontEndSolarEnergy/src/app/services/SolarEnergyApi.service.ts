import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { IUnidades, IGeracao, IUser } from '../models/interface';
import { AppConstants } from '../app-constants';

@Injectable({
  providedIn: 'root'
})
export class SolarEnergyApiService {

  novaUnidade:IUnidades = {
    id: 0,
    apelido: "",
    local: "",
    marca: "",
    modelo: "",
    isActive: false,
  }

  readonly solarEnergyApiUrl = "https://localhost:7268/api/";

  constructor(private http:HttpClient) { }

  //Métodos das Unidades
  getListUnidades():Observable<IUnidades[]>{
    return this.http.get<IUnidades[]>(`${this.solarEnergyApiUrl}unidades`);
  }
  getByIdUnidade(id:number):Observable<IUnidades>{
    return this.http.get<IUnidades>(`${this.solarEnergyApiUrl}unidades/${id}`);
  }
  postUnidade(novaUnidade:IUnidades){
    return this.http.post(`${this.solarEnergyApiUrl}unidades`, novaUnidade);
  }
  putUnidade(id:number|string, novaUnidade:IUnidades){
    return this.http.put(`${this.solarEnergyApiUrl}unidades/${id}`, novaUnidade);
  }
  deleteUnidade(id:number|string){
    return this.http.delete(`${this.solarEnergyApiUrl}unidades/${id}`);
  }

  //Métodos das Gerações
  getListGeracoes():Observable<IGeracao[]>{
    return this.http.get<IGeracao[]>(`${this.solarEnergyApiUrl}geracoes`);
  }
  postGeracao(novaGeracao:IGeracao){
    return this.http.post(`${this.solarEnergyApiUrl}geracoes`, novaGeracao);
  }
  putGeracao(id:number|string, novaGeracao:IGeracao){
    return this.http.put(`${this.solarEnergyApiUrl}geracoes/${id}`, novaGeracao);
  }
  deleteGeracao(id:number|string){
    return this.http.delete(`${this.solarEnergyApiUrl}geracoes/${id}`);
  }

  //Métodos Usuarios
  postUsuarios(newUser:IUser){
    return this.http.post(AppConstants.baseUsers, newUser);
  }

}
