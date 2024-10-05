export interface Skill {
  id: number;
  name: string;
  minLevel: number;
  maxLevel: number;
  guaranteedSuccesses: number;
  isOptional: boolean;
}