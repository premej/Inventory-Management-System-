import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetallcategoriesComponent } from './getallcategories.component';

describe('GetallcategoriesComponent', () => {
  let component: GetallcategoriesComponent;
  let fixture: ComponentFixture<GetallcategoriesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GetallcategoriesComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GetallcategoriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
