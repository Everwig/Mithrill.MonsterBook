import { Armor } from './armor.model';
import { Difficulty } from './difficulty.model';
import { MeritFlaw } from './merti-flaw.model';
import { Skill } from './skill.model';
import { Weapon } from './weapon.model';

export interface GeneratedNpc {
  name: string;

  strength: number;
  vitality: number;
  body: number;
  agility: number;
  dexterity: number;
  intelligence: number;
  willpower: number;
  emotion: number;

  damageReduction: number;
  karma: number;
  difficulty?: Difficulty;

  weapons: Weapon[];
  armors: Armor[];
  skills: Skill[];
  merits: MeritFlaw[];
  flaws: MeritFlaw[];

  hitPoint: number;
  manaPoint: number;
  powerPoint: number;
}