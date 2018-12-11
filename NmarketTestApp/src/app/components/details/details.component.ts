import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Flat } from '@model/object.model';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.scss']
})
export class DetailsComponent implements OnInit {

  flat: Flat;

  constructor(private matDialogRef: MatDialogRef<DetailsComponent>, @Inject(MAT_DIALOG_DATA) public data: any) {
    console.log(data.data[0]);
    this.flat = data.data[0];
  }
  

  ngOnInit() {
  }

  close() {
    this.matDialogRef.close();
  }

}
