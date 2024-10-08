import { createReducer, on } from '@ngrx/store';

import { PageInformation } from '../../core/model/page-information.model';
import { SortInformation } from '../../core/model/sort-information.model';
import { Npc } from '../models/npc.model';

import * as fromRoot from '../../store';
import * as fromNpcActions from './npcs.actions';

export const npcsFeatureKey = 'npcs';

export interface State extends fromRoot.State {
  npcs: NpcsState;
}

export interface NpcsState {
  npcList: NpcListState;
}

export interface NpcListState {
  isLoading: boolean;
  npcs: Npc[];
  pageInformation: PageInformation;
  sortInformation: SortInformation;
  error: any;
}

const initialState: NpcsState = {
  npcList: {
    isLoading: true,
    npcs: [],
    pageInformation: {
      pageIndex: 0,
      pageSize: 25,
      totalCount: 0
    },
    sortInformation: {
      sortDirection: 'asc',
      sortProperty: 'name'
    },
    error: undefined
  }
}

export const reducer = createReducer(
  initialState,

  on(fromNpcActions.loadNpcsSuccess, (state, action) => ({
    ...state,
    npcList: {
      ...state.npcList,
      isLoading: false,
      npcs: action.getStoredNpcsResult.npcs,
      pageInformation: action.getStoredNpcsResult.pageInformation,
      sortInformation: action.getStoredNpcsResult.sortInformation
    }
  })),

  on(fromNpcActions.pageChanged, (state, action) => ({
    ...state,
    npcList: {
      ...state.npcList,
      isLoading: true,
      pageInformation: {
        ...state.npcList.pageInformation,
        pageIndex: action.pageIndex,
        pageSize: action.pageSize
      }
    }
  })),

  on(fromNpcActions.sortChanged, (state, action) => ({
    ...state,
    npcList: {
      ...state.npcList,
      isLoading: true,
      sortInformation: {
        ...state.npcList.sortInformation,
        sortDirection: action.sortInformation.sortDirection,
        sortProperty: action.sortInformation.sortProperty
      }
    }
  })),

  on(fromNpcActions.loadNpcsFailed, (state, action) => ({
    ...state,
    npcList: {
      ...state.npcList,
      isLoading: false,
      error: action.error
    }
  }))
);