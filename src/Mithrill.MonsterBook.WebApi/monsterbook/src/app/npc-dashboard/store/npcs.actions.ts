import { createAction, props } from '@ngrx/store';
import { PageInformation } from '../../core/model/page-information.model';
import { SortInformation } from '../../core/model/sort-information.model';
import { GetStoredNpcsResult } from '../model/get-stored-npcs-result.model';

export const loadNpcs = createAction('[NPCs] Load NPCs');
export const loadNpcsSuccess = createAction(
  '[NPCs] Loaded NPCs successfully',
  props<{ getStoredNpcsResult: GetStoredNpcsResult }>()
);
export const loadNpcsFailed = createAction(
  '[NPCs] Load NPCs failed',
  props<{ error: any }>()
);

export const pageChanged = createAction(
  '[NPCs] Page changed',
  props<{ pageSize: number, pageIndex: number }>()
);

export const sortChanged = createAction(
  '[NPCs] Sort changed',
  props<{ sortInformation: SortInformation }>()
);

export const deleteNpc = createAction(
  '[NPCs] Delete template',
  props<{ npcId: number }>()
);
export const deleteNpcsFailed = createAction(
  '[NPCs] Delete NPCs failed',
  props<{ error: any }>()
);