import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ClientesComponent } from './Clientes/clientes.component';
import { ClientesEditComponent } from './Clientes/clientes-edit.component';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
import { TiendasComponent } from './Tiendas/tiendas.component';
import { TiendasEditComponent } from './Tiendas/tiendas-edit.component';
import { ArticulosComponent } from './Articulos/articulos.component';
import { ArticulosEditComponent } from './Articulos/articulos-edit.component';
import { ModalComponent } from './Modal/modal.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    ClientesComponent,
    ClientesEditComponent,
    TiendasComponent,
    TiendasEditComponent,
    ArticulosComponent,
    ArticulosEditComponent,
    ModalComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: ClientesComponent, pathMatch: 'full' },
      { path: 'clientes', component: ClientesComponent },
      { path: 'clientesEdit/:id', component: ClientesEditComponent },
      { path: 'clientesEdit', component: ClientesEditComponent },
      { path: 'tiendas', component: TiendasComponent },
      { path: 'tiendasEdit/:id', component: TiendasEditComponent },
      { path: 'tiendasEdit', component: TiendasEditComponent },
      { path: 'articulos', component: ArticulosComponent },
      { path: 'articulosEdit/:id', component: ArticulosEditComponent },
      { path: 'articulosEdit', component: ArticulosEditComponent }
    ]),
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
