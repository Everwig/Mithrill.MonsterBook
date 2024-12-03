import { Injectable } from '@angular/core';
import { SortDirection as AngularSortDirection } from '@angular/material/sort';
import { map, Observable } from 'rxjs';

import { NpcsClient, SortDirection, SortProperty } from '../../shared/services/web-api-client';
import { NpcTemplate } from '../models/npc-template.model';
import { PageInformation } from '../../core/model/page-information.model';
import { SortInformation } from '../../core/model/sort-information.model';
import { GetStoredNpcsResult } from '../models/get-stored-npcs-result.model';
import { Difficulty } from '../../core/model/difficulty.model';
import { Race } from '../../core/model/race.model';

@Injectable()
export class NpcDashboardService {
  constructor(private creatureClient: NpcsClient) { }

  getAllNpcs(
    sortInformation: SortInformation,
    pageSize: number,
    pageIndex: number
  ): Observable<GetStoredNpcsResult> {
    return this.creatureClient.getAll(
      sortInformation.sortDirection === '' ? undefined : sortInformation.sortDirection as SortDirection,
      sortInformation.sortProperty as SortProperty,
      pageSize,
      pageIndex
    ).pipe(
      map(result => {
        const npcs: NpcTemplate[] = result.creatures.map(npc => ({
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
          manaPointMax: npc.manaPointMax,
          manaPointMin: npc.manaPointMin,
          karmaMax: npc.karmaMax,
          karmaMin: npc.karmaMin,
          name: npc.name,
          powerPointMax: npc.powerPointMax,
          powerPointMin: npc.powerPointMin,
          difficulty: Difficulty[npc.difficulty as keyof typeof Difficulty],
          race: Race[npc.race as keyof typeof Race],
          skillCategories: undefined,
          arcanumRanks: undefined,
          armors: [],
          flaws: [],
          merits: [],
          skills: [],
          weapons: [],
          isUndead: false,
        }) as NpcTemplate);

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

  delete(npcId: number): Observable<void> {
    return this.creatureClient.deleteTemplate(npcId);
  }
}