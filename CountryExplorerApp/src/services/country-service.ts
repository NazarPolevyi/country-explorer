import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { map } from 'rxjs/operators';
import { catchError } from 'rxjs/internal/operators/catchError';
import { HttpClient } from '@angular/common/http';
import { Country } from 'src/models/country';
import { environment } from './../environments/environment';

@Injectable({
    providedIn: 'root'
})
export class CountryService {
    constructor(private httpClient: HttpClient) { }

    getCountries(): Observable<Country[]> {
        return this.httpClient.get(`${environment.apiUrl}/country`)
            .pipe(
                map((response: any) => response),
                catchError(this.handleError)
            );
    }

    getCountry(name: string): Observable<Country> {
        return this.httpClient.get(`${environment.apiUrl}/country/${name}`)
            .pipe(
                map((response: any) => response),
                catchError(this.handleError)
            );
    }

    private handleError(error: any) {
        return throwError(error);
    }
}