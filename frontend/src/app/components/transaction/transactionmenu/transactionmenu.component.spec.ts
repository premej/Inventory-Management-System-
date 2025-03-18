import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TransactionmenuComponent } from './transactionmenu.component';

describe('TransactionmenuComponent', () => {
  let component: TransactionmenuComponent;
  let fixture: ComponentFixture<TransactionmenuComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TransactionmenuComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TransactionmenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
