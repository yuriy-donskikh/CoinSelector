import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { User } from '../../models/user';
import { SelectorState } from '../../state/selector.state';
import * as actions from '../../state/actions/selector.actions';
import * as Selector from '../../state/selector.selectors';

@Component({
  templateUrl: './user-details.component.html',
  styleUrls: ['./user-details.component.scss']
})
export class UserDetailsComponent implements OnInit {
  id:string;
  user$: Observable<User|null>|undefined; 
  user: Observable<User|null>|undefined; 
  error$: Observable<string>|undefined;

  constructor(private store: Store<SelectorState>, private router: Router, private route: ActivatedRoute) { 
    this.id =  this.route.snapshot.paramMap.get('id')||'';
  }

  ngOnInit(): void {
    this.store.dispatch(actions.getUser({id:this.id}))
    this.user$ = this.store.select(Selector.getActiveUser); 
    this.error$ = this.store.select(Selector.getError); 
  }

  refresh(curr:string){
    console.log("params: Id:" + this.id + ' curr:' + curr);
    this.store.dispatch(actions.updateUser({id:this.id, currency:curr}));
  }

  return(){
    this.router.navigate(['/'])
  }
}
