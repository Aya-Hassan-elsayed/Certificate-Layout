import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InformationRequestComponent } from './information-request.component';

describe('InformationRequestComponent', () => {
  let component: InformationRequestComponent;
  let fixture: ComponentFixture<InformationRequestComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [InformationRequestComponent]
    });
    fixture = TestBed.createComponent(InformationRequestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
