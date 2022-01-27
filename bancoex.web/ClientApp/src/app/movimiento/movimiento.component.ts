import { Component, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Movimiento } from '../models/movimiento';
import { Cliente } from '../models/cliente';
import { Cuenta } from '../models/cuenta';
import { Item } from '../models/item';

@Component({
    selector: 'app-movimiento-component',
    templateUrl: './movimiento.component.html'
})
export class MovimientoComponent {
    clis: Cliente[] = [];
    cues: Cuenta[] = [];
    tips: Item[] = [];
    movs: Movimiento[] = [];
    mov: Movimiento = { id: 0, saldo: 0, importe: 0, tipo: 1, idCuenta: 0 };
    cli: number = 0;

    constructor(private http: HttpClient, @Inject('BASE_URL') private burl: string) {
        this.http.get<Item[]>(`${this.burl}api/tipo/getmovimiento`).subscribe(resp => {
            this.tips = resp;
        }, err => console.error(err));
        this.http.get<Cliente[]>(`${this.burl}api/cliente`).subscribe(resp => {
            this.clis = resp;
        }, err => console.error(err));
    }

    refresh() {
        this.cli = 0;
        this.create(false);
    }

    clean() {
        this.changeCuenta();
        this.create(true);
    }

    create(exec: boolean) {
        let x: number = this.mov.idCuenta;
        this.mov = { id: 0, saldo: 0, importe: 0, tipo: 1, idCuenta: 0 };
        if (exec) {
            this.mov.idCuenta = x;
        }
    }

    save() {
        if (this.mov.id == 0) {
          this.http.post<Movimiento>(`${this.burl}api/movimiento`, this.mov)
          .subscribe(resp => {
            this.mov = resp;
            this.clean();
          }, err => {
              console.error(err);
              console.log(err.error.message);
          });
        }
    }

    changeCliente() {
        this.cues = [];
        if (this.cli > 0) {
            this.http.get<Cuenta[]>(`${this.burl}api/cuenta/getbycliente/${this.cli}`).subscribe(resp => {
                this.cues = resp;
            }, err => console.error(err));
        }
    }

    changeCuenta() {
        this.movs = [];
        if (this.mov.idCuenta > 0) {
            this.http.get<Movimiento[]>(`${this.burl}api/movimiento/getbycuenta/${this.mov.idCuenta}`).subscribe(resp => {
                this.movs = resp;
            }, err => {
                console.error(err);
                alert(err.message);
            });
        }
    }

    showCuenta(id: number) {
        return this.cues.filter(e => e.id == id)[0].numeroCuenta;
    }

    showSaldo(s: number, i: number, t: number) {
        if (t == 1) {
            return s - i;
        } else {
            return s + i;
        }
    }
}