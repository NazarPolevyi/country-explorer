import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subject, takeUntil } from 'rxjs';
import { Country } from 'src/models/country';
import { Location } from '@angular/common'
import { CountryService } from 'src/services/country-service';

@Component({
  selector: 'app-country-details',
  templateUrl: './country-details.component.html',
  styleUrls: ['./country-details.component.css']
})
export class CountryDetailsComponent implements OnInit {
  public country: Country = new Country();
  private unsubscribe$ = new Subject();
  public loading = true;
  public id: any;
  constructor(
    private countryservice: CountryService,
    private route: ActivatedRoute,
    private location: Location) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.id = params['id'].split("_").join(" ");
    });

    this.countryservice.getCountry(this.id)
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe(country => {
        this.country = country;
        this.loading = false;
      });
  }

  onGoBack() {
    this.location.back();
  }
}
