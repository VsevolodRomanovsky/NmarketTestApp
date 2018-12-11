import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { HttpClientModule } from '@angular/common/http'; 
import { ObjecttableComponent } from './components/objecttable/objecttable.component';
import { MaterialModule } from './modules/material/material.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ObjectsService } from './services/objects.service';
import { DetailsComponent } from './components/details/details.component';
import { EditComponent } from './components/edit/edit.component';
import { Routes, RouterModule } from '@angular/router';
import { DataStore } from './common/dataStore';
import { ReactiveFormsModule } from '@angular/forms';

const appRoutes: Routes = [
  { path: '', component: ObjecttableComponent },
  { path: 'edit/:id', component: EditComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    ObjecttableComponent,
    DetailsComponent,
    EditComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    HttpClientModule,
    BrowserModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    MaterialModule,
    RouterModule.forRoot(
      appRoutes,
      { enableTracing: true }
    )
  ],
  providers: [ObjectsService, DataStore],
  bootstrap: [AppComponent],
  entryComponents: [DetailsComponent]
})
export class AppModule { }
