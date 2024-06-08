import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DescrebtionMapsComponent } from './descrebtion-maps.component';

describe('DescrebtionMapsComponent', () => {
  let component: DescrebtionMapsComponent;
  let fixture: ComponentFixture<DescrebtionMapsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DescrebtionMapsComponent]
    });
    fixture = TestBed.createComponent(DescrebtionMapsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
