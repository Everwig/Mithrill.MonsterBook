import { inject, Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { Actions, createEffect, ofType } from '@ngrx/effects'
import { catchError, exhaustMap, map, of, switchMap, withLatestFrom } from 'rxjs';

import { State } from './npcs.reducer';
import * as fromNpcsActions from './npcs.actions';
import * as fromNpcsSelector from './npcs.selectors';
import { NpcDashboardService } from '../services/npc-dashboard.service';

@Injectable()
export class NpcsEffects {
  private actions$ = inject(Actions);
  private store$ = inject(Store<State>);

  constructor(private npcDashboardService: NpcDashboardService) { }

  loadNpcs$ = createEffect(() =>
    this.actions$.pipe(
      ofType(
        fromNpcsActions.loadNpcs,
        fromNpcsActions.pageChanged,
        fromNpcsActions.sortChanged),
      withLatestFrom(
        this.store$.select(fromNpcsSelector.pageInformationSelector),
        this.store$.select(fromNpcsSelector.sortInformationSelector)),
      exhaustMap(([_, pageInformation, sortInformation]) =>
        this.npcDashboardService.getAllNpcs(sortInformation, pageInformation.pageIndex, pageInformation.pageSize).pipe(
          map(getAllNpcsResult => fromNpcsActions.loadNpcsSuccess({ getStoredNpcsResult: getAllNpcsResult })),
          catchError(error => of(fromNpcsActions.loadNpcsFailed({ error })))
        )
      )
    )
  );

  deleteNpcs$ = createEffect(() =>
    this.actions$.pipe(
      ofType(fromNpcsActions.deleteNpc),
      switchMap(payload => this.npcDashboardService.delete(payload.npcId).pipe(
        map(_ => fromNpcsActions.loadNpcs()),
        catchError(error => of(fromNpcsActions.deleteNpcsFailed({ error })))
      ))
    )
  );
}