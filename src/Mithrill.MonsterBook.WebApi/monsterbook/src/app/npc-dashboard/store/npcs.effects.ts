import { inject, Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { Actions, createEffect, ofType } from '@ngrx/effects'
import { catchError, exhaustMap, map, Observable, of, switchMap, tap, withLatestFrom } from 'rxjs';

import { State } from './npcs.reducer';
import * as fromNpcsActions from './npcs.actions';
import * as fromNpcsSelector from './npcs.selectors';
import { NpcDashboardService } from '../services/npc-dashboard.service';
import { NpcTemplateDetailsService } from '../services/npc-template-details.service';
import { DetailsViewMode } from '../../shared/models/details-view-mode.model';

@Injectable()
export class NpcsEffects {
  private actions$ = inject(Actions);
  private store$ = inject(Store<State>);
  private router = inject(Router)

  constructor(
    private npcDashboardService: NpcDashboardService,
     private npcTemplateDetailsService: NpcTemplateDetailsService) { }

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

  loadAttackTypes$ = createEffect(() =>
    this.actions$.pipe(
      ofType(fromNpcsActions.loadAttackTypes),
      switchMap(_ => this.npcTemplateDetailsService.getAttackTypes().pipe(
        map(attackTypes => fromNpcsActions.loadAttackTypesSuccess({ attackTypes })),
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

  loadHitPointMinMaxValues$ = createEffect(() =>
    this.actions$.pipe(
      ofType(fromNpcsActions.calculateHitPointMinMaxValues),
      switchMap(payload => this.npcTemplateDetailsService.getHitPointMinMaxValues(
        payload.strengthMin,
        payload.strengthMax,
        payload.bodyMin,
        payload.bodyMax,
        payload.isUndead,
        payload.meritIds
      ).pipe(
        map(({ hitPointMin, hitPointMax }) => fromNpcsActions.calculateHitPointMinMaxValuesSuccess({ hitPointMin, hitPointMax })),
        catchError(errors => of(fromNpcsActions.loadNpcTemplateFailed({ errors })))
      ))
    )
  );

  loadManaPointMinMaxValues$ = createEffect(() =>
    this.actions$.pipe(
      ofType(fromNpcsActions.calculateManaPointMinMaxValues),
      switchMap(payload => this.npcTemplateDetailsService.getManaPointMinMaxValues(
        payload.intelligenceMin,
        payload.intelligenceMax,
        payload.willpowerMin,
        payload.willpowerMax,
        payload.emotionMin,
        payload.emotionMax,
        payload.meritIds
      ).pipe(
        map(({ manaPointMin, manaPointMax }) => fromNpcsActions.calculateManaPointMinMaxValuesSuccess({ manaPointMin, manaPointMax })),
        catchError(errors => of(fromNpcsActions.loadNpcTemplateFailed({ errors })))
      ))
    )
  );

  loadPowerPointMinMaxValue$ = createEffect(() =>
    this.actions$.pipe(
      ofType(fromNpcsActions.calculatePowerPointMinMaxValues),
      switchMap(payload => this.npcTemplateDetailsService.getPowerPointMinMaxValues(payload.karmaMin, payload.karmaMax).pipe(
        map(({ powerPointMin, powerPointMax }) => fromNpcsActions.calculatePowerPointMinMaxValuesSuccess({ powerPointMin, powerPointMax })),
        catchError(errors => of(fromNpcsActions.loadNpcTemplateFailed({ errors })))
      ))
    )
  );

  saveTemplate$ = createEffect(() =>
    this.actions$.pipe(
      ofType(fromNpcsActions.saveNpcTemplate),
      switchMap(payload => {
        if (payload.detailsViewMode === DetailsViewMode.Create) {
          return this.npcTemplateDetailsService.createTemplate(payload.npcTemplate).pipe(
            tap(id => this.router.navigate([`/npcs/${id}`])),
            map(_ => fromNpcsActions.saveNpcTemplateSuccess()),
            catchError(error => of(fromNpcsActions.saveNpcTemplateFailed({ error })))
          );
        }

        return this.npcTemplateDetailsService.updateTemplate(payload.npcTemplate).pipe(
          map(_ => fromNpcsActions.saveNpcTemplateSuccess()),
          tap(_ => this.router.navigate(['/npcs'])),
          catchError(error => of(fromNpcsActions.saveNpcTemplateFailed({ error })))
        );
      })
    )
  );
}