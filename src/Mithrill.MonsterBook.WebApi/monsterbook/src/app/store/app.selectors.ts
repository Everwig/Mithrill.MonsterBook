import { createSelector } from '@ngrx/store';

import * as fromReducers from './index';

export const appState = (state: fromReducers.State) => state;
export const userInfoState = createSelector(appState, (state: fromReducers.State) => state.appInfo.userInfo);
export const languageCodeSelector = createSelector(appState, (state: fromReducers.State) => state.appInfo.languageCode);