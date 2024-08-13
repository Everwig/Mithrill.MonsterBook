import { Material } from '../../core/model/material.model';

export interface Armor {
  id: number;
  name: string;
  material: Material;
  armorClass: number;
  movementInhibitoryFactor: number;
  isOptional: boolean;
}