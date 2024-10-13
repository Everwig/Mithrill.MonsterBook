import { Arcanum } from '../../core/model/arcanum.model';
import { Difficulty } from '../../core/model/difficulty.model';
import { Race } from '../../core/model/race.model';
import { SkillCategories } from '../../core/model/skill-categories.model';
import { Armor } from './armor.model';
import { Flaw } from './flaw.model';
import { Merit } from './merit.model';
import { Skill } from './skill.model';
import { Weapon } from './weapon.model';

export interface NpcTemplate {
  id: number;
  name: string;
  strengthMin: number;
  strengthMax: number;
  vitalityMin: number;
  vitalityMax: number;
  bodyMin: number;
  bodyMax: number;
  agilityMin: number;
  agilityMax: number;
  dexterityMin: number;
  dexterityMax: number;
  intelligenceMin: number;
  intelligenceMax: number;
  willpowerMin: number;
  willpowerMax: number;
  emotionMin: number;
  emotionMax: number;
  karmaMin: number;
  karmaMax: number;
  hitPointMin: number;
  hitPointMax: number;
  manaPointMin: number;
  manaPointMax: number;
  powerPointMin: number;
  powerPointMax: number;
  race: Race;
  difficulty: Difficulty;
  isUndead: boolean;
  skills: Skill[];
  skillCategories: SkillCategories | undefined;
  arcanumRanks: ArcanumRanks | undefined;
  merits: Merit[];
  flaws: Flaw[];
  weapons: Weapon[];
  armors: Armor[];
}

export interface ArcanumRanks {
  primary: Arcanum;
  secondary: Arcanum;
  tertiary: Arcanum[];
  quaternary: Arcanum;
  quinary: Arcanum;
}