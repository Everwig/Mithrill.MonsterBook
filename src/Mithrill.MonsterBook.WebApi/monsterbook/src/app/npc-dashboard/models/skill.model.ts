import { Attribute } from '../../core/model/attribute.model';
import { SkillCategory } from '../../core/model/skill-category.model';

export interface Skill {
  id: number;
  name: string;
  minLevel: number;
  maxLevel: number;
  guaranteedSuccesses: number;
  isOptional: boolean;
  attribute1: Attribute;
  attribute2: Attribute;
  category: SkillCategory;
}