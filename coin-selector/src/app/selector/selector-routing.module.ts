import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddUserComponent } from './components/add-user/add-user.component';
import { UserDetailsComponent } from './components/user-details/user-details.component';
import { UserListComponent } from './components/user-list/user-list.component';
import { SelectorComponent } from './selector.component';

const routes: Routes = [
  { 
    path: '', component: SelectorComponent,
    children: [
      { path: '', component: UserListComponent },
      { path: 'userdetails/:id', component: UserDetailsComponent},
      { path: 'newuser', component: AddUserComponent}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SelectorRoutingModule { }
