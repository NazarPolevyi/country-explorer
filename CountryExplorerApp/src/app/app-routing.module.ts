import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CountryDetailsComponent } from './country-details/country-details.component';
import { CountryComponent } from './country/country.component';

const routes: Routes = [
  { path: '', redirectTo: "countries", pathMatch: 'full' },
  { path: 'countries', component: CountryComponent },
  { path: 'countries/:id', component: CountryDetailsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
