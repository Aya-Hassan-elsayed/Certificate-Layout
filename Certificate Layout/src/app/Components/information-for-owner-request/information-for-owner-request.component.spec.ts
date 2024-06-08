import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InformationForOwnerRequestComponent } from './information-for-owner-request.component';

describe('InformationForOwnerRequestComponent', () => {
  let component: InformationForOwnerRequestComponent;
  let fixture: ComponentFixture<InformationForOwnerRequestComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [InformationForOwnerRequestComponent]
    });
    fixture = TestBed.createComponent(InformationForOwnerRequestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
