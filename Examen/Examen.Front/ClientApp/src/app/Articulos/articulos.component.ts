import { Component, Inject, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Articulo } from './articulos';
import { ModalComponent } from '../Modal/modal.component';
import { Tienda } from '../Tiendas/tiendas';
import { Cart } from '../Servicios/cart.service';
import { Router } from "@angular/router";

@Component({
  selector: 'app-articulos',
  templateUrl: './articulos.component.html',
  styleUrls: ['./articulos.component.css']
})

export class ArticulosComponent {
  public articulos: Articulo[];
  public tiendas: Tienda[];

  @ViewChild(ModalComponent, { static: true }) childComponent!: ModalComponent;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string,
    private cart: Cart,
    private router: Router   ) {
  }

  ngOnInit() {
    this.http.get<Articulo[]>(this.baseUrl + 'api/Articles')
      .subscribe(result => {
        this.articulos = result;
      }, error => console.error(error));

    var title = document.getElementById('title');
    title.innerHTML = "Existencia en tiendas";
  }

  deleteArticle(id) {

    this.http.delete<Articulo[]>(this.baseUrl + 'api/Articles/' + id)
      .subscribe(result => {
        this.articulos = this.articulos.filter((c) => c.id !== id);
      }, error => console.error(error));
  }

  showStores(id) {
    this.http.get<Tienda[]>(this.baseUrl + "api/Articles/GetStoresByArticleId/" + id)
      .subscribe(result => {
        this.tiendas = result;

        this.configModal();

      }, error => console.error(error));
  }

  configModal() {

    var body = document.getElementsByClassName('modal-body')[0];
    body.innerHTML = "";

    (this.tiendas).forEach((value) => {
      var nuevaLista = document.createElement('ul');
      nuevaLista.innerHTML += '<li>' + value.sucursal + '</li>';
      body.appendChild(nuevaLista);
    });

    this.showModal();

  }

  showModal() {
    this.childComponent.showModal();
  }

  addProductToCart(article: Articulo) {
    this.cart.addLine(article);
    this.router.navigateByUrl("/carrito");
  }

}






