import { createAction, props } from '@ngrx/store';

import { SortInformation } from '../../core/model/sort-information.model';
import { GetStoredNpcsResult } from '../models/get-stored-npcs-result.model';
import { Armor } from '../models/armor.model';
import { Weapon } from '../models/weapon.model';
import { Flaw } from '../models/flaw.model';
import { Merit } from '../models/merit.model';
import { Skill } from '../models/skill.model';
import { Npc } from '../models/npc.model';

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

export const loadArmors = createAction(
  '[NPC Template] Load Armors'
);
export const loadArmorsSuccess = createAction(
  '[NPC Template] Load Armors Success',
  props<{ armors: Armor[] }>()
);

export const loadWeapons = createAction(
  '[NPC Template] Load Weapons'
);
export const loadWeaponsSuccess = createAction(
  '[NPC Template] Load Weapons Success',
  props<{ weapons: Weapon[] }>()
);

export const loadFlaws = createAction(
  '[NPC Template] Load Flaws'
);
export const loadFlawsSuccess = createAction(
  '[NPC Template] Load Flaws Success',
  props<{ flaws: Flaw[] }>()
);

export const loadMerits = createAction(
  '[NPC Template] Load Merits'
);
export const loadMeritsSucccess = createAction(
  '[NPC Template] Load Merits Success',
  props<{ merits: Merit[] }>()
);

export const loadSkills = createAction(
  '[NPC Template] Load Skills'
);
export const loadSkillsSuccess = createAction(
  '[NPC Template] Load Skills Success',
  props<{ skills: Skill[] }>()
);

export const loadNpcTemplate = createAction(
  '[NPC Template] Load NPC Template',
  props<{ id: number}>()
);
export const loadNpcTemplateSuccess = createAction(
  '[NPC Template] Load NPC Template Success',
  props<{ npcTemplate: Npc }>()
);

export const loadNpcTemplateFailed = createAction(
  '[NPC Template] Load NPC Template failed',
  props<{ errors: any }>()
);

export const clearTemplate = createAction(
  '[NPC Template] Clearing NPC Template'
);
