import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PurchasegetallsuppliersComponent } from './purchasegetallsuppliers.component';

describe('PurchasegetallsuppliersComponent', () => {
  let component: PurchasegetallsuppliersComponent;
  let fixture: ComponentFixture<PurchasegetallsuppliersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PurchasegetallsuppliersComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PurchasegetallsuppliersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
