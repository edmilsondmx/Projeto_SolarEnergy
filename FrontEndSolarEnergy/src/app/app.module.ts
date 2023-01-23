import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { LoginComponent } from './pages/login/login.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { RouterModule, Route } from '@angular/router';
import { UnidadesComponent } from './pages/unidades/unidades.component';
import { CadastroComponent } from './pages/cadastro-kw/cadastro.component';
import { CadastroUnidComponent } from './components/cadastro-unid/cadastro-unid.component';
import { HttpClientModule } from '@angular/common/http';
import { NgChartsModule } from 'ng2-charts';
import { GraficoComponent } from './components/grafico/grafico.component';
import { FooterComponent } from './components/footer/footer.component';
import { EditarUnidComponent } from './components/editar-unid/editar-unid.component';
import { SolarEnergyApiService } from './services/SolarEnergyApi.service';
import { AuthGuard } from './pages/login/auth.guard';
import { AppRoutingModule } from './app-routing.module';
import { LoginService } from './services/Login.service';
import { CadastroUserComponent } from './pages/cadastroUser/cadastro.user.component';
import { NgxLoadingModule } from "ngx-loading";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    SidebarComponent,
    DashboardComponent,
    UnidadesComponent,
    CadastroComponent,
    CadastroUnidComponent,
    GraficoComponent,
    FooterComponent,
    EditarUnidComponent,
    CadastroUserComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    NgChartsModule,
    AppRoutingModule,
    NgxLoadingModule.forRoot({}),
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      timeOut: 5000,
      positionClass: 'toast-top-right',
      progressBar: true,
      closeButton: true,
    })
    
  ],
  providers: [SolarEnergyApiService, AppRoutingModule, AuthGuard, LoginService],
  bootstrap: [AppComponent],
})
export class AppModule {}
