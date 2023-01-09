import { Component, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AgGridAngular } from 'ag-grid-angular';
import { CellClickedEvent, ColDef, GridApi, GridReadyEvent } from 'ag-grid-community';
import { Observable } from 'rxjs';
import { Country } from 'src/models/country';
import { CountryService } from 'src/services/country-service';

@Component({
  selector: 'app-country',
  templateUrl: './country.component.html',
  styleUrls: ['./country.component.css']
})
export class CountryComponent {
  private gridApi!: GridApi;

  public columnDefs: ColDef[] = [
    {
      field: 'name', minWidth: 460, getQuickFilterText: params => {
        return params.value.name;
      }
    },
    { field: 'capital', minWidth: 350 },
    { field: 'currency', minWidth: 350 },
    { field: 'language', minWidth: 350 },
    { field: 'region', minWidth: 350 },

  ];

  public defaultColDef: ColDef = {
    sortable: true,
    filter: true,
  };

  public rowData$!: Observable<Country[]>;

  @ViewChild(AgGridAngular) agGrid!: AgGridAngular;

  constructor(
    private countryservice: CountryService,
    private route: ActivatedRoute,
    private router: Router) { }

  onGridReady(params: GridReadyEvent) {
    this.gridApi = params.api;
    this.rowData$ = this.countryservice.getCountries();
  }

  onFilterTextBoxChanged() {
    this.gridApi.setQuickFilter(
      (document.getElementById('filter-text-box') as HTMLInputElement).value
    );
  }

  onCellClicked(e: CellClickedEvent): void {
    this.router.navigate([e.data.name.toLowerCase().split(" ").join("_")], { relativeTo: this.route });
  }
}
