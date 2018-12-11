import { Component, OnInit, ViewChild, ChangeDetectorRef } from '@angular/core';
import { ObjectsService } from '../../services/objects.service';
import { MatPaginator, MatSort, MatDialog, PageEvent, MatDialogConfig } from '@angular/material';
import { NmarketDataSource } from '../../common/nmDataSource';
import { DataStore } from '../../common/dataStore';
import { DetailsComponent } from '@component/details/details.component';
import { Router } from "@angular/router"
import { MatIconRegistry } from '@angular/material';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-objecttable',
  templateUrl: './objecttable.component.html',
  styleUrls: ['./objecttable.component.scss']
})
export class ObjecttableComponent implements OnInit {

  dataSource: NmarketDataSource;


  length: number;
  pageSize: number = 20;
  tableColumns: string[] = ['flatId', 'RoomsCount', 'TotalArea',
    'KitchenArea', 'Floor', 'Price', 'Building.Name',
    'Building.Queue', 'Building.Housing', 'actions'];

  constructor(private objectService: ObjectsService, public dialog: MatDialog,
    private router: Router, private dataStore: DataStore,
    iconRegistry: MatIconRegistry, sanitizer: DomSanitizer, private changeDetectorRefs: ChangeDetectorRef) {
    iconRegistry.addSvgIcon(
      'edit',
      sanitizer.bypassSecurityTrustResourceUrl('../../../assets/edit.svg'));
    iconRegistry.addSvgIcon(
      'details',
      sanitizer.bypassSecurityTrustResourceUrl('../../../assets/details.svg'));
    iconRegistry.addSvgIcon(
      'delete',
      sanitizer.bypassSecurityTrustResourceUrl('../../../assets/delete.svg'));
  }

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  ngOnInit() {
    this.dataSource = new NmarketDataSource(this.objectService, this.sort, this.paginator);
  }

  openDetails(flatId: number) {
    console.log(flatId);
    const dialogConfig = new MatDialogConfig();

    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    let flat = this.dataSource.cache$.filter(u => u.flatId === flatId);
    dialogConfig.data = {
      data: flat
    };

    this.dialog.open(DetailsComponent, dialogConfig);
  }

  editDetails(flatId: number) {
    this.dataStore.storage = this.dataSource.cache$.filter(u => u.flatId === flatId);
    this.router.navigate(['/edit', flatId]);
  }

  deleteObject(flatId: number) {
    this.dataSource.deleteObject(flatId).subscribe((res) => {
      this.dataSource = new NmarketDataSource(this.objectService, this.sort, this.paginator);
      this.changeDetectorRefs.detectChanges();
    });
  }

  pageSizeOptions: number[] = [5, 10, 20];

  // MatPaginator Output
  pageEvent: PageEvent;

  setPageSizeOptions(setPageSizeOptionsInput: string) {
    this.pageSizeOptions = setPageSizeOptionsInput.split(',').map(str => +str);
  }
}
