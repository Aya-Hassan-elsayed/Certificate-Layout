import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TablesInformationAndMapComponent } from './tables-information-and-map.component';

describe('TablesInformationAndMapComponent', () => {
  let component: TablesInformationAndMapComponent;
  let fixture: ComponentFixture<TablesInformationAndMapComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TablesInformationAndMapComponent]
    });
    fixture = TestBed.createComponent(TablesInformationAndMapComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
