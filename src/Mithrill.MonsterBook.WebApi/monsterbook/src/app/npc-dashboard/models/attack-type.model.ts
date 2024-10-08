import { DamageType } from '../../core/model/damage-type.model';

export interface AttackType {
  id: number;
  damageType: DamageType;
  numberOfDices: number;
  guaranteedDamage: number;
  isBaseAttackType: boolean;
}