import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PacienteNuevoComponent } from './paciente-nuevo.component';

describe('PacienteNuevoComponent', () => {
  let component: PacienteNuevoComponent;
  let fixture: ComponentFixture<PacienteNuevoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PacienteNuevoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PacienteNuevoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
