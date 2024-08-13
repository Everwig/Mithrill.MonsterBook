import { Injectable } from '@angular/core';
import { SortDirection as AngularSortDirection } from '@angular/material/sort';
import { map, Observable } from 'rxjs';

import { NpcClient, SortDirection, SortProperty } from '../../shared/services/web-api-client';
import { Npc } from '../model/npc.model';
import { PageInformation } from '../../core/model/page-information.model';
import { SortInformation } from '../../core/model/sort-information.model';
import { GetStoredNpcsResult } from '../model/get-stored-npcs-result.model';
import { Difficulty } from '../../core/model/difficulty.model';
import { Race } from '../../core/model/race.model';
import { Skill } from '../model/skill.model';
import { Merit } from '../model/merit.model';
import { Flaw } from '../model/flaw.model';
import { Armor } from '../model/armor.model';
import { Material } from '../../core/model/material.model';
import { Weapon } from '../model/weapon.model';
import { AttackType } from '../model/attack-type.model';
import { DamageType } from '../../core/model/damage-type.model';

@Injectable()
export class NpcDashboardService {
  constructor(private npcClient: NpcClient) { }

  getAllNpcs(
    sortInformation: SortInformation,
    pageSize: number,
    pageIndex: number
  ): Observable<GetStoredNpcsResult> {
    return this.npcClient.getStoredNpcs(
      sortInformation.sortDirection === '' ? undefined : sortInformation.sortDirection as SortDirection,
      sortInformation.sortProperty as SortProperty,
      pageSize,
      pageIndex
    ).pipe(
      map(result => {
        const npcs: Npc[] = result.creatures.map(npc => ({
          id: npc.id,
          strengthMax: npc.strengthMax,
          strengthMin: npc.strengthMin,
          agilityMax: npc.agilityMax,
          agilityMin: npc.agilityMin,
          dexterityMax: npc.dexterityMax,
          dexterityMin: npc.dexterityMin,
          bodyMax: npc.bodyMax,
          bodyMin: npc.bodyMin,
          vitalityMax: npc.vitalityMax,
          vitalityMin: npc.vitalityMin,
          emotionMax: npc.emotionMax,
          emotionMin: npc.emotionMin,
          intelligenceMax: npc.intelligenceMax,
          intelligenceMin: npc.intelligenceMin,
          willpowerMax: npc.willpowerMax,
          willpowerMin: npc.willpowerMin,
          hitPointMax: npc.hitPointMax,
          hitPointMin: npc.hitPointMin,
          manaMax: npc.manaMax,
          manaMin: npc.manaMin,
          karmaMax: npc.karmaMax,
          karmaMin: npc.karmaMin,
          name: npc.name,
          powerPointMax: npc.powerPointMax,
          powerPointMin: npc.powerPointMin,
          difficulty: npc.difficulty as unknown as Difficulty,
          race: npc.race as unknown as Race,
          skills: npc.skills.map(skill => ({
            id: skill.id,
            name: skill.name,
            guaranteedSuccesses: skill.guaranteedSuccesses,
            maxLevel: skill.skillLevelMax,
            minLevel: skill.skillLevelMin,
            isOptional: skill.isOptional
          }) as Skill),
          merits: npc.merits.map(merit => ({
            id: merit.id,
            name: merit.name,
            isOptional: merit.isOptional
          }) as Merit),
          flaws: npc.flaws.map(flaw => ({
            id: flaw.id,
            name: flaw.name,
            isOptional: flaw.isOptional
          }) as Flaw),
          armors: npc.armors.map(armor => ({
            id: armor.id,
            name: armor.name,
            armorClass: armor.armorClass,
            isOptional: armor.isOptional,
            material: armor.material as unknown as Material,
            movementInhibitoryFactor: armor.movementInhibitoryFactor
          }) as Armor),
          weapons: npc.weapons.map(weapon => ({
            id: weapon.id,
            name: weapon.name,
            isOptional: weapon.isOptional,
            material: weapon.material as unknown as Material,
            attackTypes: weapon.attackTypes.map(attackType => ({
              numberOfDices: attackType.numberOfDices,
              guaranteedDamage: attackType.guaranteedDamage,
              damageType: attackType.damageType as unknown as DamageType
            }) as AttackType)
          }) as Weapon)
        }) as Npc);

        const pageInformation: PageInformation = {
          totalCount: result.pageInformation.totalCount,
          pageSize: result.pageInformation.pageSize,
          pageIndex: result.pageInformation.pageIndex
        };

        const sortInformation: SortInformation = {
          sortProperty: result.sortInformation.sortProperty as string,
          sortDirection: result.sortInformation.sortDirection as AngularSortDirection
        };

        return { npcs, pageInformation, sortInformation };
      })
    )
  }
}