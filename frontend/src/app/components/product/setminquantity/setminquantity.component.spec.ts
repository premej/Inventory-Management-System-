import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SetminquantityComponent } from './setminquantity.component';

describe('SetminquantityComponent', () => {
  let component: SetminquantityComponent;
  let fixture: ComponentFixture<SetminquantityComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SetminquantityComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SetminquantityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
