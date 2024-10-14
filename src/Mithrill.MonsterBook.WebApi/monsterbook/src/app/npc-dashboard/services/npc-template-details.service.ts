import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';

import { Skill } from '../models/skill.model';
import { Attribute } from '../../core/model/attribute.model';
import { SkillCategory } from '../../core/model/skill-category.model';
import { Merit } from '../models/merit.model';
import { Flaw } from '../models/flaw.model';
import { Weapon } from '../models/weapon.model';
import { Material } from '../../core/model/material.model';
import { AttackType } from '../models/attack-type.model';
import { DamageType } from '../../core/model/damage-type.model';
import { Armor } from '../models/armor.model';
import { ArcanumRanks, NpcTemplate } from '../models/npc-template.model';
import { Difficulty } from '../../core/model/difficulty.model';
import { Race } from '../../core/model/race.model';
import {
  ArmorsClient,
  FlawsClient,
  MeritsClient,
  NpcsClient,
  SkillsClient,
  WeaponsClient
} from '../../shared/services/web-api-client';
import { SkillCategories } from '../../core/model/skill-categories.model';
import { Arcanum } from '../../core/model/arcanum.model';

@Injectable()
export class NpcTemplateDetailsService {
  constructor (
    private npcsClient: NpcsClient,
    private skillsClient: SkillsClient,
    private meritsClient: MeritsClient,
    private flawsClient: FlawsClient,
    private weaponsClient: WeaponsClient,
    private armorsClient: ArmorsClient
  ) { }

  getSkills(): Observable<Skill[]> {
    return this.skillsClient.getAllForNpcTemplates().pipe(
      map(skills => skills.map(skill => ({
        id: skill.id,
        name: skill.name,
        minLevel: 0,
        maxLevel: 0,
        guaranteedSuccesses: 0,
        isOptional: false,
        attribute1: Attribute[skill.attribute1 as keyof typeof Attribute],
        attribute2: Attribute[skill.attribute2 as keyof typeof Attribute],
        category: SkillCategory[skill.category as keyof typeof SkillCategory]
      }) as Skill))
    );
  }

  getMerits(): Observable<Merit[]> {
    return this.meritsClient.getAllForNpcTemplates().pipe(
      map(merits => merits.map(merit => ({
        id: merit.id,
        name: merit.name,
        isOptional: false
      }) as Merit))
    );
  }

  getFlaws(): Observable<Flaw[]> {
    return this.flawsClient.getAllForNpcTemplates().pipe(
      map(flaws => flaws.map(flaw => ({
        id: flaw.id,
        name: flaw.name,
        isOptional: false
      }) as Flaw))
    );
  }

  getWeapons(): Observable<Weapon[]> {
    return this.weaponsClient.getAllForNpcTemplates().pipe(
      map(weapons => weapons.map(weapon => ({
        id: weapon.id,
        name: weapon.name,
        material: undefined,
        baseAttackModifier: weapon.baseAttackModifier,
        baseDefenseModifier: weapon.baseDefenseModifier,
        baseInitiativeModifier: weapon.baseInitiativeModifier,
        attackTypes: [({
          damageType: weapon.baseAttackType.damageType as DamageType,
          guaranteedDamage: weapon.baseAttackType.numberOfDices,
          numberOfDices: weapon.baseAttackType.guaranteedDamage
        }) as AttackType],
        isOptional: true,
        additionalAttackModifier: 0,
        additionalDefenseModifier: 0,
        additionalInitiativeModifier: 0
      }) as Weapon))
    );
  }

  getArmors(): Observable<Armor[]> {
    return this.armorsClient.getAllForNpcTemplates().pipe(
      map(armors => armors.map(armor => ({
        id: armor.id,
        name: armor.name,
        isOptional: true,
        material: undefined,
        baseArmorClass: armor.baseArmorClass,
        baseMovementInhibitoryFactor: armor.baseMovementInhibitoryFactor
      }) as Armor))
    );
  }

  getAttackTypes(): Observable<AttackType[]> {
    return this.weaponsClient.getAllAttackTypes().pipe(
      map(attackTypes => attackTypes.map(attackType => ({
        id: attackType.id,
        damageType: attackType.damageType,
        guaranteedDamage: attackType.guaranteedDamage,
        isBaseAttackType: false,
        numberOfDices: attackType.numberOfDices
      }) as AttackType))
    );
  }

  getNpcTemplate(id: number): Observable<NpcTemplate> {
    return this.npcsClient.get(id).pipe(
      map(npc => ({
        agilityMax: npc.agilityMax,
        agilityMin: npc.agilityMin,
        bodyMax: npc.bodyMax,
        bodyMin: npc.bodyMin,
        dexterityMax: npc.dexterityMax,
        dexterityMin: npc.dexterityMin,
        difficulty: Difficulty[npc.difficulty as keyof typeof Difficulty],
        emotionMax: npc.emotionMax,
        emotionMin: npc.emotionMin,
        hitPointMax: npc.hitPointMax,
        hitPointMin: npc.hitPointMin,
        id: npc.id,
        intelligenceMax: npc.intelligenceMax,
        intelligenceMin: npc.intelligenceMin,
        karmaMax: npc.karmaMax,
        karmaMin: npc.karmaMin,
        manaPointMax: npc.manaPointMax,
        manaPointMin: npc.manaPointMin,
        name: npc.name,
        powerPointMax: npc.powerPointMax,
        powerPointMin: npc.powerPointMin,
        race: Race[npc.race as keyof typeof Race],
        strengthMax: npc.strengthMax,
        strengthMin: npc.strengthMin,
        vitalityMax: npc.vitalityMax,
        vitalityMin: npc.vitalityMin,
        willpowerMax: npc.willpowerMax,
        willpowerMin: npc.willpowerMin,
        isUndead: npc.isUndead,
        skillCategories: npc.skillCategories,
        arcanumRanks: npc.arcanumRanks
          ? ({
            primary: npc.arcanumRanks.primary,
            secondary: npc.arcanumRanks.secondary,
            tertiary: npc.arcanumRanks.tertiaries,
            quaternary: npc.arcanumRanks.quaternary,
            quinary: npc.arcanumRanks.quinary
          }) as ArcanumRanks
          : undefined,
        armors: npc.armors.map(armor => ({
          id: armor.id,
          name: armor.name,
          isOptional: armor.isOptional,
          material: Material[armor.material as keyof typeof Material],
          baseArmorClass: armor.baseArmorClass,
          baseMovementInhibitoryFactor: armor.baseMovementInhibitoryFactor,
          additionalArmorClass: armor.additionalArmorClass,
          additionalMovementInhibitoryFactor: armor.additionalMovementInhibitoryFactor
        }) as Armor),
        flaws: npc.flaws.map(flaw => ({
          id: flaw.id,
          isOptional: flaw.isOptional,
          name: flaw.name
        }) as Flaw),
        merits: npc.merits.map(merit => ({
          id: merit.id,
          isOptional: merit.isOptional,
          name: merit.name
        }) as Merit),
        skills: npc.skills.map(skill => ({
          id: skill.id,
          attribute1: Attribute[skill.attribute1 as keyof typeof Attribute],
          attribute2: Attribute[skill.attribute2 as keyof typeof Attribute],
          guaranteedSuccesses: skill.guaranteedSuccesses,
          isOptional: skill.isOptional,
          maxLevel: skill.maxLevel,
          minLevel: skill.minLevel,
          name: skill.name,
          category: SkillCategory[skill.category as keyof typeof SkillCategory]
        }) as Skill),
        weapons: npc.weapons.map(weapon => ({
          id: weapon.id,
          baseAttackModifier: weapon.baseAttackModifier,
          baseDefenseModifier: weapon.additionalDefenseModifier,
          baseInitiativeModifier: weapon.baseInitiativeModifier,
          isOptional: weapon.isOptional,
          material: Material[weapon.material as keyof typeof Material],
          name: weapon.name,
          additionalAttackModifier: weapon.additionalAttackModifier,
          additionalDefenseModifier: weapon.additionalDefenseModifier,
          additionalInitiativeModifier: weapon.additionalInitiativeModifier,
          attackTypes: weapon.attackType.map(attackType => ({
            id: attackType.id,
            damageType: attackType.damageType,
            guaranteedDamage: attackType.guaranteedDamage,
            numberOfDices: attackType.numberOfDices,
            isBaseAttackType: attackType.isBaseAttackType
          }) as AttackType)
        }) as Weapon)
      }))
    );
  }

  getHitPointMinMaxValues(
    strengthMin: number,
    strengthMax: number,
    bodyMin: number,
    bodyMax: number,
    isUndead: boolean,
    meritIds: number[]
  ): Observable<{ hitPointMin: number, hitPointMax: number }> {
    return this.npcsClient.getHitPointMinMaxValues(strengthMin, strengthMax, bodyMin, bodyMax, isUndead, meritIds).pipe(
      map((tuple) => ({ hitPointMin: tuple.item1, hitPointMax: tuple.item2 }))
    );
  }

  getManaPointMinMaxValues(
    intelligenceMin: number,
    intelligenceMax: number,
    willpowerMin: number,
    willpowerMax: number,
    emotionMin: number,
    emotionMax: number,
    meritIds: number[]
  ): Observable<{ manaPointMin: number, manaPointMax: number }> {
    return this.npcsClient.getManaPointMinMaxValues(
      intelligenceMin,
      intelligenceMax,
      willpowerMin,
      willpowerMax,
      emotionMin,
      emotionMax,
      meritIds).pipe(
        map((tuple) => ({ manaPointMin: tuple.item1, manaPointMax: tuple.item2 }))
    );
  }

  getPowerPointMinMaxValues(karmaMin: number, karmaMax: number): Observable<{ powerPointMin: number, powerPointMax: number }> {
    return this.npcsClient.getPowerPointMinMaxValues(karmaMin, karmaMax).pipe(
      map((tuple) => ({ powerPointMin: tuple.item1, powerPointMax: tuple.item2 }))
    );
  }
}