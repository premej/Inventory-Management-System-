import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetoverstockComponent } from './getoverstock.component';

describe('GetoverstockComponent', () => {
  let component: GetoverstockComponent;
  let fixture: ComponentFixture<GetoverstockComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GetoverstockComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GetoverstockComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
