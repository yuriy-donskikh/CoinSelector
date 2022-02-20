import { AfterViewInit, Component, ElementRef, OnInit, ViewChildren } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl, FormArray, FormControlName } from '@angular/forms';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { SelectorState } from '../../state/selector.state';
import * as actions from '../../state/actions/selector.actions';
import { debounceTime, fromEvent, merge, Observable } from 'rxjs';

@Component({
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.scss']
})
export class AddUserComponent implements OnInit  {

  userForm: FormGroup;

  constructor(private store: Store<SelectorState>, private router: Router, private fb: FormBuilder) { 
    this.userForm = this.fb.group({});
  }

  ngOnInit(): void {
    this.userForm = this.fb.group({
      userName: ['', Validators.required],
      currency: ['BTC', Validators.required]
    });
  }

  saveUser():void{
    if (this.userForm?.valid){
        this.store.dispatch(actions.addUser({request:{name:this.userForm.value['userName'], currency:this.userForm.value['currency']}}));
        this.router.navigate(['/']);
    }
  }

}
