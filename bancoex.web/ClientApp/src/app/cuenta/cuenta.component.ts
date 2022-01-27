import { Component, Inject, Input, OnChanges, SimpleChanges } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Cuenta } from '../models/cuenta';
import { Item } from '../models/item';
declare var $: any;

@Component({
    selector: 'cuenta-component',
    templateUrl: './cuenta.component.html'
})
export class CuentaComponent implements OnChanges {
    @Input() value: any;
    ctas: Cuenta[] = [];
    cta: Cuenta = Object.create(null);
    show: boolean = true;
    tips: Item[] = [];

    constructor(private http: HttpClient, @Inject("BASE_URL") private burl: string)
    {
        http.get<Item[]>(`${burl}api/tipo/getcuenta`).subscribe(resp => {
            this.tips = resp;
        }, err => console.error(err));
    }

    cuentas() {
        let cliente: number = this.value.id == undefined ? 0 : this.value.id;
        this.http.get<Cuenta[]>(`${this.burl}api/cuenta/getbycliente/${cliente}`).subscribe(resp => {
        this.ctas = resp;
        }, err => console.error(err));
    }

    create() {
        this.cta = { id: 0, numeroCuenta: '', saldo: 0, tipo: 0, activa: true, idCliente: this.value.id };
        this.show = false;
    }

    edit(item: Cuenta) {
        this.cta = item;
        this.show = false;
    }

    save() {
        if (this.cta.id == 0) {
            this.http.post<Cuenta>(`${this.burl}api/cuenta`, this.cta).subscribe(resp => {
                this.cta = resp;
                this.refresh();
            }, err => console.error(err));
        } else {
            this.http.put<Cuenta>(`${this.burl}api/cuenta/${this.cta.id}`, this.cta).subscribe(resp => {
                this.cta = resp;
                this.refresh();
            }, err => console.error(err));
        }
    }

    refresh() {
        this.show = true;
        this.cuentas();
    }

    hideModal() {
        $('#modalCuenta').modal('hide');
    }

    ngOnChanges(): void {
        this.cuentas();
    }
}