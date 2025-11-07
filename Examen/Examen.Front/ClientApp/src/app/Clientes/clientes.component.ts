import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Cliente } from './clientes';

@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.css']
})

export class ClientesComponent {
  public clientes: Cliente[];

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) {
  }

  ngOnInit() {
    this.http.get<Cliente[]>(this.baseUrl + 'api/Clients')
      .subscribe(result => {
        this.clientes = result;
      }, error => console.error(error));
  }

  deleteClient(id) {

    this.http.delete<Cliente[]>(this.baseUrl + 'api/Clients/' + id)
      .subscribe(result => {
        this.clientes = this.clientes.filter((c) => c.id !== id);
      }, error => console.error(error));
  }
}


