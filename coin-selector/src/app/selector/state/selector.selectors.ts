import { createFeatureSelector, createSelector } from "@ngrx/store";
import { State as BaseState } from "../../state/app.state";
import { SelectorState } from "./selector.state";

export interface State extends BaseState {
    selector: SelectorState;
}

const getSelectorFeatureState = createFeatureSelector<SelectorState>('selector');

export const getUsers = createSelector(
    getSelectorFeatureState,
    state => state.users
);

export const getActiveUser = createSelector(
    getSelectorFeatureState,
    state => state.activeUser
);

export const getError = createSelector(
    getSelectorFeatureState,
    state => state.error
);