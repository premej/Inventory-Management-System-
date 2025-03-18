import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetcurrentstockComponent } from './getcurrentstock.component';

describe('GetcurrentstockComponent', () => {
  let component: GetcurrentstockComponent;
  let fixture: ComponentFixture<GetcurrentstockComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GetcurrentstockComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GetcurrentstockComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
