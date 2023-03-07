import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddPizaComponent } from './add-piza.component';

describe('AddPizaComponent', () => {
  let component: AddPizaComponent;
  let fixture: ComponentFixture<AddPizaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddPizaComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddPizaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
