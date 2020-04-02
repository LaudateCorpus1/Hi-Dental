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
export class UserDetail {
    id:number;
    description: string;
    identityDocument:string;
    gender:string;
    userTypeId:string;
    userId:string;
}
export class UserFilterParams {
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
  