import { createFeatureSelector, createSelector } from '@ngrx/store';

import * as fromNpcsReducer from './npcs.reducer';

const npcsFeatureState = createFeatureSelector<fromNpcsReducer.NpcsState>(fromNpcsReducer.npcsFeatureKey);
export const isLoadingSelector = createSelector(
  npcsFeatureState,
  (state: fromNpcsReducer.NpcsState) => state.npcList.isLoading
);

export const npcsSelector = createSelector(
  npcsFeatureState,
  (state: fromNpcsReducer.NpcsState) => state.npcList.npcs
);

export const pageInformationSelector = createSelector(
  npcsFeatureState,
  (state: fromNpcsReducer.NpcsState) => state.npcList.pageInformation
)

export const sortInformationSelector = createSelector(
  npcsFeatureState,
  (state: fromNpcsReducer.NpcsState) => state.npcList.sortInformation
);