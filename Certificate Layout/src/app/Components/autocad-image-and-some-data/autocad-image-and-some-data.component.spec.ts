import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AutocadImageAndSomeDataComponent } from './autocad-image-and-some-data.component';

describe('AutocadImageAndSomeDataComponent', () => {
  let component: AutocadImageAndSomeDataComponent;
  let fixture: ComponentFixture<AutocadImageAndSomeDataComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AutocadImageAndSomeDataComponent]
    });
    fixture = TestBed.createComponent(AutocadImageAndSomeDataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
