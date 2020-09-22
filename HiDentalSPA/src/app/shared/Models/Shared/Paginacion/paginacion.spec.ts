import { Paginacion } from "src/app/shared/services/HTTPClient/base.service";

describe('Usuarios', () => {
  it('should create an instance', () => {
    expect(new Paginacion()).toBeTruthy();
  });
});