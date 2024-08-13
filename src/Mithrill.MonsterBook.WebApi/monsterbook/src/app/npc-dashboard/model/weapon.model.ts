import { Material } from '../../core/model/material.model';
import { AttackType } from './attack-type.model';

export interface Weapon {
  id: number;
  name: string;
  material: Material;
  attackTypes: AttackType[];
  isOptional: boolean;
}