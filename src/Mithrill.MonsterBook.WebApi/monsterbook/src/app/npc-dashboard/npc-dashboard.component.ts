import { CommonModule } from '@angular/common';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatProgressBarModule } from '@angular/material/progress-bar'
import { MatPaginatorModule, MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableModule } from '@angular/material/table'
import { MatSortModule, Sort } from '@angular/material/sort';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { Npc } from './model/npc.model';
import { State } from '../store';
import { PageInformation } from '../core/model/page-information.model';
import { SortInformation } from '../core/model/sort-information.model';
import { ObservableDataSource } from '../core/model/observable-data-source';
import { Material } from '../core/model/material.model';
import { AttackType } from './model/attack-type.model';
import { DamageType } from '../core/model/damage-type.model';
import * as fromNpcsSelector from './store/npcs.selectors';
import * as fromNpcsActions from './store/npcs.actions';
import { EnumToStringPipe } from '../shared/pipes/enum-to-string.pipe';

@Component({
  selector: 'app-npc-dashboard',
  standalone: true,
  imports: [
    CommonModule,
    MatButtonModule,
    MatIconModule,
    MatMenuModule,
    MatPaginatorModule,
    MatProgressBarModule,
    MatTableModule,
    MatSortModule,
    EnumToStringPipe
  ],
  templateUrl: './npc-dashboard.component.html',
  styleUrl: './npc-dashboard.component.scss'
})
export class NpcDashboardComponent implements OnInit {
  readonly isLoading$: Observable<boolean>;
  readonly npcs$: Observable<Npc[]>;
  readonly dataSource$: ObservableDataSource<Npc>;
  readonly pageInformation$: Observable<PageInformation>;
  readonly sortInformation$: Observable<SortInformation>;

  displayedColumns: string[] = [
    'name',
    'strength',
    'vitality',
    'body',
    'agility',
    'dexterity',
    'intelligence',
    'willpower',
    'emotion',
    'karma',
    'hitPoint',
    'mana',
    'powerPoint',
    'race',
    'difficulity',
    'actions'
  ];

  @ViewChild(MatPaginator)paginator!: MatPaginator;

  constructor(private store$: Store<State>) {
    this.isLoading$ = this.store$.select(fromNpcsSelector.isLoadingSelector);
    this.npcs$ = this.store$.select(fromNpcsSelector.npcsSelector);
    this.dataSource$ = new ObservableDataSource(this.npcs$);
    this.pageInformation$ = this.store$.select(fromNpcsSelector.pageInformationSelector);
    this.sortInformation$ = this.store$.select(fromNpcsSelector.sortInformationSelector);
  }

  ngOnInit(): void {
    this.store$.dispatch(fromNpcsActions.loadNpcs());
  }

  onSortChanged(sort: Sort): void {
    this.store$.dispatch(fromNpcsActions.sortChanged({
      sortInformation: {
        sortDirection: sort.direction,
        sortProperty: sort.active
      }
    }));
  }

  onPageChanged(pageEvent: PageEvent): void {
    this.store$.dispatch(fromNpcsActions.pageChanged({
      pageIndex: pageEvent.pageIndex,
      pageSize: pageEvent.pageSize
    }));
  }

  onDelete(npcId: number): void {
    this.store$.dispatch(fromNpcsActions.deleteNpc({ npcId }));
  }

  getMaterial(material: Material): string {
    switch(material) {
      case Material.Leather:
        return 'Bőr';
      case Material.DragonHide:
        return 'Sárkánybőr';
      case Material.Wood:
        return 'Fa';
      case Material.Copper:
        return 'Réz';
      case Material.Gold:
        return 'Arany';
      case Material.Iron:
        return 'Vas';
      case Material.Steel:
        return 'Acél';
      case Material.Mithrill:
        return 'Mithrill';
      case Material.Adamar:
        return 'Adamár';
      case Material.Adamir:
        return 'Adamir';
      default:
        return '';
    }
  }

  getDamageTypes(attackTypes: AttackType[]): string {
    if (!attackTypes || attackTypes.length === 0) {
      return '';
    }

    let damageType: string = this.getDamageType(attackTypes[0].damageType);

    for (let index = 1; index < attackTypes.length; index++) {
      damageType = damageType + ', ' + this.getDamageType(attackTypes[index].damageType);
    }

    return damageType;
  }

  private getDamageType(damageType: DamageType): string {
    switch (damageType) {
      case DamageType.Bludgeoning:
        return 'Zúzó';
      case DamageType.Slashing:
        return 'Vágó';
      case DamageType.Stabbing:
        return 'Szúró';
      case DamageType.Dark:
        return 'Gonoszság';
      case DamageType.Light:
        return 'Jóság';
      case DamageType.Fire:
        return 'Tűz';
      case DamageType.Ice:
        return 'Jég';
      case DamageType.Lightning:
        return 'Villám';
      default:
        return '';
    }
  }
}