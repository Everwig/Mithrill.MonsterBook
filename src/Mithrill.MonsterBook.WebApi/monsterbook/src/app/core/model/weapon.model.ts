import { AttackType } from "./attack-type.model";
import { Material } from "./material.model";

export interface Weapon {
  id: number;
  name: string;
  material: Material;
  attackTypes: AttackType[];
  baseAttackModifier: number;
  baseDefenseModifier: number;
  baseInitiativeModifier: number;
  additionalAttackModifier: number;
  additionalDefenseModifier: number;
  additionalInitiativeModifier: number;
}