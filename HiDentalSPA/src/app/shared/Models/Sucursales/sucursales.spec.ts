import { SucursalesViewModel, SucursalFilterParams, Sucursal } from "./sucursales";

describe('Usuarios', () => {
  it('should create an instance', () => {
    expect(new Sucursal()).toBeTruthy();
    expect(new SucursalesViewModel()).toBeTruthy();
    expect(new SucursalFilterParams()).toBeTruthy();
  });
});