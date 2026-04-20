import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SolicitorSearchService } from '../services/solicitor-search.service';

@Component({
  selector: 'app-info-track-report-table',
  imports: [CommonModule],
  templateUrl: './info-track-report-table.html',
  styleUrl: './info-track-report-table.less',
})
export class InfoTrackReportTable {
  constructor(private readonly _solicitorSearchService: SolicitorSearchService) {
  }
  public get results()
  {
    return this._solicitorSearchService.results;
  }
}
