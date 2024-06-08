import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AutoCadImageComponent } from './auto-cad-image.component';

describe('AutoCadImageComponent', () => {
  let component: AutoCadImageComponent;
  let fixture: ComponentFixture<AutoCadImageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AutoCadImageComponent]
    });
    fixture = TestBed.createComponent(AutoCadImageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
