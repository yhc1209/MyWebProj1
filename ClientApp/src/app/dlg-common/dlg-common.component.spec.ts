import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DlgCommonComponent } from './dlg-common.component';

describe('DlgCommonComponent', () => {
  let component: DlgCommonComponent;
  let fixture: ComponentFixture<DlgCommonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DlgCommonComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DlgCommonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
