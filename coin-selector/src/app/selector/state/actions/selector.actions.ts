import { createAction, props } from '@ngrx/store';
import { SetRequest } from '../../models/set-request';
import { User } from '../../models/user';
import { UserInfo } from '../../models/user-info';

export const getUsers = createAction(
    '[Selector] Get Users'
);

export const loadUsers = createAction(
    '[Selector] Load Users',
    props<{users: UserInfo[]}>()
);

export const getUser = createAction(
    '[Selector] Get User',
    props<{id: string}>()
);

export const loadUser = createAction(
    '[Selector] Load User',
    props<{user: User}>()
);

export const addUser = createAction(
    '[Selector] Add User',
    props<{request: SetRequest}>()
);

export const addUserState = createAction(
    '[Selector] Add User to State',
    props<{user: UserInfo}>()
);

export const updateUser = createAction(
    '[Selector] Update User',
    props<{id: string, currency: string}>()
);

export const deleteUser = createAction(
    '[Selector] Delete User',
    props<{id: string}>()
);

export const errorHappened = createAction(
    '[Selector] Error',
    props<{error: string}>()
);
