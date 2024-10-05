import { DamageType } from '../../core/model/damage-type.model';

export interface AttackType {
  damageType: DamageType;
  numberOfDices: number;
  guaranteedDamage: number;
}