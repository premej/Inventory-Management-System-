import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SalesmenuComponent } from './salesmenu.component';

describe('SalesmenuComponent', () => {
  let component: SalesmenuComponent;
  let fixture: ComponentFixture<SalesmenuComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SalesmenuComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SalesmenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
