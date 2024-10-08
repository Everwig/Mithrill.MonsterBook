import { inject, Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { Actions, createEffect, ofType } from '@ngrx/effects'
import { catchError, exhaustMap, map, of, switchMap, withLatestFrom } from 'rxjs';

import { State } from './npcs.reducer';
import * as fromNpcsActions from './npcs.actions';
import * as fromNpcsSelector from './npcs.selectors';
import { NpcDashboardService } from '../services/npc-dashboard.service';
import { NpcTemplateDetailsService } from '../services/npc-template-details.service';

@Injectable()
export class NpcsEffects {
  private actions$ = inject(Actions);
  private store$ = inject(Store<State>);

  constructor(private npcDashboardService: NpcDashboardService, private npcTemplateDetailsService: NpcTemplateDetailsService) { }

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

  loadArmors$ = createEffect(() =>
    this.actions$.pipe(
      ofType(fromNpcsActions.loadArmors),
      switchMap(_ => this.npcTemplateDetailsService.getArmors().pipe(
        map(armors => fromNpcsActions.loadArmorsSuccess({ armors })),
        catchError(errors => of(fromNpcsActions.loadNpcTemplateFailed({ errors })))
      ))
    )
  );

  loadWeapons$ = createEffect(() =>
    this.actions$.pipe(
      ofType(fromNpcsActions.loadWeapons),
      switchMap(_ => this.npcTemplateDetailsService.getWeapons().pipe(
        map(weapons => fromNpcsActions.loadWeaponsSuccess({ weapons })),
        catchError(errors => of(fromNpcsActions.loadNpcTemplateFailed({ errors })))
      ))
    )
  );

  loadMerits$ = createEffect(() =>
    this.actions$.pipe(
      ofType(fromNpcsActions.loadMerits),
      switchMap(_ => this.npcTemplateDetailsService.getMerits().pipe(
        map(merits => fromNpcsActions.loadMeritsSucccess({ merits })),
        catchError(errors => of(fromNpcsActions.loadNpcTemplateFailed({ errors })))
      ))
    )
  );

  loadFlaws$ = createEffect(() =>
    this.actions$.pipe(
      ofType(fromNpcsActions.loadFlaws),
      switchMap(_ => this.npcTemplateDetailsService.getFlaws().pipe(
        map(flaws => fromNpcsActions.loadFlawsSuccess({ flaws })),
        catchError(errors => of(fromNpcsActions.loadNpcTemplateFailed({ errors })))
      ))
    )
  );

  loadSkills$ = createEffect(() =>
    this.actions$.pipe(
      ofType(fromNpcsActions.loadSkills),
      switchMap(_ => this.npcTemplateDetailsService.getSkills().pipe(
        map(skills => fromNpcsActions.loadSkillsSuccess({ skills })),
        catchError(errors => of(fromNpcsActions.loadNpcTemplateFailed({ errors })))
      ))
    )
  );

  loadNpcTemplate$ = createEffect(() =>
    this.actions$.pipe(
      ofType(fromNpcsActions.loadNpcTemplate),
      switchMap(payload => this.npcTemplateDetailsService.getNpcTemplate(payload.id).pipe(
        map(npcTemplate => fromNpcsActions.loadNpcTemplateSuccess({ npcTemplate })),
        catchError(errors => of(fromNpcsActions.loadNpcTemplateFailed({ errors })))
      ))
    )
  );
}