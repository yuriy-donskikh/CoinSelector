import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { UserInfo } from '../../models/user-info';
import { getUsers } from '../../state/selector.selectors';
import { SelectorState } from '../../state/selector.state';
import * as actions from '../../state/actions/selector.actions';
import { Router } from '@angular/router';

@Component({
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent implements OnInit {

  userInfo$: Observable<UserInfo[]>|undefined;

  constructor(private store: Store<SelectorState>, private router: Router) { }

  ngOnInit(): void {
    this.store.dispatch(actions.getUsers());
    this.userInfo$ = this.store.select(getUsers);
  }

  userDetails(id: string): void {
    this.router.navigate(['/userdetails', id])
  }

  deleteUser(id:string): void{
    this.store.dispatch(actions.deleteUser({id}));
  }

  newUser(): void {
    this.router.navigate(['/newuser'])
  }
}
