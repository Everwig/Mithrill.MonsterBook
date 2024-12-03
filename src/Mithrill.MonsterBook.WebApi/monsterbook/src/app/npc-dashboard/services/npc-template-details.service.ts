import { Injectable } from '@angular/core';
import { map, Observable, of } from 'rxjs';

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
  WeaponsClient,
  Armor3 as CreateArmor,
  Armor4 as UpdateArmor,
  Armor5 as ValidateArmor,
  Flaw3 as CreateFlaw,
  Flaw4 as UpdateFlaw,
  Flaw5 as ValdiateFlaw,
  Merit3 as CreateMerit,
  Merit4 as UpdateMerit,
  Merit5 as ValidateMerit,
  Skill2 as CreateSkill,
  Skill3 as UpdateSkill,
  Skill4 as ValidateSkill,
  Weapon2 as CreateWeapon,
  Weapon3 as UpdateWeapon,
  Weapon4 as ValidateWeapon,
  AttackType2 as WeaponAttackType,
  SkillCategories as TemplateSkillCategories,
  NpcTemplate2 as UpdateNpcTemplate,
  NpcTemplate3 as ValidateNpcTemplate,
  ValidateNpcTemplateQuery,
  CreateNpcTemplateCommand,
  ValidationMode
} from '../../shared/services/web-api-client';
import { DetailsViewMode } from '../../shared/models/details-view-mode.model';
import { ValidationResult } from '../../shared/models/validation-result.model';

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
        skillCategories: npc.skillCategories
          ? ({
              firstSecondary: npc.skillCategories?.firstSecondary,
              primary: npc.skillCategories?.primary,
              secondSecondary: npc.skillCategories?.secondSecondary,
              tertiary: npc.skillCategories?.tertiary
            })
          : undefined,
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

  createTemplate(npcTemplate: NpcTemplate): Observable<number>{
    return this.npcsClient.createTemplate(new CreateNpcTemplateCommand({
      agilityMax: npcTemplate.agilityMax,
      agilityMin: npcTemplate.agilityMin,
      armors: npcTemplate.armors.map(armor => new CreateArmor({
        additionalArmorClass: armor.additionalArmorClass,
        additionalMovementInhibitoryFactor: armor.additionalMovementInhibitoryFactor,
        isOptional: armor.isOptional,
        id: armor.id,
        material: armor.material!
      })),
      bodyMax: npcTemplate.bodyMax,
      bodyMin: npcTemplate.bodyMin,
      damageReductionMax: 0,
      damageReductionMin: 0,
      dexterityMax: npcTemplate.dexterityMax,
      dexterityMin: npcTemplate.dexterityMin,
      difficulty: npcTemplate.difficulty,
      emotionMax: npcTemplate.emotionMax,
      emotionMin: npcTemplate.emotionMin,
      flaws: npcTemplate.flaws.map(flaw => new CreateFlaw({
        id: flaw.id,
        isOptional: flaw.isOptional
      })),
      intelligenceMax: npcTemplate.intelligenceMax,
      intelligenceMin: npcTemplate.intelligenceMin,
      isUndead: npcTemplate.isUndead,
      karmaMax: npcTemplate.karmaMax,
      karmaMin: npcTemplate.karmaMin,
      merits: npcTemplate.merits.map(merit => new CreateMerit({
        id: merit.id,
        isOptional: merit.isOptional
      })),
      name: npcTemplate.name,
      nameHu: '',
      race: npcTemplate.race,
      skillCategories: npcTemplate.skillCategories
        ? new TemplateSkillCategories({
            primary: npcTemplate.skillCategories.primary!,
            firstSecondary: npcTemplate.skillCategories.firstSecondary!,
            secondSecondary: npcTemplate.skillCategories.secondSecondary!,
            tertiary: npcTemplate.skillCategories.tertiary!
          })
        : undefined,
        skills: npcTemplate.skills.map(skill => new CreateSkill({
          guaranteedSuccesses: skill.guaranteedSuccesses,
          id: skill.id,
          isOptional: skill.isOptional,
          maxLevel: skill.maxLevel,
          minLevel: skill.minLevel
        })),
        arcanumRanks: undefined,
        strengthMax: npcTemplate.strengthMax,
        strengthMin: npcTemplate.strengthMin,
        vitalityMax: npcTemplate.vitalityMax,
        vitalityMin: npcTemplate.vitalityMin,
        weapons: npcTemplate.weapons.map(weapon => new CreateWeapon({
          additionalAttackModifier: weapon.additionalAttackModifier,
          additionalAttackTypes: weapon.attackTypes.filter(attackType => !attackType.isBaseAttackType)
            .map(attackType => new WeaponAttackType({
              damageType: attackType.damageType,
              guaranteedDamage: attackType.guaranteedDamage,
              numberOfDices: attackType.numberOfDices
            })),
          additionalDefenseModifier: weapon.additionalDefenseModifier,
          additionalInitiativeModifier: weapon.additionalInitiativeModifier,
          id: weapon.id,
          isOptional: weapon.isOptional,
          material: weapon.material!
        })),
        willpowerMax: npcTemplate.willpowerMax,
        willpowerMin: npcTemplate.willpowerMin
    }));
  }

  updateTemplate(npcTemplate: NpcTemplate): Observable<void> {
    console.log(npcTemplate);
    return this.npcsClient.updateTemplate(
      npcTemplate.id,
      new UpdateNpcTemplate({
        agilityMax: npcTemplate.agilityMax,
        agilityMin: npcTemplate.agilityMin,
        armors: npcTemplate.armors.map(armor => new UpdateArmor({
          id: armor.id,
          material: armor.material!,
          additionalArmorClass: armor.additionalArmorClass,
          additionalMovementInhibitoryFactor: armor.additionalMovementInhibitoryFactor,
          isOptional: armor.isOptional
        }) as UpdateArmor),
        bodyMax: npcTemplate.bodyMax,
        bodyMin: npcTemplate.bodyMin,
        damageReductionMax: 0,
        damageReductionMin: 0,
        dexterityMax: npcTemplate.dexterityMax,
        dexterityMin: npcTemplate.dexterityMin,
        difficulty: npcTemplate.difficulty,
        emotionMax: npcTemplate.emotionMax,
        emotionMin: npcTemplate.emotionMin,
        flaws: npcTemplate.flaws.map(flaw => new UpdateFlaw({
          id: flaw.id,
          isOptional: flaw.isOptional
        })),
        id: npcTemplate.id,
        intelligenceMax: npcTemplate.intelligenceMax,
        intelligenceMin: npcTemplate.intelligenceMin,
        isUndead: npcTemplate.isUndead,
        karmaMax: npcTemplate.karmaMax,
        karmaMin: npcTemplate.karmaMin,
        merits: npcTemplate.merits.map(merit => new UpdateMerit({
          id: merit.id,
          isOptional: merit.isOptional
        })),
        name: npcTemplate.name,
        nameHu: '',
        race: npcTemplate.race,
        skillCategories: npcTemplate.skillCategories
          ? new TemplateSkillCategories({
              firstSecondary: npcTemplate.skillCategories?.firstSecondary!,
              primary: npcTemplate.skillCategories?.primary!,
              secondSecondary: npcTemplate.skillCategories?.secondSecondary!,
              tertiary: npcTemplate.skillCategories?.tertiary!
            })
          : undefined,
        arcanumRanks: undefined,
        skills: npcTemplate.skills.map(skill => new UpdateSkill({
          id: skill.id,
          guaranteedSuccesses: skill.guaranteedSuccesses,
          isOptional: skill.isOptional,
          maxLevel: skill.maxLevel,
          minLevel: skill.minLevel
        })),
        strengthMax: npcTemplate.strengthMax,
        strengthMin: npcTemplate.strengthMin,
        vitalityMax: npcTemplate.vitalityMax,
        vitalityMin: npcTemplate.vitalityMin,
        weapons: npcTemplate.weapons.map(weapon => new UpdateWeapon({
          id: weapon.id,
          additionalAttackModifier: weapon.additionalAttackModifier,
          additionalAttackTypes: weapon.attackTypes
            .filter(attackType => !attackType.isBaseAttackType)
            .map(attackType => new WeaponAttackType({
              damageType: attackType.damageType,
              guaranteedDamage: attackType.guaranteedDamage,
              numberOfDices: attackType.numberOfDices
            })),
          additionalDefenseModifier: weapon.additionalDefenseModifier,
          additionalInitiativeModifier: weapon.additionalInitiativeModifier,
          isOptional: weapon.isOptional,
          material: weapon.material!
        })),
        willpowerMax: npcTemplate.willpowerMax,
        willpowerMin: npcTemplate.willpowerMin
      }));
  }

  validateTemplate(npcTemplate: NpcTemplate, isNew: boolean): Observable<ValidationResult> {
    return this.npcsClient.validate(new ValidateNpcTemplateQuery({
      validationMode: isNew ? ValidationMode.Create : ValidationMode.Edit,
      npcTemplate: new ValidateNpcTemplate({
        id: npcTemplate.id,
        agilityMax: npcTemplate.agilityMax,
        agilityMin: npcTemplate.agilityMin,
        armors: npcTemplate.armors.map(armor => new ValidateArmor({
          additionalArmorClass: armor.additionalArmorClass,
          additionalMovementInhibitoryFactor: armor.additionalMovementInhibitoryFactor,
          isOptional: armor.isOptional,
          id: armor.id,
          material: armor.material!
        })),
        bodyMax: npcTemplate.bodyMax,
        bodyMin: npcTemplate.bodyMin,
        damageReductionMax: 0,
        damageReductionMin: 0,
        dexterityMax: npcTemplate.dexterityMax,
        dexterityMin: npcTemplate.dexterityMin,
        difficulty: npcTemplate.difficulty,
        emotionMax: npcTemplate.emotionMax,
        emotionMin: npcTemplate.emotionMin,
        flaws: npcTemplate.flaws.map(flaw => new ValdiateFlaw({
          id: flaw.id,
          isOptional: flaw.isOptional
        })),
        intelligenceMax: npcTemplate.intelligenceMax,
        intelligenceMin: npcTemplate.intelligenceMin,
        isUndead: npcTemplate.isUndead,
        karmaMax: npcTemplate.karmaMax,
        karmaMin: npcTemplate.karmaMin,
        merits: npcTemplate.merits.map(merit => new ValidateMerit({
          id: merit.id,
          isOptional: merit.isOptional
        })),
        name: npcTemplate.name,
        nameHu: '',
        race: npcTemplate.race,
        skillCategories: npcTemplate.skillCategories
          ? new TemplateSkillCategories({
              primary: npcTemplate.skillCategories.primary!,
              firstSecondary: npcTemplate.skillCategories.firstSecondary!,
              secondSecondary: npcTemplate.skillCategories.secondSecondary!,
              tertiary: npcTemplate.skillCategories.tertiary!
            })
          : undefined,
        arcanumRanks: undefined,
        skills: npcTemplate.skills.map(skill => new ValidateSkill({
          guaranteedSuccesses: skill.guaranteedSuccesses,
          id: skill.id,
          isOptional: skill.isOptional,
          maxLevel: skill.maxLevel,
          minLevel: skill.minLevel
        })),
        strengthMax: npcTemplate.strengthMax,
        strengthMin: npcTemplate.strengthMin,
        vitalityMax: npcTemplate.vitalityMax,
        vitalityMin: npcTemplate.vitalityMin,
        weapons: npcTemplate.weapons.map(weapon => new ValidateWeapon({
          additionalAttackModifier: weapon.additionalAttackModifier,
          additionalAttackTypes: weapon.attackTypes.filter(attackType => !attackType.isBaseAttackType)
            .map(attackType => new WeaponAttackType({
              damageType: attackType.damageType,
              guaranteedDamage: attackType.guaranteedDamage,
              numberOfDices: attackType.numberOfDices
            })),
          additionalDefenseModifier: weapon.additionalDefenseModifier,
          additionalInitiativeModifier: weapon.additionalInitiativeModifier,
          id: weapon.id,
          isOptional: weapon.isOptional,
          material: weapon.material!
        })),
        willpowerMax: npcTemplate.willpowerMax,
        willpowerMin: npcTemplate.willpowerMin
      })
    })).pipe(
      map(validationResult => new ValidationResult( validationResult.isValid, validationResult.errors))
    );
  }
}