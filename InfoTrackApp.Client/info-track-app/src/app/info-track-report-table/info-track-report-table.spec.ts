import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InfoTrackReportTable } from './info-track-report-table';

describe('InfoTrackReportTable', () => {
  let component: InfoTrackReportTable;
  let fixture: ComponentFixture<InfoTrackReportTable>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InfoTrackReportTable],
    }).compileComponents();

    fixture = TestBed.createComponent(InfoTrackReportTable);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
