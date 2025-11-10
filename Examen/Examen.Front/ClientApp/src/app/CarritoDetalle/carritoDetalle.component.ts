import { Component } from "@angular/core";
import { Cart } from '../Servicios/cart.service';

@Component({
  selector: "carrito-detalle",
  templateUrl: "carritoDetalle.component.html"
})

export class CarritoDetalleComponent {
  constructor(public cart: Cart) { }
}


