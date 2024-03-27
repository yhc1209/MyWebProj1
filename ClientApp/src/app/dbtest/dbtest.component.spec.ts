import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DBtestComponent } from './dbtest.component';

describe('DBtestComponent', () => {
  let component: DBtestComponent;
  let fixture: ComponentFixture<DBtestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DBtestComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DBtestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
