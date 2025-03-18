import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetunderstockComponent } from './getunderstock.component';

describe('GetunderstockComponent', () => {
  let component: GetunderstockComponent;
  let fixture: ComponentFixture<GetunderstockComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GetunderstockComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GetunderstockComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
