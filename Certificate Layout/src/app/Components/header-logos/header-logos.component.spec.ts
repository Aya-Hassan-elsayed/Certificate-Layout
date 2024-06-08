import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HeaderLogosComponent } from './header-logos.component';

describe('HeaderLogosComponent', () => {
  let component: HeaderLogosComponent;
  let fixture: ComponentFixture<HeaderLogosComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [HeaderLogosComponent]
    });
    fixture = TestBed.createComponent(HeaderLogosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
