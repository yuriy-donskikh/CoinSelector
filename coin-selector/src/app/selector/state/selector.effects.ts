import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import * as actions from "./actions/selector.actions"; 
import { catchError, concatMap, map, of, tap } from "rxjs";
import { CoinSelectorService } from "../services/coin-selector.service";

@Injectable()
export class SelectorEffects{
    constructor(private actions$: Actions, private coinSelectorService: CoinSelectorService){}

    getAllUsers$ = createEffect(()=>{
        return this.actions$
            .pipe(
                ofType(actions.getUsers),
                concatMap(()=>
                    this.coinSelectorService.getAllUsers()
                    .pipe(
                        tap(()=>actions.errorHappened({error:""})),
                        map((users)=>actions.loadUsers({ users })),
                        catchError((error)=>of(actions.errorHappened({error: error.message})))
                    )
                )
            )
    });

    getUser$ = createEffect(()=>{
        return this.actions$
            .pipe(
                ofType(actions.getUser),
                concatMap((param)=>
                    this.coinSelectorService.getUser(param.id)
                    .pipe(
                        tap(()=>actions.errorHappened({error:""})),
                        map((user)=>actions.loadUser({user})),
                        catchError((error)=>of(actions.errorHappened({error: error.message})))
                    )
                )
            )
    });

    addUser$ = createEffect(()=>{
        return this.actions$
            .pipe(
                ofType(actions.addUser),
                concatMap((params)=>
                    this.coinSelectorService.addUser(params.request)
                    .pipe(
                        tap(()=>actions.errorHappened({error:""})),
                        map((user)=>actions.addUserState({user})),
                        catchError((error)=>of(actions.errorHappened({error: error.message})))
                    )
                )
            )
    });

    updateUser$ = createEffect(()=>{
        return this.actions$
            .pipe(
                ofType(actions.updateUser),
                concatMap((params)=>
                    this.coinSelectorService.updateUser(params.id, params.currency)
                    .pipe(
                        tap(()=>actions.errorHappened({error:""})),
                        map(()=>actions.getUser({id:params.id})),
                        catchError((error)=>of(actions.errorHappened({error: error.message})))
                    )    
                )
            )
    });

    deleteUser$ = createEffect(()=>{
        return this.actions$
            .pipe(
                ofType(actions.deleteUser),
                concatMap((params)=>
                    this.coinSelectorService.deleteUser(params.id)
                    .pipe(
                        tap(()=>actions.errorHappened({error:""})),
                        map(()=>actions.getUsers()),
                        catchError((error)=>of(actions.errorHappened({error: error.message})))
                    )    
                )
            )
    });
} 