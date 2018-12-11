import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ObjecttableComponent } from './objecttable.component';

describe('ObjecttableComponent', () => {
  let component: ObjecttableComponent;
  let fixture: ComponentFixture<ObjecttableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ObjecttableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ObjecttableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
