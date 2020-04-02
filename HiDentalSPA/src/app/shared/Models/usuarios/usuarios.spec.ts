import { Usuarios, UsuariosViewModel, UserDetail, UserFilterParams } from './usuarios';

describe('Usuarios', () => {
  it('should create an instance', () => {
    expect(new Usuarios()).toBeTruthy();
    expect(new UsuariosViewModel()).toBeTruthy();
    expect(new UserDetail()).toBeTruthy();
    expect(new UserFilterParams()).toBeTruthy();
  });
});