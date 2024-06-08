import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InformationRequestAllComponent } from './information-request-all.component';

describe('InformationRequestAllComponent', () => {
  let component: InformationRequestAllComponent;
  let fixture: ComponentFixture<InformationRequestAllComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [InformationRequestAllComponent]
    });
    fixture = TestBed.createComponent(InformationRequestAllComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
