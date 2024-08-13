import { Routes } from '@angular/router';

import * as fromNpcs from './npc-dashboard/store/npcs.reducer';
import { provideState } from '@ngrx/store';
import { Actions, provideEffects } from '@ngrx/effects';
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
