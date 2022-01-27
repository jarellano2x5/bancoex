import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Cliente } from '../models/cliente';

@Component({
  selector: 'app-cliente-component',
  templateUrl: './cliente.component.html'
})
export class ClienteComponent {
  show: boolean = true;
  clis: Cliente[] = [];
  cli: Cliente = Object.create(null);
  sel: Cliente = Object.create(null);
  
  constructor(private http: HttpClient, @Inject("BASE_URL") private burl: string)
  {
    this.clientes();
  }

  clientes() {
    this.http.get<Cliente[]>(`${this.burl}api/cliente`).subscribe(resp => {
      this.clis = resp;
    }, err => console.error(err));
  }

  create() {
    this.cli = { id: 0, identificacion: '', nombre: '', activo: true };
    this.show = false;
  }

  edit(item: Cliente) {
    this.cli = item;
    this.show = false;
  }

  save() {
    if (this.cli.id == 0) {
      this.http.post<Cliente>(`${this.burl}api/cliente`, this.cli).subscribe(resp => {
        this.cli = resp;
        this.refresh();
      }, err => console.error(err));
    } else {
      this.http.put<Cliente>(`${this.burl}api/cliente/${this.cli.id}`, this.cli).subscribe(resp => {
        this.cli = resp;
        this.refresh();
      }, err => console.error(err));
    }
  }

  refresh() {
    this.show = true;
    this.clientes();
  }

  select(item: Cliente) {
    this.sel = item;
  }

}

