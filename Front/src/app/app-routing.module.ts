import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ProductoComponent } from './producto/producto.component';
import { VentaComponent } from './venta/venta.component';
import { LoginComponent } from './login/login.component';
import { UsuarioComponent } from './usuario/usuario.component';
import { ActividadComponent } from './actividad/actividad.component';
import { AuthGuard } from './sacurity/auth.guard';

const routes: Routes = [
  {path: '', redirectTo: '/login', pathMatch: 'full'},
  {path: 'login', component: LoginComponent},
  {path: 'home', component: HomeComponent, canActivate:[AuthGuard]},
  {path: 'producto', component: ProductoComponent, canActivate:[AuthGuard]},
  {path: 'venta', component: VentaComponent, canActivate:[AuthGuard]},
  {path: 'usuario', component: UsuarioComponent, canActivate:[AuthGuard]},
  {path: 'actividad', component: ActividadComponent, canActivate:[AuthGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
