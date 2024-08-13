import { ActionReducerMap, MetaReducer } from '@ngrx/store';

import * as fromUserInfo from './app.reducer';

export interface State {
  appInfo: fromUserInfo.AppReducerState;
}

export const reducers: ActionReducerMap<State> = {
  appInfo: fromUserInfo.userInfoReducer
}

export const metaReducers: MetaReducer<State>[] = [];