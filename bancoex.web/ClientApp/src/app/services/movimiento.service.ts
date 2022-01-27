import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Movimiento } from '../models/movimiento';

@Injectable({
    providedIn: 'root'
})
export class MovimientoService {

    constructor(private http: HttpClient, @Inject('BASE_URL') private burl: string) {}

    /*
    postMovs(prm: Movimiento): Observable<Movimiento> {
        return this.http.post<Movimiento>()
    }
    */
}