import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatSliderModule } from '@angular/material/slider';
import { ActivatedRoute } from '@angular/router';
import { Store } from '@ngrx/store';

import { Race } from '../../core/model/race.model';
import { Difficulty } from '../../core/model/difficulty.model';
import { State } from '../../store';
import * as fromNpcsSelector from '../store/npcs.selectors';
import * as fromNpcsActions from '../store/npcs.actions';
import { NpcTemplateDetailsService } from '../services/npc-template-details.service';
import { Observable, Subscription } from 'rxjs';
import { Flaw } from '../models/flaw.model';
import { Skill } from '../models/skill.model';
import { Merit } from '../models/merit.model';
import { Armor } from '../models/armor.model';
import { Weapon } from '../models/weapon.model';
import { Npc } from '../models/npc.model';
import { DetailsViewMode } from '../../shared/models/details-view-mode.model';

@Component({
  selector: 'app-npc-template-details',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    MatInputModule,
    MatSelectModule,
    MatSliderModule,
    ReactiveFormsModule
  ],
  templateUrl: './npc-template-details.component.html',
  styleUrl: './npc-template-details.component.scss'
})
export class NpcTemplateDetailsComponent implements OnInit {
  private subscriptions: Subscription = new Subscription();

  npcTemplateDetails: FormGroup;
  npcTemplateDetailsMode: DetailsViewMode;
  race = Race;
  difficulty = Difficulty;
  hitPointMin: number = 0;
  hitPointMax: number = 0;
  manaPointMin: number = 0;
  manaPointMax: number = 0;
  powerPointMin: number = 0;
  powerPointMax: number = 0;

  readonly flaws$: Observable<Flaw[]>;
  readonly merits$: Observable<Merit[]>;
  readonly armors$: Observable<Armor[]>;
  readonly weapons$: Observable<Weapon[]>;
  readonly skills$: Observable<Skill[]>;
  readonly npcTemplate$: Observable<Npc | undefined>;

  constructor(private route: ActivatedRoute, private formBuilder: FormBuilder, private store$: Store<State>) {
    this.npcTemplateDetailsMode = DetailsViewMode.Create;
    this.flaws$ = this.store$.select(fromNpcsSelector.flawsSelector);
    this.merits$  = this.store$.select(fromNpcsSelector.meritsSelector);
    this.armors$ = this.store$.select(fromNpcsSelector.armorsSelector);
    this.weapons$ = this.store$.select(fromNpcsSelector.weaponsSelector);
    this.skills$ = this.store$.select(fromNpcsSelector.skillsSelector);
    this.npcTemplate$ = this.store$.select(fromNpcsSelector.npcTemplateSelector);

    this.npcTemplateDetails = this.formBuilder.group({
      id: new FormControl(null),
      name: new FormControl(null),
      strengthMax: new FormControl(null),
      strengthMin: new FormControl(null),
      vitalityMax: new FormControl(null),
      vitalityMin: new FormControl(null),
      bodyMax: new FormControl(null),
      bodyMin: new FormControl(null),
      agilityMax: new FormControl(null),
      agilityMin: new FormControl(null),
      dexterityMax: new FormControl(null),
      dexterityMin: new FormControl(null),
      intelligenceMax: new FormControl(null),
      intelligenceMin: new FormControl(null),
      willpowerMax: new FormControl(null),
      willpowerMin: new FormControl(null),
      emotionMax: new FormControl(null),
      emotionMin: new FormControl(null),
      karmaMax: new FormControl(null),
      karmaMin: new FormControl(null),
      race: new FormControl(Race.CivilizedHuman),
      difficulty: new FormControl(Difficulty.Newbie),
      skills: new FormControl([]),
      merits: new FormControl([]),
      flaws: new FormControl([]),
      weapons: new FormControl([]),
      armors: new FormControl([])
    });
  }

  ngOnInit(): void {
    this.store$.dispatch(fromNpcsActions.loadFlaws());
    this.store$.dispatch(fromNpcsActions.loadMerits());
    this.store$.dispatch(fromNpcsActions.loadArmors());
    this.store$.dispatch(fromNpcsActions.loadWeapons());
    this.store$.dispatch(fromNpcsActions.loadSkills());

    const routeSubscription = this.route.paramMap.subscribe(paramMap => {
      if (paramMap.has('id')) {
        const id = Number(paramMap.get('id'));
        this.npcTemplateDetailsMode = DetailsViewMode.Edit;
        this.store$.dispatch(fromNpcsActions.loadNpcTemplate({ id }));
        this.updateFormInEditMode()
      } else {
        this.npcTemplateDetailsMode = DetailsViewMode.Create;
        this.store$.dispatch(fromNpcsActions.clearTemplate());
      }
    });

    this.subscriptions.add(routeSubscription);
  }

  getMaxValueBaseOnRace(): number {
    const currentRace: Race = this.npcTemplateDetails.controls['race'].value;

    switch(currentRace) {
      case Race.CreatureOfLight:
      case Race.CreatureOfDarkness:
        return 20;
      case Race.Mythical:
      case Race.Bug:
        return 30;
      case Race.Dragon:
        return 40;
      default:
        return 16;
    }
  }

  private updateFormInEditMode(): void {
    this.subscriptions.add(this.npcTemplate$.subscribe((npcTemplate) => {
      if (npcTemplate) {
        this.npcTemplateDetails.patchValue({
          id: npcTemplate.id,
          name: npcTemplate.name,
          strengthMin: npcTemplate.strengthMin,
          strengthMax: npcTemplate.strengthMax,
          vitalityMin: npcTemplate.vitalityMin,
          vitalityMax: npcTemplate.vitalityMax,
          bodyMin: npcTemplate.bodyMin,
          bodyMax: npcTemplate.bodyMax,
          agilityMin: npcTemplate.agilityMin,
          agilityMax: npcTemplate.agilityMax,
          dexterityMin: npcTemplate.dexterityMin,
          dexterityMax: npcTemplate.dexterityMax,
          intelligenceMin: npcTemplate.intelligenceMin,
          intelligenceMax: npcTemplate.intelligenceMax,
          willpowerMin: npcTemplate.willpowerMin,
          willpowerMax: npcTemplate.willpowerMax,
          emotionMin: npcTemplate.emotionMin,
          emotionMax: npcTemplate.emotionMax,
          karmaMin: npcTemplate.karmaMin,
          karmaMax: npcTemplate.karmaMax,
          hitPointMin: npcTemplate.hitPointMin,
          hitPointMax: npcTemplate.hitPointMax,
          manaMin: npcTemplate.manaMin,
          manaMax: npcTemplate.manaMax,
          powerPointMin: npcTemplate.powerPointMin,
          powerPointMax: npcTemplate.powerPointMax,
          race: npcTemplate.race,
          difficulty: npcTemplate.difficulty,
          skills: npcTemplate.skills,
          merits: npcTemplate.merits,
          flaws: npcTemplate.flaws,
          weapons: npcTemplate.weapons,
          armors: npcTemplate.armors
        });
      }
    }))
  }
}