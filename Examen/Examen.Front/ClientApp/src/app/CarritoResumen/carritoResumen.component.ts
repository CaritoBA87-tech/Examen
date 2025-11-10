import { Component } from "@angular/core";
import { Cart } from "../Servicios/cart.service";

@Component({
  selector: "carrito-resumen",
  templateUrl: "carritoResumen.component.html",
  styleUrls: ["carritoResumen.component.css"]
})

export class CarritoResumenComponent {

  constructor(public cart: Cart) { }

}
