import { Paginacion } from "../Shared/Paginacion/paginacion";

export class Sucursal {
    id:number;
    title: string;
    address:string;
    phoneNumber:string;
    description:string;
    isPrincipal:boolean;
    principalOfficeId:string;
    // tslint:disable-next-line: no-use-before-declare
}
export class SucursalesViewModel {
    id:number;
    title: string;
    address:string;
    phoneNumber:string;
    description:string;
    isPrincipal:boolean;
    officeName:string=' En espera orbi';
    principalOfficeId:string;
    createAt:string;
    updateAt:string;
    state:number;
    // tslint:disable-next-line: no-use-before-declare
}
export class SucursalFilterParams extends Paginacion {
    title?: string;
    isPrincipal=false;
    principalOfficeId:string;
    // tslint:disable-next-line: no-use-before-declare
}
