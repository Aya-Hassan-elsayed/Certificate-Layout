import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HeaderAdresessComponent } from './header-adresess.component';

describe('HeaderAdresessComponent', () => {
  let component: HeaderAdresessComponent;
  let fixture: ComponentFixture<HeaderAdresessComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [HeaderAdresessComponent]
    });
    fixture = TestBed.createComponent(HeaderAdresessComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
