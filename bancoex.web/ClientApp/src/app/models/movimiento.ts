export interface Movimiento {
    id: number;
    saldo: number;
    importe: number;
    tipo: number;
    fecha?: string;
    idCuenta: number;
}