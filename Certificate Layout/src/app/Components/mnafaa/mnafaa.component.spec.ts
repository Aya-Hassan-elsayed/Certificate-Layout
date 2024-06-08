import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MnafaaComponent } from './mnafaa.component';

describe('MnafaaComponent', () => {
  let component: MnafaaComponent;
  let fixture: ComponentFixture<MnafaaComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MnafaaComponent]
    });
    fixture = TestBed.createComponent(MnafaaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
