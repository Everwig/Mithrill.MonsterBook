import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatChipsModule } from '@angular/material/chips';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSelectChange, MatSelectModule } from '@angular/material/select';
import { MatSliderModule } from '@angular/material/slider';
import { MatSlideToggleModule } from '@angular/material/slide-toggle'
import { ActivatedRoute } from '@angular/router';
import { Store } from '@ngrx/store';

import { Race } from '../../core/model/race.model';
import { Difficulty } from '../../core/model/difficulty.model';
import { State } from '../../store';
import * as fromNpcsSelector from '../store/npcs.selectors';
import * as fromNpcsActions from '../store/npcs.actions';
import { map, Observable, Subscription } from 'rxjs';
import { Flaw } from '../models/flaw.model';
import { Skill } from '../models/skill.model';
import { Merit } from '../models/merit.model';
import { Armor } from '../models/armor.model';
import { Weapon } from '../models/weapon.model';
import { NpcTemplate } from '../models/npc-template.model';
import { DetailsViewMode } from '../../shared/models/details-view-mode.model';
import { SkillCategory } from '../../core/model/skill-category.model';
import { armorOnlyMaterials, Material } from '../../core/model/material.model';
import { baseDamageTypes, DamageType } from '../../core/model/damage-type.model';
import { AttackType } from '../models/attack-type.model';

@Component({
  selector: 'app-npc-template-details',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    MatButtonModule,
    MatChipsModule,
    MatExpansionModule,
    MatIconModule,
    MatInputModule,
    MatSelectModule,
    MatSliderModule,
    MatSlideToggleModule,
    ReactiveFormsModule
  ],
  templateUrl: './npc-template-details.component.html',
  styleUrl: './npc-template-details.component.scss'
})
export class NpcTemplateDetailsComponent implements OnInit {
  private subscriptions: Subscription = new Subscription();

  selectedSkill: Skill | undefined;
  selectedMerit: Merit | undefined;
  selectedFlaw: Flaw | undefined;
  selectedWeapon: Weapon | undefined;
  selectedArmor: Armor | undefined;
  selectedDamageType: AttackType | undefined;
  skillCategories: SkillCategory[] = [];
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
  readonly attackTypes$: Observable<AttackType[]>;
  readonly npcTemplate$: Observable<NpcTemplate | undefined>;
  readonly separatorKeysCodes: number[] = [ENTER, COMMA];

  constructor(private route: ActivatedRoute, private formBuilder: FormBuilder, private store$: Store<State>) {
    this.npcTemplateDetailsMode = DetailsViewMode.Create;
    this.flaws$ = this.store$.select(fromNpcsSelector.flawsSelector);
    this.merits$  = this.store$.select(fromNpcsSelector.meritsSelector);
    this.armors$ = this.store$.select(fromNpcsSelector.armorsSelector);
    this.weapons$ = this.store$.select(fromNpcsSelector.weaponsSelector);
    this.skills$ = this.store$.select(fromNpcsSelector.skillsSelector);
    this.attackTypes$ = this.store$.select(fromNpcsSelector.attackTypesSelector);
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
      armors: new FormControl([]),
      isUndead: new FormControl(false),
      skillCategories: new FormControl([])
    });
  }

  ngOnInit(): void {
    this.store$.dispatch(fromNpcsActions.loadFlaws());
    this.store$.dispatch(fromNpcsActions.loadMerits());
    this.store$.dispatch(fromNpcsActions.loadArmors());
    this.store$.dispatch(fromNpcsActions.loadWeapons());
    this.store$.dispatch(fromNpcsActions.loadSkills());
    this.store$.dispatch(fromNpcsActions.loadAttackTypes());

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

  getSkillCategories(): SkillCategory[] {
    const skillCategories: SkillCategory[] = Object.values(SkillCategory);
    const selectedCategories: SkillCategory[] = this.npcTemplateDetails.value.skillCategories;

    return skillCategories.filter(category => !selectedCategories.includes(category));
  }

  onSkillCategoryRemove(skillCategory: SkillCategory): void {
    const selectedCategories: SkillCategory[] = this.npcTemplateDetails.value.skillCategories;
    const updatedSkillCategories = selectedCategories.filter(category => category !== skillCategory);
    this.npcTemplateDetails.patchValue({ skillCategories: updatedSkillCategories });
  }

  onSkillCategory(matSelectChange: MatSelectChange): void {
    const skillCategory: SkillCategory = matSelectChange.value as SkillCategory;
    const selectedCategories: SkillCategory[] = this.npcTemplateDetails.value.skillCategories;
    this.npcTemplateDetails.patchValue({ skillCategories: selectedCategories.push(skillCategory) });
  }

  getMaxValueBaseOnRace(): number {
    const currentRace: Race = this.npcTemplateDetails.value.race;
    const isUndead: boolean = this.npcTemplateDetails.value.isUndead;

    switch(currentRace) {
      case Race.CreatureOfLight:
      case Race.CreatureOfDarkness:
        return isUndead ? 16 : 20;
      case Race.Mythical:
      case Race.Bug:
        return 30;
      case Race.Dragon:
        return 40;
      default:
        return 16;
    }
  }

  getFilteredSkills(): Observable<Skill[]> {
    return this.skills$.pipe(
      map(skills => skills.filter(skill => {
        const templateSkills: Skill[] = this.npcTemplateDetails.value.skills;
        return templateSkills.findIndex(s => s.id === skill.id) === -1;
      }))
    );
  }

  onSkillSelect(matSelectChange: MatSelectChange): void {
    const templateSkills: Skill[] = this.npcTemplateDetails.value.skills;
    templateSkills.push(matSelectChange.value as Skill);
    this.npcTemplateDetails.patchValue({ skills: templateSkills });
    setTimeout(() => this.selectedSkill = undefined, 100);
  }

  onRemoveSkill(id: number): void {
    const templateSkills: Skill[] = this.npcTemplateDetails.value.skills;
    this.npcTemplateDetails.patchValue({ skills: templateSkills.filter(skill => skill.id !== id) });
  }

  getFilteredMerits(): Observable<Merit[]> {
    return this.merits$.pipe(
      map(merits => merits.filter(merit => {
        const templateMerits: Merit[] = this.npcTemplateDetails.value.merits;
        return templateMerits.findIndex(m => m.id === merit.id);
      }))
    );
  }

  onMeritSelect(matSelectChange: MatSelectChange): void {
    const templateMerits: Merit[] = this.npcTemplateDetails.value.merits;
    templateMerits.push(matSelectChange.value as Merit);
    this.npcTemplateDetails.patchValue({ merits: templateMerits });
    setTimeout(() => this.selectedMerit = undefined, 100);
  }

  onRemoveMerit(id: number): void {
    const templateMerits: Merit[] = this.npcTemplateDetails.value.merits;
    this.npcTemplateDetails.patchValue({ merits: templateMerits.filter(merit => merit.id !== id) });
  }

  getFilteredFlaws(): Observable<Flaw[]> {
    return this.flaws$.pipe(
      map(flaws => flaws.filter(flaw => {
        const templateFlaws: Flaw[] = this.npcTemplateDetails.value.flaws;
        return templateFlaws.findIndex(f => f.id === flaw.id);
      }))
    );
  }

  onFlawSelect(matSelectChange: MatSelectChange): void {
    const templateFlaws: Flaw[] = this.npcTemplateDetails.value.flaws;
    templateFlaws.push(matSelectChange.value as Flaw);
    this.npcTemplateDetails.patchValue({ flaws: templateFlaws });
    setTimeout(() => this.selectedFlaw = undefined, 100);
  }

  onRemoveFlaw(id: number): void {
    const templateFlaws: Flaw[] = this.npcTemplateDetails.value.flaws;
    this.npcTemplateDetails.patchValue({ flaws: templateFlaws.filter(flaw => flaw.id !== id) });
  }

  getFilteredMaterialTypes(): Material[] {
    return Object.values(Material).filter(material => !armorOnlyMaterials.includes(material));
  }

  onWeaponSelect(matSelectChange: MatSelectChange): void {
    const templateWeapons: Weapon[] = this.npcTemplateDetails.value.weapons;
    templateWeapons.push(matSelectChange.value as Weapon);
    this.npcTemplateDetails.patchValue({ weapons: templateWeapons });
    setTimeout(() => this.selectedWeapon = undefined, 100);
  }

  onRemoveWeapon(weapon: Weapon): void {
    const templateWeapons: Weapon[] = this.npcTemplateDetails.value.weapons;
    this.npcTemplateDetails.patchValue({ weapons: templateWeapons.filter(w => w !== weapon) });
  }

  onDamageTypeSelect(matSelectChange: MatSelectChange, weapon: Weapon): void {
    const damageType: DamageType = matSelectChange.value as DamageType;

    weapon.attackTypes.push({
      damageType: damageType,
      guaranteedDamage: 0,
      id: 0,
      isBaseAttackType: false,
      numberOfDices: 0
    });

    setTimeout(() => this.selectedDamageType = undefined, 100);
  }

  getFilteredDamageTypes(attackTypes: AttackType[]): DamageType[] {
    const selectedDamage: DamageType[] = attackTypes.map(attackType => attackType.damageType);

    return Object.values(DamageType)
      .filter(damageType => !selectedDamage.includes(damageType))
      .filter(damageType => !baseDamageTypes.includes(damageType));
  }

  getBaseAttackTypes(attackTypes: AttackType[]): string {
    const baseAttackType: AttackType = attackTypes.filter(attackType => attackType.isBaseAttackType)[0];

    if (baseAttackType) {
      return `${baseAttackType.damageType} (${baseAttackType.numberOfDices}D6` +
        `${baseAttackType.guaranteedDamage === 0 ? '' : '+' + baseAttackType.guaranteedDamage})`;
    }

    return '0';
  }

  getAdditionalAttackTypes(attackTypes: AttackType[]): AttackType[] {
    return attackTypes.filter(attackType => !attackType.isBaseAttackType);
  }

  onAttackTypeDamageChange(numberOfDices: number, attackType: AttackType): void {
    attackType.numberOfDices = numberOfDices;
  }

  onAttackTypeRemove(attackType: AttackType, weapon: Weapon): void {
    weapon.attackTypes = weapon.attackTypes.filter(aT => aT !== attackType);
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
          race: npcTemplate.race,
          difficulty: npcTemplate.difficulty,
          skills: npcTemplate.skills,
          merits: npcTemplate.merits,
          flaws: npcTemplate.flaws,
          weapons: npcTemplate.weapons,
          armors: npcTemplate.armors,
          isUndead: npcTemplate.isUndead
        });


        this.hitPointMin = npcTemplate.hitPointMin;
        this.hitPointMax = npcTemplate.hitPointMax;
        this.manaPointMin = npcTemplate.manaPointMin;
        this.manaPointMax = npcTemplate.manaPointMax;
        this.powerPointMin = npcTemplate.powerPointMin;
        this.powerPointMax = npcTemplate.powerPointMax;
      }
    }));
  }
}