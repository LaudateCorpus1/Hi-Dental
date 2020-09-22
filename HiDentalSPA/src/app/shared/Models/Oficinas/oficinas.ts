import { Paginacion } from "../Shared/Paginacion/paginacion";

export class Oficina {
    title: string;
    address: string;
    phoneNumber: string;
    description: string;
    isPrincipal = true;
    // tslint:disable-next-line: no-use-before-declare
}
export class OficinasViewModel {
    id:number;
    title: string;
    address:string;
    phoneNumber:string;
    description:string;
    createAt:string;
    updateAt:string;
    state:number;
    // tslint:disable-next-line: no-use-before-declare
}
export class OficinaFilterParams extends Paginacion {
    title: string;
    isPrincipal=true;
    // tslint:disable-next-line: no-use-before-declare
}
