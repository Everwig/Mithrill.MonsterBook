import { createAction, props } from '@ngrx/store';

import { SortInformation } from '../../core/model/sort-information.model';
import { GetStoredNpcsResult } from '../models/get-stored-npcs-result.model';
import { Armor } from '../models/armor.model';
import { Weapon } from '../models/weapon.model';
import { Flaw } from '../models/flaw.model';
import { Merit } from '../models/merit.model';
import { Skill } from '../models/skill.model';
import { NpcTemplate } from '../models/npc-template.model';
import { AttackType } from '../models/attack-type.model';

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

export const loadAttackTypes = createAction(
  '[NPC Tempalte] Load AttackTypes'
);
export const loadAttackTypesSuccess = createAction(
  '[NPC Tempalte] Load AttackTypes Success',
  props<{ attackTypes: AttackType[] }>()
);

export const loadNpcTemplate = createAction(
  '[NPC Template] Load NPC Template',
  props<{ id: number}>()
);
export const loadNpcTemplateSuccess = createAction(
  '[NPC Template] Load NPC Template Success',
  props<{ npcTemplate: NpcTemplate }>()
);
export const loadNpcTemplateFailed = createAction(
  '[NPC Template] Load NPC Template failed',
  props<{ errors: any }>()
);

export const clearTemplate = createAction(
  '[NPC Template] Clearing NPC Template'
);

export const calculateHitPointMinMaxValues = createAction(
  '[NPC Template] Calculate Hit Point min-max values',
  props<{
    strengthMin: number,
    strengthMax: number,
    bodyMin: number,
    bodyMax: number,
    isUndead: boolean,
    meritIds: number[]
  }>()
);
export const calculateHitPointMinMaxValuesSuccess = createAction(
  '[NPC Template] Calculate Hit Point min-max values success',
  props<{ hitPointMin: number, hitPointMax: number }>()
);

export const calculateManaPointMinMaxValues = createAction(
  '[NPC Template] Calculate Mana Point min-max values',
  props<{
    intelligenceMin: number,
    intelligenceMax: number,
    willpowerMin: number,
    willpowerMax: number,
    emotionMin: number,
    emotionMax: number,
    meritIds: number[]
  }>()
);
export const calculateManaPointMinMaxValuesSuccess = createAction(
  '[NPC Template] Calculate Mana Point min-max values success',
  props<{ manaPointMin: number, manaPointMax: number }>()
);

export const calculatePowerPointMinMaxValues = createAction(
  '[NPC Template] Calculate Power Point min-max values',
  props<{karmaMin: number, karmaMax: number }>()
);
export const calculatePowerPointMinMaxValuesSuccess = createAction(
  '[NPC Template] Calculate Power Point min-max values success',
  props<{ powerPointMin: number, powerPointMax: number }>()
);