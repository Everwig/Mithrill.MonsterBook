import { Material } from '../../core/model/material.model';

export interface Armor {
  id: number;
  name: string;
  material: Material | undefined;
  baseArmorClass: number;
  baseMovementInhibitoryFactor: number;
  isOptional: boolean;
  additionalArmorClass: number;
  additionalMovementInhibitoryFactor: number;
}