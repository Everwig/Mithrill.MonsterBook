import { createAction, props } from '@ngrx/store';

import { UserInfo } from './app.reducer';

export const userInfoChanged = createAction('[UserInfo] User Info Changed', props<{ userInfo: UserInfo }>());

export const logOutUser = createAction('[UserInfo] Log Out User');
export const logOutUserSuccess = createAction('[UserInfo] Log Out User Success');

export const languageChanged = createAction('[AppInfo] Language changed', props<{ languageCode: string }>());