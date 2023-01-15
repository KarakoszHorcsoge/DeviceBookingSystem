import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuthorotyComponent } from './authoroty.component';

describe('AuthorotyComponent', () => {
  let component: AuthorotyComponent;
  let fixture: ComponentFixture<AuthorotyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AuthorotyComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AuthorotyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
