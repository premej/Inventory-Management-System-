import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoginComponent1 } from './login.component';

describe('LoginComponent', () => {
  let component: LoginComponent1;
  let fixture: ComponentFixture<LoginComponent1>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LoginComponent1]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LoginComponent1);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
