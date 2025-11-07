import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Articulo } from './articulos';

@Component({
  selector: 'app-articulos',
  templateUrl: './articulos.component.html'
})

export class ArticulosComponent {
  public articulos: Articulo[];

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) {
  }

  ngOnInit() {
    this.http.get<Articulo[]>(this.baseUrl + 'api/Articles')
      .subscribe(result => {
        this.articulos = result;
      }, error => console.error(error));
  }

  deleteArticle(id) {

    this.http.delete<Articulo[]>(this.baseUrl + 'api/Articles/' + id)
      .subscribe(result => {
        this.articulos = this.articulos.filter((c) => c.id !== id);
      }, error => console.error(error));
  }

}
