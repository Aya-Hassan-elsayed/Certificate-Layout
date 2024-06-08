import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TableEdgesComponent } from './table-edges.component';

describe('TableEdgesComponent', () => {
  let component: TableEdgesComponent;
  let fixture: ComponentFixture<TableEdgesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TableEdgesComponent]
    });
    fixture = TestBed.createComponent(TableEdgesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
