import {Component, signal} from '@angular/core';
import {InfoTrackReportTable} from './info-track-report-table/info-track-report-table';
import {InfoTrackSearchBox} from './info-track-search-box/info-track-search-box';

@Component({
  selector: 'app-root',
  imports: [InfoTrackReportTable, InfoTrackSearchBox],
  templateUrl: './app.html',
  styleUrl: './app.less'
})
export class App {
  protected readonly title = signal('info-track-scraper-client');
}
