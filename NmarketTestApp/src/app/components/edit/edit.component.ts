import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { NmarketDataSource } from '../../common/nmDataSource';
import { DataStore } from '../../common/dataStore';
import { Flat } from '@model/object.model';
import { FormBuilder, FormGroup, Validators, FormsModule, NgForm, FormControl } from '@angular/forms';
import { ObjectsService } from '../../services/objects.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss']
})
export class EditComponent implements OnInit {

  private id: number;
  private subscription: Subscription;
  private ds: NmarketDataSource;

  formData: Flat;

  objForm: FormGroup;
  totalArea: number;
  kitchenArea: number;
  price: number;

  constructor(private activateRoute: ActivatedRoute, private dataStore: DataStore,
    private fb: FormBuilder, private router: Router, private service: ObjectsService) {

    this.objForm = fb.group({
      'totalArea': [null, Validators.required],
      'kitchenArea': [null, Validators.required],
      'price': [null, Validators.required]
    });

    this.subscription = activateRoute.params.subscribe(params => this.id = params['id']);
  }

  ngOnInit() {
    this.formData = this.dataStore.storage as Flat;

    this.objForm.get('totalArea').setValue(this.formData[0].totalArea);
    this.objForm.get('kitchenArea').setValue(this.formData[0].kitchenArea);
    this.objForm.get('price').setValue(this.formData[0].price);

    console.log("edit = " + this.formData[0].id);
  }

  onFormSubmit(form: NgForm) {
    this.formData[0].totalArea = this.objForm.get('totalArea').value;
    this.formData[0].kitchenArea = this.objForm.get('kitchenArea').value;
    this.formData[0].price = this.objForm.get('price').value;

    this.service.updateObjet(this.formData[0]);
    this.return();
  }

  return() {
    this.router.navigate(['./']);
  }

}
