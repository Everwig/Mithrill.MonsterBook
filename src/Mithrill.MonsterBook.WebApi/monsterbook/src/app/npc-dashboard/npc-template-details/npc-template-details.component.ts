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
import { MatSlideToggleChange, MatSlideToggleModule } from '@angular/material/slide-toggle'
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
import { ArcanumRanks, NpcTemplate } from '../models/npc-template.model';
import { DetailsViewMode } from '../../shared/models/details-view-mode.model';
import { SkillCategory } from '../../core/model/skill-category.model';
import { armorOnlyMaterials, Material } from '../../core/model/material.model';
import { baseDamageTypes, DamageType } from '../../core/model/damage-type.model';
import { AttackType } from '../models/attack-type.model';
import { SkillCategories } from '../../core/model/skill-categories.model';
import { CategoryNumber } from '../../core/model/category-number.model';
import { Arcanum } from '../../core/model/arcanum.model';

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

  primarySkillCategory: SkillCategory | undefined;
  secondarySkillCategories: SkillCategory[] = [];
  tertiarySkillCategory: SkillCategory | undefined;
  primaryArcanum: Arcanum | undefined;
  secondaryArcanum: Arcanum | undefined;
  tertiaryArcanum: Arcanum[] = [];
  quaternaryArcanum: Arcanum | undefined;
  quinaryArcanum: Arcanum | undefined;
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

  readonly flaws$: Observable<Flaw[]>;
  readonly merits$: Observable<Merit[]>;
  readonly armors$: Observable<Armor[]>;
  readonly weapons$: Observable<Weapon[]>;
  readonly skills$: Observable<Skill[]>;
  readonly attackTypes$: Observable<AttackType[]>;
  readonly hitPointMin$: Observable<number>;
  readonly hitPointMax$: Observable<number>;
  readonly manaPointMin$: Observable<number>;
  readonly manaPointMax$: Observable<number>;
  readonly powerPointMin$: Observable<number>;
  readonly powerPointMax$: Observable<number>;
  readonly npcTemplate$: Observable<NpcTemplate | undefined>;
  readonly separatorKeysCodes: number[] = [ENTER, COMMA];
  readonly categoryNumbers = CategoryNumber;
  private readonly timeOut = 150;
  private readonly wizardUniversity = "Wizarding university";
  private readonly magicChalice = "Magic chalice";
  private readonly undead = "Undead";
  private readonly tough = "Tough";
  private readonly arcane = "arcane";
  private readonly maxSecondarySkillCategories = 2;
  private readonly maxTertiaryArcanums = 5;

  constructor(private route: ActivatedRoute, private formBuilder: FormBuilder, private store$: Store<State>) {
    this.npcTemplateDetailsMode = DetailsViewMode.Create;
    this.flaws$ = this.store$.select(fromNpcsSelector.flawsSelector);
    this.merits$  = this.store$.select(fromNpcsSelector.meritsSelector);
    this.armors$ = this.store$.select(fromNpcsSelector.armorsSelector);
    this.weapons$ = this.store$.select(fromNpcsSelector.weaponsSelector);
    this.skills$ = this.store$.select(fromNpcsSelector.skillsSelector);
    this.attackTypes$ = this.store$.select(fromNpcsSelector.attackTypesSelector);
    this.npcTemplate$ = this.store$.select(fromNpcsSelector.npcTemplateSelector);
    this.hitPointMax$ = this.store$.select(fromNpcsSelector.hitPointMax);
    this.hitPointMin$ = this.store$.select(fromNpcsSelector.hitPointMin);
    this.manaPointMax$ = this.store$.select(fromNpcsSelector.manaPointMax);
    this.manaPointMin$ = this.store$.select(fromNpcsSelector.manaPointMin);
    this.powerPointMax$ = this.store$.select(fromNpcsSelector.powerPointMax);
    this.powerPointMin$ = this.store$.select(fromNpcsSelector.powerPointMin);

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
      skillCategories: new FormControl(undefined),
      arcanumRanks: new FormControl(undefined)
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

  onIsUndeadChange(matSlideToggleChange: MatSlideToggleChange): void {
    this.npcTemplateDetails.patchValue({
      isUndead: matSlideToggleChange.checked
    });

    this.triggerHitPointRecalculation();
  }

  getSkillCategories(skillCategoryNumbers: CategoryNumber): SkillCategory[] {
    let skillCategories: SkillCategory[] = Object.values(SkillCategory);
    const currentSkillCategories = this.npcTemplateDetails.value.skillCategories as SkillCategories;
    if (!currentSkillCategories) {
      return skillCategories;
    }

    const selectedSkillCategories: SkillCategory[] = [
      skillCategoryNumbers === CategoryNumber.Primary ? undefined : currentSkillCategories.primary,
      skillCategoryNumbers === CategoryNumber.Secondry ? undefined : currentSkillCategories.firstSecondary,
      skillCategoryNumbers === CategoryNumber.Secondry ? undefined : currentSkillCategories.secondSecondary,
      skillCategoryNumbers === CategoryNumber.Tertiary ? undefined : currentSkillCategories.tertiary
    ].filter(skillCategory => skillCategory !== undefined);

    return skillCategories.filter(category => !selectedSkillCategories.includes(category));
  }

  onSkillCategorySelect(matSelectChange: MatSelectChange, skillCategoryNumbers: CategoryNumber): void {
    const selectedCategories: SkillCategories = this.npcTemplateDetails.value.skillCategories;
    if (skillCategoryNumbers === CategoryNumber.Primary) {
      selectedCategories.primary = matSelectChange.value;
    }

    if (skillCategoryNumbers === CategoryNumber.Tertiary) {
      selectedCategories.tertiary = matSelectChange.value;
    }

    if (skillCategoryNumbers === CategoryNumber.Secondry) {
      const selection = matSelectChange.value as SkillCategories[];
      if (selection.length === 0) {
        selectedCategories.firstSecondary = undefined;
        selectedCategories.secondSecondary = undefined;
      } else {
        selectedCategories.firstSecondary = selection[0] as unknown as SkillCategory;
        selectedCategories.secondSecondary = selection[1] ? selection[1] as unknown as SkillCategory : undefined;
      }
    }

    this.npcTemplateDetails.patchValue({ skillCategories: selectedCategories });
  }

  isSkillCategoryOptionDisabled(skillCategory: SkillCategory): boolean {
    return !this.secondarySkillCategories.includes(skillCategory) && this.secondarySkillCategories.length === this.maxSecondarySkillCategories;
  }

  isArcanumRankOptionDisabled(arcanum: Arcanum): boolean {
    return !this.tertiaryArcanum.includes(arcanum) && this.tertiaryArcanum.length === this.maxTertiaryArcanums;
  }

  getArcanums(arcanumRankNumber: CategoryNumber): Arcanum[] {
    let arcanumRanks: Arcanum[] = Object.values(Arcanum);
    const currentArcanumRanks = this.npcTemplateDetails.value.arcanumRanks as ArcanumRanks;
    if (!currentArcanumRanks) {
      return arcanumRanks;
    }

    const selectedArcanumRanks: Arcanum[] = [
      arcanumRankNumber === CategoryNumber.Primary ? undefined : currentArcanumRanks.primary,
      arcanumRankNumber === CategoryNumber.Secondry ? undefined : currentArcanumRanks.secondary,
      ...(arcanumRankNumber === CategoryNumber.Tertiary ? [] : currentArcanumRanks.tertiary),
      arcanumRankNumber === CategoryNumber.Quaternary ? undefined : currentArcanumRanks.quaternary,
      arcanumRankNumber === CategoryNumber.Quinary ? undefined : currentArcanumRanks.quinary,
    ].filter(arcanumRank => arcanumRank !== undefined);

    return arcanumRanks.filter(arcanumRank => !selectedArcanumRanks.includes(arcanumRank));
  }

  onArcanumSelect(matSelectChange: MatSelectChange, arcanumRankNumber: CategoryNumber): void {
    const currentArcanumRanks = this.npcTemplateDetails.value.arcanumRanks as ArcanumRanks;

    switch(arcanumRankNumber) {
      case CategoryNumber.Primary:
        currentArcanumRanks.primary = matSelectChange.value;
        break;
      case CategoryNumber.Secondry:
        currentArcanumRanks.secondary = matSelectChange.value;
        break;
      case CategoryNumber.Tertiary:
        if (this.tertiaryArcanum.length > 1 && !this.doesNpcHaveMagicUniversityMerit(this.npcTemplateDetails.value.merits)) {
          this.tertiaryArcanum = [matSelectChange.value];
          currentArcanumRanks.tertiary = [matSelectChange.value]
        } else if (this.doesNpcHaveMagicUniversityMerit(this.npcTemplateDetails.value.merits)) {
          currentArcanumRanks.tertiary = matSelectChange.value;
        } else {
          currentArcanumRanks.tertiary = [matSelectChange.value]
        }
        break;
      case CategoryNumber.Quaternary:
        currentArcanumRanks.quaternary = matSelectChange.value;
        break;
      case CategoryNumber.Quinary:
        currentArcanumRanks.quinary = matSelectChange.value;
        break;
    }

    this.npcTemplateDetails.patchValue({ arcanumRanks: currentArcanumRanks });
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
    setTimeout(() => this.selectedSkill = undefined, this.timeOut);
  }

  onRemoveSkill(id: number): void {
    const templateSkills: Skill[] = this.npcTemplateDetails.value.skills;
    this.npcTemplateDetails.patchValue({ skills: templateSkills.filter(skill => skill.id !== id) });
  }

  getFilteredMerits(): Observable<Merit[]> {
    return this.merits$.pipe(
      map(merits => {
        const templateMeritsIds: number[] = this.npcTemplateDetails.value.merits.map((merit: Merit) => merit.id);
        return merits.filter(merit => !templateMeritsIds.includes(merit.id));
      })
    );
  }

  onMeritSelect(matSelectChange: MatSelectChange): void {
    const templateMerits: Merit[] = this.npcTemplateDetails.value.merits;
    const selectedMerit: Merit = matSelectChange.value as Merit;
    setTimeout(() => this.selectedMerit = undefined, this.timeOut);

    if (this.npcTemplateDetails.value.arcanumRanks &&
        this.doesNpcHaveMagicUniversityMerit([selectedMerit]) &&
        !this.doesNpcHaveMagicUniversityMerit(templateMerits)) {
      templateMerits.push(selectedMerit);
      this.tertiaryArcanum = [...this.tertiaryArcanum, this.quaternaryArcanum!, this.quinaryArcanum!]
        .filter(arcanum => arcanum !== undefined);

      this.quaternaryArcanum = undefined;
      this.quinaryArcanum = undefined;
      this.npcTemplateDetails.patchValue({
        merits: templateMerits,
        arcanumRanks: ({
          ...this.npcTemplateDetails.value.arcanumRanks,
          tertiary: [
            ...this.npcTemplateDetails.value.arcanumRanks.tertiary,
            this.npcTemplateDetails.value.arcanumRanks.quaternary,
            this.npcTemplateDetails.value.arcanumRanks.quinary
          ].filter(arcanum => arcanum !== undefined),
          quaternary: undefined,
          quinary: undefined
        }) as ArcanumRanks
      });
    } else {
      templateMerits.push(selectedMerit);
      this.npcTemplateDetails.patchValue({ merits: templateMerits });
    }

    this.updateTemplateBasedOnMerit(selectedMerit);
  }

  onRemoveMerit(merit: Merit): void {
    const templateMerits: Merit[] = this.npcTemplateDetails.value.merits;
    this.npcTemplateDetails.patchValue({ merits: templateMerits.filter(m => m.id !== merit.id) });

    if (this.doesNpcHaveMagicUniversityMerit([merit])) {
      this.tertiaryArcanum = [this.tertiaryArcanum[0]];
    }
  }

  getFilteredFlaws(): Observable<Flaw[]> {
    return this.flaws$.pipe(
      map(flaws => {
        const templateFlawIds: number[] = this.npcTemplateDetails.value.flaws.map((flaw: Flaw) => flaw.id);
        return flaws.filter(flaw => !templateFlawIds.includes(flaw.id));
      })
    );
  }

  onFlawSelect(matSelectChange: MatSelectChange): void {
    const templateFlaws: Flaw[] = this.npcTemplateDetails.value.flaws;
    templateFlaws.push(matSelectChange.value as Flaw);
    this.npcTemplateDetails.patchValue({ flaws: templateFlaws });
    setTimeout(() => this.selectedFlaw = undefined, this.timeOut);
  }

  onRemoveFlaw(id: number): void {
    const templateFlaws: Flaw[] = this.npcTemplateDetails.value.flaws;
    this.npcTemplateDetails.patchValue({ flaws: templateFlaws.filter(flaw => flaw.id !== id) });
  }

  getMaterialTypes(): Material[] {
    return Object.values(Material);
  }

  getFilteredMaterialTypes(): Material[] {
    return this.getMaterialTypes().filter(material => !armorOnlyMaterials.includes(material));
  }

  onWeaponSelect(matSelectChange: MatSelectChange): void {
    const templateWeapons: Weapon[] = this.npcTemplateDetails.value.weapons;
    templateWeapons.push(matSelectChange.value as Weapon);
    this.npcTemplateDetails.patchValue({ weapons: templateWeapons });
    setTimeout(() => this.selectedWeapon = undefined, this.timeOut);
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

    setTimeout(() => this.selectedDamageType = undefined, this.timeOut);
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

  onArmorSelect(matSelectChange: MatSelectChange): void {
    const templateArmors: Armor[] = this.npcTemplateDetails.value.armors;
    templateArmors.push(matSelectChange.value as Armor);
    this.npcTemplateDetails.patchValue({ armors: templateArmors });
    setTimeout(() => this.selectedArmor = undefined, this.timeOut);
  }

  onRemoveArmor(armor: Armor): void {
    const templateArmors: Armor[] = this.npcTemplateDetails.value.armors;
    this.npcTemplateDetails.patchValue({ armors: templateArmors.filter(a => a !== armor) });
  }

  doesNpcHaveMagicUniversityMerit(merits: Merit[]): boolean {
    return merits.findIndex(merit => merit.name === this.wizardUniversity) > -1;
  }

  doesNpcHaveArcanums(): boolean {
    return (this.npcTemplateDetails.value.skills as Skill[]).findIndex(skill => skill.name.endsWith(this.arcane)) > -1;
  }

  onStrengthChange(): void {
    if (this.npcTemplateDetails.value.isUndead) {
      this.triggerHitPointRecalculation();
    }
  }

  updateTemplateBasedOnMerit(merit: Merit): void {
    switch(merit.name) {
      case this.magicChalice:
        this.triggerManaPointRecalculation();
        break;
      case this.undead:
        this.npcTemplateDetails.patchValue({
          isUndead: true
        });
        this.triggerHitPointRecalculation();
        break;
      case this.tough:
        this.triggerHitPointRecalculation();
        break;
    }
  }

  triggerManaPointRecalculation(): void {
    const npcTemplate: NpcTemplate = this.npcTemplateDetails.value as NpcTemplate;
    this.store$.dispatch(fromNpcsActions.calculateManaPointMinMaxValues({
      emotionMax: npcTemplate.emotionMax,
      emotionMin: npcTemplate.emotionMin,
      intelligenceMax: npcTemplate.intelligenceMax,
      intelligenceMin: npcTemplate.intelligenceMin,
      meritIds: npcTemplate.merits.map(merit => merit.id),
      willpowerMax: npcTemplate.willpowerMax,
      willpowerMin: npcTemplate.willpowerMin
    }));
  }

  triggerHitPointRecalculation(): void {
    const npcTemplate: NpcTemplate = this.npcTemplateDetails.value as NpcTemplate;
    this.store$.dispatch(fromNpcsActions.calculateHitPointMinMaxValues({
      bodyMax: npcTemplate.bodyMax,
      bodyMin: npcTemplate.bodyMin,
      isUndead: npcTemplate.isUndead,
      meritIds: npcTemplate.merits.map(merit => merit.id),
      strengthMax: npcTemplate.strengthMax,
      strengthMin: npcTemplate.strengthMin
    }));
  }

  triggerPowerPointRecalculation(): void {
    const npcTemplate: NpcTemplate = this.npcTemplateDetails.value as NpcTemplate;
    this.store$.dispatch(fromNpcsActions.calculatePowerPointMinMaxValues({
      karmaMax: npcTemplate.karmaMax,
      karmaMin: npcTemplate.karmaMin
    }));
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
          isUndead: npcTemplate.isUndead,
          skillCategories: npcTemplate.skillCategories,
          arcanumRanks: npcTemplate.arcanumRanks
        });

        this.primarySkillCategory = npcTemplate.skillCategories?.primary;
        this.secondarySkillCategories.push(
          npcTemplate.skillCategories?.firstSecondary!,
          npcTemplate.skillCategories?.secondSecondary!);
        this.tertiarySkillCategory = npcTemplate.skillCategories?.tertiary;
        this.primaryArcanum = npcTemplate.arcanumRanks?.primary;
        this.secondaryArcanum = npcTemplate.arcanumRanks?.secondary;
        this.tertiaryArcanum = npcTemplate.arcanumRanks?.tertiary ?? [];
        this.quaternaryArcanum = npcTemplate.arcanumRanks?.quaternary;
        this.quinaryArcanum = npcTemplate.arcanumRanks?.quinary;
      }
    }));
  }
}