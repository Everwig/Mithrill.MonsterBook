import { Routes } from '@angular/router';
import { provideState } from '@ngrx/store';
import { provideEffects } from '@ngrx/effects';

import * as fromNpcs from './npc-dashboard/store/npcs.reducer';
import { NpcsEffects } from './npc-dashboard/store/npcs.effects';
import { NpcDashboardService } from './npc-dashboard/services/npc-dashboard.service';
import { ArmorsClient, FlawsClient, MeritsClient, NpcsClient, SkillsClient, WeaponsClient } from './shared/services/web-api-client';
import { NpcTemplateDetailsService } from './npc-dashboard/services/npc-template-details.service';

export const routes: Routes = [
  {
    path: "npcs/:id",
    loadComponent: () => import('./npc-dashboard/npc-template-details/npc-template-details.component').then(mod => mod.NpcTemplateDetailsComponent),
    providers: [
      provideState(fromNpcs.npcsFeatureKey, fromNpcs.reducer),
      provideEffects(NpcsEffects),
      NpcTemplateDetailsService,
      NpcDashboardService,
      NpcsClient,
      SkillsClient,
      MeritsClient,
      FlawsClient,
      ArmorsClient,
      WeaponsClient
    ]
  },
  {
    path: 'npcs',
    loadComponent: () => import('./npc-dashboard/npc-dashboard.component').then(mod => mod.NpcDashboardComponent),
    providers: [
      provideState(fromNpcs.npcsFeatureKey, fromNpcs.reducer),
      provideEffects(NpcsEffects),
      NpcDashboardService,
      NpcTemplateDetailsService,
      NpcsClient,
      SkillsClient,
      MeritsClient,
      FlawsClient,
      ArmorsClient,
      WeaponsClient
    ]
  },
  { path: '**', redirectTo: 'npcs' }
];
