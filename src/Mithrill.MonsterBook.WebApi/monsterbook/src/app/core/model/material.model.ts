export enum Material {
  Bone = "Bone",
  Cloth = "Cloth",
  Leather = "Leather",
  DragonHide = "DragonHide",
  Wood = "Wood",
  Brick = "Brick",
  Copper = "Copper",
  Gold = "Gold",
  Stone = "Stone",
  Marble = "Marble",
  Iron = "Iron",
  Steel = "Steel",
  Mithrill = "Mithrill",
  Granite = "Granite",
  Ruby = "Ruby",
  Diamond = "Diamond",
  Adamar = "Adamar",
  Adamir = "Adamir"
}

export const armorOnlyMaterials: Material[] = [
  Material.Cloth,
  Material.Leather,
  Material.DragonHide
] as const;