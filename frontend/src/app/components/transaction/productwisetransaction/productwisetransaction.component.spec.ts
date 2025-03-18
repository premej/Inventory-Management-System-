import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductwisetransactionComponent } from './productwisetransaction.component';

describe('ProductwisetransactionComponent', () => {
  let component: ProductwisetransactionComponent;
  let fixture: ComponentFixture<ProductwisetransactionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ProductwisetransactionComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProductwisetransactionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
