import { SkillCategory } from './skill-category.model';

export interface SkillCategories {
  primary: SkillCategory | undefined;
  firstSecondary: SkillCategory | undefined;
  secondSecondary: SkillCategory | undefined;
  tertiary: SkillCategory | undefined;
}