import { Component, computed, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SolicitorSearchService } from '../services/solicitor-search.service';
import { Solicitor } from '../models/solicitor';

@Component({
  selector: 'app-info-track-report-table',
  imports: [CommonModule],
  templateUrl: './info-track-report-table.html',
  styleUrl: './info-track-report-table.less',
})
export class InfoTrackReportTable {
  private _sortByRatingDesc = signal(false);

  public results = computed(() => {
    const data = this._solicitorSearchService.results();
    if (!this._sortByRatingDesc()) {
      return data;
    }
    return [...data].sort((a, b) => (b.rating ?? 0) - (a.rating ?? 0));
  });

  constructor(private readonly _solicitorSearchService: SolicitorSearchService) {}

  sortByRating(): void {
    this._sortByRatingDesc.set(!this._sortByRatingDesc());
  }
}
