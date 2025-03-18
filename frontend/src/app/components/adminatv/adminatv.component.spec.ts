import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminatvComponent } from './adminatv.component';

describe('AdminatvComponent', () => {
  let component: AdminatvComponent;
  let fixture: ComponentFixture<AdminatvComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AdminatvComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AdminatvComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
