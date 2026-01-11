import { Material } from "./material.model";

export interface Armor {
  id: number;
  name: string;
  material: Material;
  baseArmorClass: number;
  baseMovementInhibitoryFactor: number;
  additionalArmorClass: number;
  additionalMovementInhibitoryFactor: number;
}