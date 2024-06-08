import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DescreptionMabnaComponent } from './descreption-mabna.component';

describe('DescreptionMabnaComponent', () => {
  let component: DescreptionMabnaComponent;
  let fixture: ComponentFixture<DescreptionMabnaComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DescreptionMabnaComponent]
    });
    fixture = TestBed.createComponent(DescreptionMabnaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
