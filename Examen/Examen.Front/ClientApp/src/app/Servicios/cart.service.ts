import { Injectable } from "@angular/core";
import { Articulo } from "../Articulos/articulos";

@Injectable()
export class Cart {
  public lines: CartLine[] = [];
  public itemCount: number = 0;
  public cartPrice: number = 0;

  addLine(article: Articulo, quantity: number = 1) {
    let line = this.lines.find(line => line.article.id == article.id);
    if (line != undefined) {
      line.quantity += quantity;
    } else {
      this.lines.push(new CartLine(article, quantity));
    }
    this.recalculate();
  }

  updateQuantity(article: Articulo, quantity: number) {
    let line = this.lines.find(line => line.article.id == article.id);
    if (line != undefined) {
      line.quantity = Number(quantity);
    }
    this.recalculate();
  }

  removeLine(id: number) {
    let index = this.lines.findIndex(line => line.article.id == id);
    this.lines.splice(index,1);
    this.recalculate();
  }

  clear() {
    this.lines = [];
    this.itemCount = 0;
    this.cartPrice = 0;
  }

  private recalculate() {
    this.itemCount = 0;
    this.cartPrice = 0;
    this.lines.forEach(l => {
      this.itemCount += l.quantity;
      this.cartPrice += (l.quantity * l.article.precio);
    })
  }
}

export class CartLine {
  constructor(public article: Articulo,
    public quantity: number) { }

  get lineTotal() {
    return this.quantity * this.article.precio;
  }
}
