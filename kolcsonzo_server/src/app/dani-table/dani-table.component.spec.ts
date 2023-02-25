import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DaniTableComponent } from './dani-table.component';

describe('DaniTableComponent', () => {
  let component: DaniTableComponent;
  let fixture: ComponentFixture<DaniTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DaniTableComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DaniTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
