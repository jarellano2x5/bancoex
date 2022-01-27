export interface Cuenta {
    id: number;
    numeroCuenta: string;
    saldo: number;
    tipo: number;
    activa: boolean;
    idCliente: number;
}