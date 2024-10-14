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
);

export const sortInformationSelector = createSelector(
  npcsFeatureState,
  (state: fromNpcsReducer.NpcsState) => state.npcList.sortInformation
);

export const armorsSelector = createSelector(
  npcsFeatureState,
  (state: fromNpcsReducer.NpcsState) => state.npcTemplate.armors
);

export const weaponsSelector = createSelector(
  npcsFeatureState,
  (state: fromNpcsReducer.NpcsState) => state.npcTemplate.weapons
);

export const flawsSelector = createSelector(
  npcsFeatureState,
  (state: fromNpcsReducer.NpcsState) => state.npcTemplate.flaws
);

export const meritsSelector = createSelector(
  npcsFeatureState,
  (state: fromNpcsReducer.NpcsState) => state.npcTemplate.merits
);

export const skillsSelector = createSelector(
  npcsFeatureState,
  (state: fromNpcsReducer.NpcsState) => state.npcTemplate.skills
);

export const attackTypesSelector = createSelector(
  npcsFeatureState,
  (state: fromNpcsReducer.NpcsState) => state.npcTemplate.attackTypes
);

export const hitPointMin = createSelector(
  npcsFeatureState,
  (state: fromNpcsReducer.NpcsState) => state.npcTemplate.hitPointMin
);

export const hitPointMax = createSelector(
  npcsFeatureState,
  (state: fromNpcsReducer.NpcsState) => state.npcTemplate.hitPointMax
);

export const manaPointMin = createSelector(
  npcsFeatureState,
  (state: fromNpcsReducer.NpcsState) => state.npcTemplate.manaPointMin
);

export const manaPointMax = createSelector(
  npcsFeatureState,
  (state: fromNpcsReducer.NpcsState) => state.npcTemplate.manaPointMax
);

export const powerPointMin = createSelector(
  npcsFeatureState,
  (state: fromNpcsReducer.NpcsState) => state.npcTemplate.powerPointMin
);

export const powerPointMax = createSelector(
  npcsFeatureState,
  (state: fromNpcsReducer.NpcsState) => state.npcTemplate.powerPointMax
);

export const npcTemplateSelector = createSelector(
  npcsFeatureState,
  (state: fromNpcsReducer.NpcsState) => state.npcTemplate.template
);