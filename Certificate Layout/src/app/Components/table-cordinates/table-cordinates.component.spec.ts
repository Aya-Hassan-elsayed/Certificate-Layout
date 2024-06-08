import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TableCordinatesComponent } from './table-cordinates.component';

describe('TableCordinatesComponent', () => {
  let component: TableCordinatesComponent;
  let fixture: ComponentFixture<TableCordinatesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TableCordinatesComponent]
    });
    fixture = TestBed.createComponent(TableCordinatesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
