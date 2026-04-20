import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import mockData from './MockData.json';

interface SolicitorResult {
  title: string;
  address: string | null;
  phone: string | null;
  website: string | null;
  rating: number | null;
  numberOfReviews: number | null;
}

@Component({
  selector: 'app-info-track-report-table',
  imports: [CommonModule],
  templateUrl: './info-track-report-table.html',
  styleUrl: './info-track-report-table.less',
})
export class InfoTrackReportTable {
  results: SolicitorResult[] = mockData;
}
