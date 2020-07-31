import { OficinasViewModel, OficinaFilterParams, Oficina } from './oficinas';

describe('Oficinas', () => {
  it('should create an instance', () => {
    expect(new Oficina()).toBeTruthy();
    expect(new OficinasViewModel()).toBeTruthy();
    expect(new OficinaFilterParams()).toBeTruthy();
    

  });
});