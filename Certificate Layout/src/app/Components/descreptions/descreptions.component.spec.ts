import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DescreptionsComponent } from './descreptions.component';

describe('DescreptionsComponent', () => {
  let component: DescreptionsComponent;
  let fixture: ComponentFixture<DescreptionsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DescreptionsComponent]
    });
    fixture = TestBed.createComponent(DescreptionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
