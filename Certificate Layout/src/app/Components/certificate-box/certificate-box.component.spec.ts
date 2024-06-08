import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CertificateBoxComponent } from './certificate-box.component';

describe('CertificateBoxComponent', () => {
  let component: CertificateBoxComponent;
  let fixture: ComponentFixture<CertificateBoxComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CertificateBoxComponent]
    });
    fixture = TestBed.createComponent(CertificateBoxComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
