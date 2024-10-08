import { Injectable } from '@angular/core';
import { ArmorsClient, FlawsClient, MeritsClient, NpcsClient, SkillsClient, WeaponsClient } from '../../shared/services/web-api-client';
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
import { Npc } from '../models/npc.model';
import { Difficulty } from '../../core/model/difficulty.model';
import { Race } from '../../core/model/race.model';

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
        isOptional: true,
        attribute1: skill.attribute1 as any as Attribute,
        attribute2: skill.attribute2 as any as Attribute,
        category: skill.category as SkillCategory
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
        isOptional: true
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
    )
  }

  getNpcTemplate(id: number): Observable<Npc> {
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
        manaMax: npc.manaMax,
        manaMin: npc.manaMin,
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
    )
  }
}