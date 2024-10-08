import { PageInformation } from '../../core/model/page-information.model';
import { SortInformation } from '../../core/model/sort-information.model';
import { Npc } from './npc.model';

export interface GetStoredNpcsResult {
  npcs: Npc[],
  pageInformation: PageInformation,
  sortInformation: SortInformation
}