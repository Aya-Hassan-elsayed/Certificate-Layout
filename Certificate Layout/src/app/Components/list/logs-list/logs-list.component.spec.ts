import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LogsListComponent } from './logs-list.component';

describe('LogsListComponent', () => {
  let component: LogsListComponent;
  let fixture: ComponentFixture<LogsListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [LogsListComponent]
    });
    fixture = TestBed.createComponent(LogsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
