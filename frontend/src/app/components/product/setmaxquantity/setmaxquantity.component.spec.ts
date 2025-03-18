import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SetmaxquantityComponent } from './setmaxquantity.component';

describe('SetmaxquantityComponent', () => {
  let component: SetmaxquantityComponent;
  let fixture: ComponentFixture<SetmaxquantityComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SetmaxquantityComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SetmaxquantityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
