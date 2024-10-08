import { createReducer, on } from '@ngrx/store';

import { PageInformation } from '../../core/model/page-information.model';
import { SortInformation } from '../../core/model/sort-information.model';
import { Npc } from '../models/npc.model';

import * as fromRoot from '../../store';
import * as fromNpcActions from './npcs.actions';
import { Weapon } from '../models/weapon.model';
import { Armor } from '../models/armor.model';
import { Flaw } from '../models/flaw.model';
import { Merit } from '../models/merit.model';
import { Skill } from '../models/skill.model';

export const npcsFeatureKey = 'npcs';

export interface State extends fromRoot.State {
  npcs: NpcsState;
}

export interface NpcsState {
  npcList: NpcListState;
  npcTemplate: NpcTemplate;
}

export interface NpcListState {
  isLoading: boolean;
  npcs: Npc[];
  pageInformation: PageInformation;
  sortInformation: SortInformation;
  error: any;
}

export interface NpcTemplate {
  weapons: Weapon [];
  armors: Armor[];
  flaws: Flaw[];
  merits: Merit[];
  skills: Skill[];
  npc: Npc | undefined;
  isLoading: boolean;
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
  },
  npcTemplate: {
    armors: [],
    flaws: [],
    merits: [],
    skills: [],
    weapons: [],
    npc: undefined,
    isLoading: false
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
  })),

  on(fromNpcActions.loadArmorsSuccess, (state, action) => ({
    ...state,
    npcTemplate: {
      ...state.npcTemplate,
      armors: action.armors,
      isLoading: false
    }
  })),

  on(fromNpcActions.loadFlawsSuccess, (state, action) => ({
    ...state,
    npcTemplate: {
      ...state.npcTemplate,
      flaws: action.flaws,
      isLoading: false
    }
  })),

  on(fromNpcActions.loadMeritsSucccess, (state, action) => ({
    ...state,
    npcTemplate: {
      ...state.npcTemplate,
      merits: action.merits,
      isLoading: false
    }
  })),

  on(fromNpcActions.loadSkillsSuccess, (state, action) => ({
    ...state,
    npcTemplate: {
      ...state.npcTemplate,
      skills: action.skills,
      isLoading: false
    }
  })),

  on(fromNpcActions.loadWeaponsSuccess, (state, action) => ({
    ...state,
    npcTemplate: {
      ...state.npcTemplate,
      weapons: action.weapons,
      isLoading: false
    }
  })),

  on(fromNpcActions.loadNpcTemplateSuccess, (state, action) => ({
    ...state,
    npcTemplate: {
      ...state.npcTemplate,
      npc: action.npcTemplate,
      isLoading: false
    }
  })),

  on(fromNpcActions.clearTemplate, (state, action) => ({
    ...state,
    npcTemplate: {
      ...state.npcTemplate,
      npc: undefined,
      isLoading: false
    }
  }))
);