import { Sucursal } from "../Sucursales/sucursales";
import { Paginacion } from "../Shared/Paginacion/paginacion";

export class Usuarios {
    id:number;
    names: string;
    lastNames:string;
    userName:string;
    createAt:string;

}
export class UsuariosViewModel {
    id:number;
    names: string;
    lastNames:string;
    userName:string;
    createAt:string;
    state:state;
    createdBy:string;
    creationType:string;
    email:string;
    phoneNumber:string;
    emailConfirmed:boolean;
    userDetail:string;
    dentalBranchId:string;
    dentalBranch:string;
    // tslint:disable-next-line: no-use-before-declare

}
export class UserViewModel {
    id:number;
    names: string;
    lastNames:string;
    userName:string;
    createAt:string;
    state:state;
    createdBy:string;
    email:string;
    phoneNumber:string;
    emailConfirmed:boolean;
    userDetail:UserDetail;
    dentalBranchId:string;
    dentalBranch:Sucursal;
    // tslint:disable-next-line: no-use-before-declare

}
export class User {
    id: string;
    names: string;
    lastNames: string;
    userName: string;
    createdBy: string;
    password: string;
    phoneNumber: string;
    dentalBranchId: string;
    // tslint:disable-next-line: no-use-before-declare
}
export class UserAuthViewModel {
    expiration: string;
    expire: boolean;
    permissions: string[];
    token: string;
    unavailablePermissions?: string;
    user:User
    // tslint:disable-next-line: no-use-before-declare
}
export class UserDetail {
    id:number;
    description: string;
    identityDocument:string;
    gender:string;
    userTypeId:string;
    userId:string;
}
export class UserFilterParams extends Paginacion {
    id?:string;
    dentalBranchId: string;
    names?:string;
    lastNames?:string;
    indentityDocument?:string;
    page?:number;
    quantityByPage?:number;
}

enum state {
    Activo,
    Removido,
    Eliminado,
}
export class Enum<T> {
    public constructor(public readonly value: T) {}
    public toString() {
      return this.value.toString();
    }
  }
  