import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CertificateFoldersPathesComponent } from './certificate-folders-pathes.component';

describe('CertificateFoldersPathesComponent', () => {
  let component: CertificateFoldersPathesComponent;
  let fixture: ComponentFixture<CertificateFoldersPathesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CertificateFoldersPathesComponent]
    });
    fixture = TestBed.createComponent(CertificateFoldersPathesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
