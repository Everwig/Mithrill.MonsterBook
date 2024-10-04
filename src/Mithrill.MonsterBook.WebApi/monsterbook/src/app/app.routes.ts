import { Routes } from '@angular/router';
import { provideState } from '@ngrx/store';
import { provideEffects } from '@ngrx/effects';

import * as fromNpcs from './npc-dashboard/store/npcs.reducer';
import { NpcsEffects } from './npc-dashboard/store/npcs.effects';
import { NpcDashboardService } from './npc-dashboard/services/npc-dashboard.service';
import { NpcClient } from './shared/services/web-api-client';

export const routes: Routes = [
  {
    path: 'npcs',
    loadComponent: () => import('./npc-dashboard/npc-dashboard.component').then(mod => mod.NpcDashboardComponent),
    providers: [
      provideState(fromNpcs.npcsFeatureKey, fromNpcs.reducer),
      provideEffects(NpcsEffects),
      NpcDashboardService,
      NpcClient
    ]
  },
  { path: '**', redirectTo: 'npcs' }
];
