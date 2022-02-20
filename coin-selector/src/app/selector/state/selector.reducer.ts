import { createReducer, on } from "@ngrx/store";
import * as actions from "./actions/selector.actions";
import { SelectorState } from "./selector.state";

const initialState: SelectorState = {
    users: [],
    activeUser: null,
    error: '' 
}

export const selectorReducer = createReducer<SelectorState>(
    initialState,
    on(actions.loadUsers, (state, action): SelectorState => {
        return {
            ... state,
            users: action.users
        }
    }),
    on(actions.loadUser, (state, action): SelectorState => {
        return {
            ... state,
            activeUser: action.user
        }
    }),
    on(actions.addUserState, (state, action): SelectorState => {
        return {
            ... state,
            users: [...state.users, action.user] 
        }
    }),
    on(actions.errorHappened, (state, action): SelectorState => {
        return {
            ... state,
            error: action.error 
        }
    })
);