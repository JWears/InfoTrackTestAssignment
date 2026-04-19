import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InfoTrackReportPage } from './info-track-report-page';

describe('InfoTrackReportPage', () => {
  let component: InfoTrackReportPage;
  let fixture: ComponentFixture<InfoTrackReportPage>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InfoTrackReportPage],
    }).compileComponents();

    fixture = TestBed.createComponent(InfoTrackReportPage);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
