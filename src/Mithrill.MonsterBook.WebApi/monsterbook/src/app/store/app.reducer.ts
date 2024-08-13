import { Action, createReducer, on } from '@ngrx/store';

import * as fromUserInfoActions from './app.actions';

export interface UserInfo {
  sub: string | undefined;
  preferred_username: string;
  name: string;
  roles: string[];
}

export declare type AppReducerState = {
  languageCode: string,
  userInfo: UserInfo;
};

export const initialState: AppReducerState = {
  languageCode: 'en',
  userInfo: {
    sub: undefined,
    preferred_username: '',
    name: '',
    roles: []
  }
};

const reducer = createReducer(
  initialState,

  on(fromUserInfoActions.userInfoChanged, (state, action) => ({
    ...state,
    userInfo: action.userInfo
  })),
  on(fromUserInfoActions.logOutUserSuccess, (state, _) => ({
    ...state,
    userInfo: initialState.userInfo
  })),
  on(fromUserInfoActions.languageChanged, (state, action) => ({
    ...state,
    languageCode: action.languageCode
  }))
);

export function userInfoReducer(state: AppReducerState | undefined, action: Action): AppReducerState {
  return reducer(state, action);
}