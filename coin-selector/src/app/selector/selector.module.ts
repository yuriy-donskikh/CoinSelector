import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SelectorRoutingModule } from './selector-routing.module';
import { SelectorComponent } from './selector.component';

import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { StoreModule } from '@ngrx/store';
import { HttpClientModule } from '@angular/common/http';
import { EffectsModule } from '@ngrx/effects';
import { selectorReducer } from './state/selector.reducer';
import { UserListComponent } from './components/user-list/user-list.component';
import { SelectorEffects } from './state/selector.effects';
import { UserDetailsComponent } from './components/user-details/user-details.component';
import { AddUserComponent } from './components/add-user/add-user.component';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    SelectorComponent,
    UserListComponent,
    UserDetailsComponent,
    AddUserComponent
  ],
  imports: [
    CommonModule,
    SelectorRoutingModule,
    FontAwesomeModule,
    HttpClientModule,
    ReactiveFormsModule,
    StoreModule.forFeature('selector', selectorReducer),
    EffectsModule.forFeature([SelectorEffects])
  ]
})
export class SelectorModule { }
