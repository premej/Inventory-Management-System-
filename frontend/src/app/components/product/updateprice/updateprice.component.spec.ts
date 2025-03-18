import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdatepriceComponent } from './updateprice.component';

describe('UpdatepriceComponent', () => {
  let component: UpdatepriceComponent;
  let fixture: ComponentFixture<UpdatepriceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UpdatepriceComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UpdatepriceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
