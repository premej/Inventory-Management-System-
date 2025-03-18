import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StockmenuComponent } from './stockmenu.component';

describe('StockmenuComponent', () => {
  let component: StockmenuComponent;
  let fixture: ComponentFixture<StockmenuComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [StockmenuComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StockmenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
