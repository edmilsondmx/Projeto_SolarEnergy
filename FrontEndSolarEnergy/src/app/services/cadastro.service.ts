import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { IUser } from '../models/interface';
import { AlertasService } from './alertas.service';
import { SolarEnergyApiService } from './SolarEnergyApi.service';

@Injectable({
  providedIn: 'root'
})
export class CadastroService {

  constructor(
    private router:Router,
    private alertasService:AlertasService,
    private solarEnergyApi:SolarEnergyApiService) { }

  cadastrar(newUser:IUser){
    return this.solarEnergyApi.postUsuarios(newUser)
  }
}
