import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Articulo } from './articulos';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Tienda } from '../Tiendas/tiendas';
import { ArticuloTienda } from '../Articulos/articuloTienda';

@Component({
  selector: 'app-articulos-edit',
  templateUrl: './articulos-edit.component.html'
})

export class ArticulosEditComponent {

  id?: number;
  form: FormGroup;
  articulo: Articulo;
  public tiendas: Tienda[];
  tiendasIDs: number[] = [];
  public selected: Tienda[];
  conjunto: ArticuloTienda[] = [];

  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) {
  }

  ngOnInit() {
    this.form = new FormGroup({
      codigo: new FormControl(''),
      descripcion: new FormControl(''),
      precio: new FormControl('', Validators.pattern(/^\d+(\.\d+)?$/)),
      stock: new FormControl('', Validators.pattern('^[0-9]*$'))
    }, null);

    this.http.get<Tienda[]>(this.baseUrl + 'api/Stores')
      .subscribe(result => {
        this.tiendas = result;
      }, error => console.error(error));

    this.loadData();
  }

  loadData() {

    this.id = +this.activatedRoute.snapshot.paramMap.get('id');

    if (this.id) { //Si en la ruta viene especificado un id es EDIT MODE
      var url = this.baseUrl + "api/Articles/" + this.id;

      this.http.get<Articulo>(url).subscribe(result => {
        this.articulo = result;
        this.form.patchValue(this.articulo);

      }, error => console.error(error));

      //Obtener las tiendas
      this.tiendasIDs = [];
      var url2 = this.baseUrl + "api/Articles/getTiendasArticulo/" + this.id;

      this.http.get<ArticuloTienda[]>(url2).subscribe(result => {

        var sdsdf = this.tiendas;
        //this.tiendasSelected = result;

        if (sdsdf) {
          result.forEach((value) => {
            let obj = sdsdf.find(o => o.id == value.tiendaID);
            this.tiendasIDs.push(value.tiendaID);

            if (obj)
              obj.checked = true;
          });
        }

      }, error => console.error(error));

    }

  }

  onSubmit() {
    var articulo = (this.id) ? this.articulo : <Articulo>{};

    articulo.codigo = this.form.get("codigo").value;
    articulo.descripcion = this.form.get("descripcion").value;
    articulo.precio = this.form.get("precio").value;
    articulo.stock = this.form.get("stock").value;
    articulo.tiendasIDs = this.tiendasIDs;

    if (this.id) { // EDIT mode
      var url = this.baseUrl + "api/Articles/" + this.articulo.id;

      this.http.put<Articulo>(url, articulo).subscribe(result => {
        console.log("Artículo " + articulo.id + " ha sido actualizado");

       var url2 = this.baseUrl + "api/Articles/updateTiendasArticulo/";

        var df = this.tiendasIDs;

        if (df.length > 0) {
          df.forEach((value) => {
            this.conjunto.push({ articuloID: this.articulo.id, tiendaID: value });
          });
        }

        else
          this.conjunto.push({ articuloID: this.articulo.id, tiendaID: 0 });

        this.http.post<ArticuloTienda[]>(url2, this.conjunto).subscribe(result => {
          //console.log("Artículo " + articulo.id + "ha sido creado");


          this.router.navigate(['/articulos']);
        }, error => console.log(error));

        this.router.navigate(['/articulos']);
      }, error => console.log(error));
    }

    else // ADD NEW mode
    {
      var url = this.baseUrl + "api/Articles/";

      this.http.post<Articulo>(url, articulo).subscribe(result => {
        console.log("Artículo " + articulo.id + "ha sido creado");

        this.router.navigate(['/articulos']);
      }, error => console.log(error));
    }
  }

  onCheckboxChange(option: Option): void {
    console.log(`Checkbox ${option.name} is now ${option.checked ? 'checked' : 'unchecked'}`);

    if (option.checked)
      this.tiendasIDs.push(option.id);

    else {
      const index: number = this.tiendasIDs.indexOf(option.id);

      if (index > -1) {
        this.tiendasIDs.splice(index, 1); 
      }
    }

  }

}

interface Option {
  id: number;
  name: string;
  checked: boolean;
}
