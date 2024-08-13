import { ApplicationConfig, provideZoneChangeDetection, isDevMode } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideClientHydration } from '@angular/platform-browser';
import { provideAnimations } from '@angular/platform-browser/animations';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { provideStore } from '@ngrx/store';
import { metaReducers, reducers } from './store';
import { provideStoreDevtools } from '@ngrx/store-devtools';
import { provideEffects } from '@ngrx/effects';
import { API_BASE_URL, NpcClient } from './shared/services/web-api-client';
import { provideHttpClient } from '@angular/common/http';
import { NpcsEffects } from './npc-dashboard/store/npcs.effects';
import { NpcDashboardService } from './npc-dashboard/services/npc-dashboard.service';

export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes),
    provideClientHydration(),
    provideAnimations(),
    provideAnimationsAsync(),
    provideStore(reducers, {
        metaReducers,
        runtimeChecks: {
            strictActionImmutability: false,
            strictStateImmutability: false
        }
    }),
    provideStoreDevtools({ maxAge: 25, logOnly: !isDevMode() }),
    provideEffects(),
    provideHttpClient(),
    { provide: API_BASE_URL, useValue: 'https://localhost:44333' }
]
};
