import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Route, RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { UnidadesComponent } from './pages/unidades/unidades.component';
import { CadastroUnidComponent } from './components/cadastro-unid/cadastro-unid.component';
import { EditarUnidComponent } from './components/editar-unid/editar-unid.component';
import { CadastroComponent } from './pages/cadastro-kw/cadastro.component';
import { AuthGuard } from './pages/login/auth.guard';
import { LoginComponent } from './pages/login/login.component';
import { AppComponent } from './app.component';
import { NgxLoadingModule } from 'ngx-loading';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  {
    path: 'dashboard',
    component: DashboardComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'unidades',
    canActivate: [AuthGuard],
    canActivateChild: [AuthGuard],
    children: [
      {
        path: '',
        component: UnidadesComponent,
      },
      {
        path: 'cadastro-unidades',
        component: CadastroUnidComponent,
      },
      {
        path: 'editar-unidades',
        component: EditarUnidComponent,
      },
    ],
  },
  { path: 'cadastro', component: CadastroComponent, canActivate: [AuthGuard] },
  { path: '**', redirectTo: '/login', pathMatch: 'full' },
];

@NgModule({
  declarations: [],
  exports: [RouterModule],
  imports: [CommonModule, RouterModule.forRoot(routes)],
})
export class AppRoutingModule {}
