import { PageInformation } from '../../core/model/page-information.model';
import { SortInformation } from '../../core/model/sort-information.model';
import { NpcTemplate } from './npc-template.model';

export interface GetStoredNpcsResult {
  npcs: NpcTemplate[],
  pageInformation: PageInformation,
  sortInformation: SortInformation
}