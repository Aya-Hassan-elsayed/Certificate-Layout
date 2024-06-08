import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DescreptionArdComponent } from './descreption-ard.component';

describe('DescreptionArdComponent', () => {
  let component: DescreptionArdComponent;
  let fixture: ComponentFixture<DescreptionArdComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DescreptionArdComponent]
    });
    fixture = TestBed.createComponent(DescreptionArdComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
