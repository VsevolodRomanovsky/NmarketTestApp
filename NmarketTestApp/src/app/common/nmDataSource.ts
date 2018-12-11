import { DataSource } from "@angular/cdk/collections";
import { Flat } from '@model/object.model';
import { ObjectsService } from '../services/objects.service';
import { Observable, BehaviorSubject, of, merge } from 'rxjs';
import { catchError, startWith, switchMap, map, finalize } from 'rxjs/operators';
import { MatPaginator, MatSort } from '@angular/material';

export class NmarketDataSource extends DataSource<Flat> {
  resultsLength = 0;
  isLoadingResults = true;
  isRateLimitReached = false;
  cache$: Flat[];
  displayDataChanges: any[];


  constructor(private nmarketService: ObjectsService,
    private sort: MatSort,
    private paginator: MatPaginator) {
    super();
  }


  deleteObject(flatId: number): Observable<Flat[]> {
    return merge(...this.displayDataChanges)
      .pipe(
        startWith(null),
      switchMap(() => {
          return this.nmarketService.deleteObject(flatId)
        }),
        map(data => {
          this.isLoadingResults = false;
          this.isRateLimitReached = false;
          this.resultsLength = data.rowCount;
          this.cache$ = data.results;
          return data.results;
        }),
        catchError(() => {
          this.isLoadingResults = false;
          this.isRateLimitReached = true;
          return of([]);
        })
      );
  }

   connect(): Observable<Flat[]> {
      this.displayDataChanges = [
      this.sort.sortChange,
      this.paginator.page
    ];

    this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);


    return merge(...this.displayDataChanges)
      .pipe(
        startWith(null),
        switchMap(() => {
          return this.nmarketService.getObjects(
            this.sort.active,
            this.sort.direction, 
            this.paginator.pageIndex+1,
            this.paginator.pageSize)
        }),
        map(data => {
          this.isLoadingResults = false;
          this.isRateLimitReached = false;
          this.resultsLength = data.rowCount;
          this.cache$ = data.results;
          return data.results;
        }),
        catchError(() => {
          this.isLoadingResults = false;
          this.isRateLimitReached = true;
          return of([]);
      })
     );
  }

  disconnect() { }
}
