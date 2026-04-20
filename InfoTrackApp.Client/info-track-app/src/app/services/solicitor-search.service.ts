import { Injectable, inject, signal } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Solicitor } from '../models/solicitor';

@Injectable({ providedIn: 'root' })
export class SolicitorSearchService {
  private http = inject(HttpClient);

  readonly results = signal<Solicitor[]>([]);
  readonly loading = signal(false);
  readonly error = signal<string | null>(null);

  search(practiceArea: string, location: string): void {
    this.loading.set(true);
    this.error.set(null);

    const params = new HttpParams()
      .set('practiceArea', practiceArea)
      .set('location', location);

    this.http
      .get<Solicitor[]>(`${environment.apiBaseUrl}/SolicitorSearch/GetSolicitorData`, { params })
      .subscribe({
        next: (results) => {
          this.results.set(results);
          this.loading.set(false);
        },
        error: () => {
          this.error.set('Search failed');
          this.loading.set(false);
        },
      });
  }
}
