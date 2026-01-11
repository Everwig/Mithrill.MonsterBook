import { DamageType } from './damage-type.model';

export interface AttackType {
  id: number;
  damageType: DamageType;
  numberOfDices: number;
  guaranteedDamage: number;
  isBaseAttackType: boolean;
}