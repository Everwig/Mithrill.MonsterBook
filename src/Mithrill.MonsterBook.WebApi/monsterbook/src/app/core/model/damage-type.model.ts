export enum DamageType {
  Slashing = "Slashing",
  Stabbing = "Stabbing",
  Bludgeoning = "Bludgeoning",
  Fire = "Fire",
  Lightning = "Lightning",
  Ice = "Ice",
  Light = "Light",
  Dark = "Dark"
}

export const baseDamageTypes: DamageType[] = [
  DamageType.Slashing,
  DamageType.Bludgeoning,
  DamageType.Stabbing
] as const;