import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { NpcsClient } from '../shared/services/web-api-client';
import { MatSelectModule } from '@angular/material/select';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { SummonType } from '../core/model/summon-type.model';
import { Difficulty } from '../core/model/difficulty.model';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { map, Observable, of } from 'rxjs';
import { NpcTemplate } from '../npc-dashboard/models/npc-template.model';
import { Race } from '../core/model/race.model';
import { GeneratedNpc } from '../core/model/generated-npc.model';
import { MeritFlaw } from '../core/model/merti-flaw.model';
import { Armor } from '../core/model/armor.model';
import { Weapon } from '../core/model/weapon.model';
import { AttackType } from '../core/model/attack-type.model';
import { Skill } from '../core/model/skill.model';

export const nameof = <T>(name: keyof T) => name;
interface selectOption {
  value: string;
  viewValue: string;
}

@Component({
  selector: 'app-generate-npc',
  imports: [
    CommonModule,
    FormsModule,
    MatInputModule,
    MatSelectModule,
    MatSlideToggleModule
],
  templateUrl: './generate-npc.component.html',
  styleUrl: './generate-npc.component.scss'
})
export class GenerateNpcComponent {
  readonly summon: string = 'summon';
  readonly regular: string = 'regular';

  selectedNpcType?: string;
  selectedNpcTemplate?: NpcTemplate;
  selectedSummontype?: string;
  selectedDifficulty?: string;
  selectedLevel?: number;
  isProminent: boolean = false;
  hasKarma: boolean = false;
  isEvil: boolean = false;
  isUndead: boolean = false;
  summonTypes: selectOption[];
  diffulties: selectOption[];
  levels: selectOption[];
  npcTypes: selectOption[] = [
    { value: this.regular, viewValue: 'Hagyományos' },
    { value: this.summon, viewValue: 'Idézett lény' }
  ];

  generatedNpc$?: Observable<GeneratedNpc>;
  npcTemplate$?: Observable<NpcTemplate[]>;

  constructor(private npcsClient: NpcsClient) {
    this.summonTypes = Object.values(SummonType).map(type => ({ value: type, viewValue: this.summonTypeMapper(type) }));
    this.diffulties = Object.values(Difficulty).map(type => ({ value: type, viewValue: this.difficultyMapper(type) }));
    this.levels = Array.from(Array(12), (_, index) => ({ value: `${index + 1}`, viewValue: `${index + 1 }`}));
    this.npcTemplate$ = npcsClient.getTemplatesForGeneration().pipe(
      map(templates => templates.map(template => ({ ...template }) as NpcTemplate))
    );
  }

  generateSummon(): void {
    if (this.selectedNpcType === this.summon && this.selectedSummontype && this.selectedLevel) {
      this.selectedNpcTemplate = undefined;
      this.selectedDifficulty = undefined;
      this.isEvil = false;
      this.hasKarma = false;
      this.isUndead = false;
      this.isProminent = false;
      this.generatedNpc$ = this.npcsClient.getSummon(this.selectedSummontype as SummonType, this.selectedLevel).pipe(
        map(generatedNpc => ({
            agility: generatedNpc.agility,
            body: generatedNpc.body,
            damageReduction: generatedNpc.damageReduction,
            dexterity: generatedNpc.dexterity,
            emotion: generatedNpc.emotion,
            hitPoint: generatedNpc.hitPoint,
            intelligence: generatedNpc.intelligence,
            karma: generatedNpc.karma,
            manaPoint: generatedNpc.manaPoint,
            name: generatedNpc.name,
            powerPoint: generatedNpc.powerPoint,
            strength: generatedNpc.strength,
            vitality: generatedNpc.vitality,
            willpower: generatedNpc.willpower,
            armors: [],
            flaws: [],
            merits: generatedNpc.merits.map(merit => ({
              id: merit.id,
              name: merit.name,
            }) as MeritFlaw),
            skills: generatedNpc.skills.map(skill => ({
              id: skill.id,
              name: skill.name,
              numberOfDices: skill.numberOfDices,
              level: skill.level,
              guaranteedSuccesses: skill.guaranteedSuccesses
            }) as Skill),
            weapons: generatedNpc.weapons.map(weapon => ({
              id: weapon.id,
              name: weapon.name,
              material: weapon.material,
              baseAttackModifier: weapon.baseAttackModifier,
              baseDefenseModifier: weapon.baseDefenseModifier,
              baseInitiativeModifier: weapon.baseInitiativeModifier,
              attackTypes: weapon.attackTypes.map(attackType => ({
                damageType: attackType.damageType,
                guaranteedDamage: attackType.guaranteedDamage,
                numberOfDices: attackType.numberOfDices
              }) as AttackType),
              additionalAttackModifier: weapon.additionalAttackModifier,
              additionalDefenseModifier: weapon.additionalDefenseModifier,
              additionalInitiativeModifier: weapon.additionalInitiativeModifier
            }) as Weapon)
          }) as GeneratedNpc)
      );
    }

    if (this.selectedNpcType === this.regular && this.selectedNpcTemplate && this.selectedDifficulty) {
      this.selectedSummontype = undefined;
      this.selectedLevel = undefined;

      this.generatedNpc$ = this.npcsClient.getGenerated(
        this.selectedNpcTemplate.id,
        this.isProminent,
        this.hasKarma,
        this.isEvil,
        this.isUndead,
        this.selectedDifficulty as Difficulty).pipe(
          map(generatedNpc => ({
            agility: generatedNpc.agility,
            body: generatedNpc.body,
            damageReduction: generatedNpc.damageReduction,
            dexterity: generatedNpc.dexterity,
            difficulty: generatedNpc.difficulty,
            emotion: generatedNpc.emotion,
            hitPoint: generatedNpc.hitPoint,
            intelligence: generatedNpc.intelligence,
            karma: generatedNpc.karma,
            manaPoint: generatedNpc.manaPoint,
            name: generatedNpc.name,
            powerPoint: generatedNpc.powerPoint,
            strength: generatedNpc.strength,
            vitality: generatedNpc.vitality,
            willpower: generatedNpc.willpower,
            armors: generatedNpc.armors.map(armor => ({
              id: armor.id,
              name: armor.name,
              material: armor.material,
              baseArmorClass: armor.baseArmorClass,
              baseMovementInhibitoryFactor: armor.baseMovementInhibitoryFactor,
              additionalArmorClass: armor.additionalArmorClass,
              additionalMovementInhibitoryFactor: armor.additionalMovementInhibitoryFactor
            }) as Armor),
            flaws: generatedNpc.flaws.map(flaw => ({
              id: flaw.id,
              name: flaw.name
            }) as MeritFlaw),
            merits: generatedNpc.merits.map(merit => ({
              id: merit.id,
              name: merit.name,
            }) as MeritFlaw),
            skills: generatedNpc.skills.map(skill => ({
              id: skill.id,
              name: skill.name,
              numberOfDices: skill.numberOfDices,
              level: skill.level,
              guaranteedSuccesses: skill.guaranteedSuccesses
            }) as Skill),
            weapons: generatedNpc.weapons.map(weapon => ({
              id: weapon.id,
              name: weapon.name,
              material: weapon.material,
              baseAttackModifier: weapon.baseAttackModifier,
              baseDefenseModifier: weapon.baseDefenseModifier,
              baseInitiativeModifier: weapon.baseInitiativeModifier,
              attackTypes: weapon.attackTypes.map(attackType => ({
                damageType: attackType.damageType,
                guaranteedDamage: attackType.guaranteedDamage,
                numberOfDices: attackType.numberOfDices
              }) as AttackType),
              additionalAttackModifier: weapon.additionalAttackModifier,
              additionalDefenseModifier: weapon.additionalDefenseModifier,
              additionalInitiativeModifier: weapon.additionalInitiativeModifier
            }) as Weapon)
          }) as GeneratedNpc)
        );
    }
  }

  onTemplateChange(): void {
    if (this.selectedNpcTemplate){
      this.isUndead = this.selectedNpcTemplate.isUndead;
      this.isEvil = this.selectedNpcTemplate.race === Race.CreatureOfDarkness;
      this.hasKarma = this.selectedNpcTemplate.karmaMin > 0;
    }
  }

  isProminentDisabled(): boolean {
    return this.selectedNpcTemplate !== undefined &&
      this.selectedNpcTemplate.race === Race.Animal
  }

  isKarmaDisabled(): boolean {
    return this.selectedNpcTemplate !== undefined &&
      (this.selectedNpcTemplate.race === Race.Animal ||
      this.selectedNpcTemplate.race === Race.Elemental ||
      this.selectedNpcTemplate.race === Race.Bug)
  }

  isUndeadDisabled(): boolean {
    return this.selectedNpcTemplate !== undefined &&
      (this.selectedNpcTemplate.race === Race.Elemental ||
      (this.selectedNpcTemplate.race === Race.CreatureOfDarkness && this.selectedNpcTemplate.isUndead))
  }

  private summonTypeMapper(type: string): string {
    switch (type) {
      case SummonType.Air:
        return "Levegő";
      case SummonType.Earth:
        return "Föld";
      case SummonType.Fire:
        return "Tűz";
      case SummonType.Holy:
        return "Angyal";
      case SummonType.Ice:
        return "Jég";
      case SummonType.Rock:
        return "Szikla";
      case SummonType.Sand:
        return "Homok";
      case SummonType.Thunder:
        return "Villám";
      case SummonType.Unholy:
        return "Démon";
      case SummonType.Water:
        return "Víz";
      default:
        throw Error('Invalid summon type');
    }
  }

  private difficultyMapper(type: string): string {
    switch(type) {
      case Difficulty.Newbie:
      case Difficulty.Demigodly:
      case Difficulty.Experienced:
      case Difficulty.Expert:
      case Difficulty.Godly:
      case Difficulty.Variable:
      case Difficulty.Veteran:
        return nameof(type);
      default:
        throw Error('Invalid summon type');
    }
  }
}