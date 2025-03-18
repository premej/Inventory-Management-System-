import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetallcustomersComponent } from './getallcustomers.component';

describe('GetallcustomersComponent', () => {
  let component: GetallcustomersComponent;
  let fixture: ComponentFixture<GetallcustomersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GetallcustomersComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GetallcustomersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
