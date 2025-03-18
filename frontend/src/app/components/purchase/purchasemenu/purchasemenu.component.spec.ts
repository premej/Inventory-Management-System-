import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PurchasemenuComponent } from './purchasemenu.component';

describe('PurchasemenuComponent', () => {
  let component: PurchasemenuComponent;
  let fixture: ComponentFixture<PurchasemenuComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PurchasemenuComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PurchasemenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
