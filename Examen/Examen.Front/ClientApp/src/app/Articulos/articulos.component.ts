import { Component, Inject, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Articulo } from './articulos';
import { ModalComponent } from '../Modal/modal.component';
import { Tienda } from '../Tiendas/tiendas';
import { Cart } from '../Servicios/cart.service';
import { Router } from "@angular/router";
import { ArticuloTienda } from './articuloTienda';

@Component({
  selector: 'app-articulos',
  templateUrl: './articulos.component.html',
  styleUrls: ['./articulos.component.css']
})

export class ArticulosComponent {
  public articulos: Articulo[];
  public tiendas: ArticuloTienda[];

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

        this.sumarStock();

      }, error => console.error(error));

    var title = document.getElementById('title');
    title.innerHTML = "Existencia en tiendas";
    title.style.cssText = 'font-size:18px;';
  }

  sumarStock() {

    for (var i = 0; i < this.articulos.length; i++) {
      var hfg = this.articulos[i].articulosTienda;
      var stockTotal = (this.articulos[i].articulosTienda).reduce((accumulator, currentProduct) => {
        return accumulator + (currentProduct.stock);
      }, 0);

      this.articulos[i].stock = stockTotal;
    }
  }

  deleteArticle(id) {

    this.http.delete<Articulo[]>(this.baseUrl + 'api/Articles/' + id)
      .subscribe(result => {
        this.articulos = this.articulos.filter((c) => c.id !== id);
      }, error => console.error(error));
  }

  showStores(id) {
    this.http.get<ArticuloTienda[]>(this.baseUrl + "api/Articles/GetStoresByArticleId/" + id)
      .subscribe(result => {
        this.tiendas = result;

        this.configModal();

      }, error => console.error(error));
  }

  configModal() {

    var container = document.getElementsByClassName('modal-body')[0];
    container.innerHTML = "";

    // Create the table element
    const table = document.createElement('table');
    table.style.cssText = ' width:250px;';
    //table.setAttribute('border-bottom', '1'); // Add a border for visibility

    // Create the table header (thead)
    const thead = document.createElement('thead');
    const headerRow = document.createElement('tr');

    // Define header data
    const headers = ['Sucursal', 'Stock'];

    // Create and append table header cells (th)
    headers.forEach(headerText => {
      const th = document.createElement('th');
      th.style.cssText = ' background-color:gainsboro; border-bottom:1px solid gray; height:35px;';
      th.textContent = headerText;
      headerRow.appendChild(th);
    });
    thead.appendChild(headerRow);
    table.appendChild(thead);

    // Create the table body (tbody)
    const tbody = document.createElement('tbody');

    const selectedValues = [];

    this.tiendas.forEach(obj => {
        selectedValues.push({ tienda: obj['tienda'], stock: obj['stock']});
    });

    var suma = 0;

    selectedValues.forEach(rowData => {
      const row = document.createElement('tr');

      Object.entries(rowData).forEach(([key, value]) => {
        console.log(`Property Name: ${key}, Value: ${value}`);

        const td = document.createElement('td');
        td.style.cssText = 'height:35px;';
        td.textContent = value;

        if (key == "stock")
          suma = suma + Number(value);

        row.appendChild(td);
      });

      tbody.appendChild(row);
    });

    const rowTotal = document.createElement('tr');
    const tdTotal = document.createElement('td');
    tdTotal.textContent = "Total";
    rowTotal.appendChild(tdTotal);

    const tdTotal2 = document.createElement('td');
    rowTotal.style.cssText = ' background-color:gainsboro; height:35px; font-weight:bold;';
    tdTotal2.textContent = suma;
    rowTotal.appendChild(tdTotal2);
    tbody.appendChild(rowTotal);

    table.appendChild(tbody);

    // Append the complete table to the container
    container.appendChild(table);

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






