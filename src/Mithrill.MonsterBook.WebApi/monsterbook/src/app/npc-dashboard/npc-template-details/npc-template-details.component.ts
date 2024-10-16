import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormArray, FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatChipsModule } from '@angular/material/chips';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatMenuModule } from '@angular/material/menu';
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
import { OverlayModule } from '@angular/cdk/overlay';

@Component({
  selector: 'app-npc-template-details',
  standalone: true,
  imports: [
    CommonModule,
    OverlayModule,
    FormsModule,
    MatButtonModule,
    MatChipsModule,
    MatExpansionModule,
    MatIconModule,
    MatInputModule,
    MatMenuModule,
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
  menuToggle: boolean = false;

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

  get skills(): FormArray {
    return this.npcTemplateDetails.controls['skills'] as FormArray;
  }

  get merits(): FormArray {
    return this.npcTemplateDetails.controls['merits'] as FormArray;
  }

  get flaws(): FormArray {
    return this.npcTemplateDetails.controls['flaws'] as FormArray;
  }

  get weapons():FormArray {
    return this.npcTemplateDetails.controls['weapons'] as FormArray;
  }

  get armors(): FormArray {
    return this.npcTemplateDetails.controls['armors'] as FormArray;
  }

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
      skills: new FormArray([]),
      merits: new FormArray([]),
      flaws: new FormArray([]),
      weapons: new FormArray([]),
      armors: new FormArray([]),
      isUndead: new FormControl(false),
      skillCategories: new FormControl(undefined),
      arcanumRanks: new FormControl(undefined)
    });

    this.subscriptions.add(this.npcTemplateDetails.valueChanges.subscribe(value => console.log(value)));
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

  toggleMenu(): void {
    this.menuToggle = !this.menuToggle;
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
        const templateSkills: Skill[] = this.skills.value;
        return templateSkills.findIndex(s => s.id === skill.id) === -1;
      }))
    );
  }

  onSkillSelect(matSelectChange: MatSelectChange): void {
    const selectedSkill = matSelectChange.value as Skill;
    this.addSkills([selectedSkill], true);
    setTimeout(() => this.selectedSkill = undefined, this.timeOut);
  }

  onRemoveSkill(index: number): void {
    this.skills.removeAt(index);
  }

  getFilteredMerits(): Observable<Merit[]> {
    return this.merits$.pipe(
      map(merits => {
        const templateMeritsIds: number[] = this.merits.value.map((merit: Merit) => merit.id);
        return merits.filter(merit => !templateMeritsIds.includes(merit.id));
      })
    );
  }

  onMeritSelect(matSelectChange: MatSelectChange): void {
    const templateMerits: Merit[] = this.merits.value;
    const selectedMerit: Merit = matSelectChange.value as Merit;
    setTimeout(() => this.selectedMerit = undefined, this.timeOut);

    if (this.npcTemplateDetails.value.arcanumRanks &&
        this.doesNpcHaveMagicUniversityMerit([selectedMerit]) &&
        !this.doesNpcHaveMagicUniversityMerit(templateMerits)) {
      this.tertiaryArcanum = [...this.tertiaryArcanum, this.quaternaryArcanum!, this.quinaryArcanum!]
        .filter(arcanum => arcanum !== undefined);

      this.quaternaryArcanum = undefined;
      this.quinaryArcanum = undefined;
      this.npcTemplateDetails.patchValue({
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
      }, { emitEvent: false });
    }

    this.addMerits([selectedMerit], true);
    this.updateTemplateBasedOnMerit(selectedMerit);
  }

  onRemoveMerit(index: number): void {
    const merit = this.merits.value[index] as Merit;
    this.merits.removeAt(index);

    if (this.doesNpcHaveMagicUniversityMerit([merit])) {
      this.tertiaryArcanum = [this.tertiaryArcanum[0]];
    }
  }

  getFilteredFlaws(): Observable<Flaw[]> {
    return this.flaws$.pipe(
      map(flaws => {
        const templateFlawIds: number[] = this.flaws.value.map((flaw: Flaw) => flaw.id);
        return flaws.filter(flaw => !templateFlawIds.includes(flaw.id));
      })
    );
  }

  onFlawSelect(matSelectChange: MatSelectChange): void {
    const selectedFlaw: Flaw = matSelectChange.value;
    this.addFlaws([selectedFlaw], true);
    setTimeout(() => this.selectedFlaw = undefined, this.timeOut);
  }

  onRemoveFlaw(index: number): void {
    this.flaws.removeAt(index);
  }

  getMaterialTypes(): Material[] {
    return Object.values(Material);
  }

  getFilteredMaterialTypes(): Material[] {
    return this.getMaterialTypes().filter(material => !armorOnlyMaterials.includes(material));
  }

  onWeaponSelect(matSelectChange: MatSelectChange): void {
    const selectedWeapon: Weapon = matSelectChange.value as Weapon;
    this.addWeapons([selectedWeapon], true);
    setTimeout(() => this.selectedWeapon = undefined, this.timeOut);
  }

  onRemoveWeapon(index: number): void {
    this.weapons.removeAt(index);
  }

  onDamageTypeSelect(matSelectChange: MatSelectChange, weapon: AbstractControl): void {
    const damageType: DamageType = matSelectChange.value as DamageType;
    const currentAttackTypes: AttackType[] = (weapon.value as Weapon).attackTypes;
    currentAttackTypes.push({
      damageType: damageType,
      guaranteedDamage: 0,
      id: 0,
      isBaseAttackType: false,
      numberOfDices: 0
    });

    weapon.patchValue({ attackTypes: currentAttackTypes });
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

  onAttackTypeDamageChange(numberOfDices: number, damageType: DamageType, weapon: AbstractControl): void {
    const currentAttackTypes: AttackType[] = (weapon.value as Weapon).attackTypes;
    currentAttackTypes.forEach(attackType => {
      if (attackType.damageType === damageType) {
        attackType.numberOfDices = numberOfDices;
      }
    });

    weapon.patchValue({ attackTypes: currentAttackTypes });
  }

  onAttackTypeRemove(attackType: AttackType, weapon: AbstractControl): void {
    const currentAttackTypes: AttackType[] = (weapon.value as Weapon).attackTypes;
    weapon.patchValue({ attackTypes: currentAttackTypes.filter(aT => aT !== attackType) });
  }

  onArmorSelect(matSelectChange: MatSelectChange): void {
    const selectedArmor: Armor = matSelectChange.value as Armor;
    this.addArmors([selectedArmor], true);
    setTimeout(() => this.selectedArmor = undefined, this.timeOut);
  }

  onRemoveArmor(index: number): void {
    this.armors.removeAt(index);
  }

  doesNpcHaveMagicUniversityMerit(merits: Merit[]): boolean {
    return merits.findIndex(merit => merit.name === this.wizardUniversity) > -1;
  }

  doesNpcHaveArcanums(): boolean {
    return (this.skills.value as Skill[]).findIndex(skill => skill.name.endsWith(this.arcane)) > -1;
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

  saveTemplate(): void {
    const npcTemplate: NpcTemplate = this.npcTemplateDetails.value;
    this.store$.dispatch(fromNpcsActions.saveNpcTemplate({ npcTemplate: npcTemplate, detailsViewMode: this.npcTemplateDetailsMode }));
  }

  deleteTemplate(): void {
    this.store$.dispatch(fromNpcsActions.deleteNpc({ npcId: this.npcTemplateDetails.value.id }));
  }

  isFormInEditMode(): boolean {
    return this.npcTemplateDetailsMode === DetailsViewMode.Edit;
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
          isUndead: npcTemplate.isUndead,
          skillCategories: npcTemplate.skillCategories,
          arcanumRanks: npcTemplate.arcanumRanks
        }, { emitEvent: false });

        this.addSkills(npcTemplate.skills, false);
        this.addMerits(npcTemplate.merits, false);
        this.addFlaws(npcTemplate.flaws, false);
        this.addArmors(npcTemplate.armors, false);
        this.addWeapons(npcTemplate.weapons, false);

        this.primarySkillCategory = npcTemplate.skillCategories?.primary;
        if (npcTemplate.skillCategories?.firstSecondary) {
          this.secondarySkillCategories.push(npcTemplate.skillCategories?.firstSecondary);
        }

        if (npcTemplate.skillCategories?.secondSecondary) {
          this.secondarySkillCategories.push(npcTemplate.skillCategories?.secondSecondary);
        }

        this.tertiarySkillCategory = npcTemplate.skillCategories?.tertiary;
        this.primaryArcanum = npcTemplate.arcanumRanks?.primary;
        this.secondaryArcanum = npcTemplate.arcanumRanks?.secondary;
        this.tertiaryArcanum = npcTemplate.arcanumRanks?.tertiary ?? [];
        this.quaternaryArcanum = npcTemplate.arcanumRanks?.quaternary;
        this.quinaryArcanum = npcTemplate.arcanumRanks?.quinary;
      }
    }));
  }

  private addSkills(skills: Skill[], emitEvent: boolean): void {
    skills.map(skill => this.formBuilder.group({
      id: new FormControl(skill.id),
      name: new FormControl(skill.name),
      minLevel: new FormControl(skill.minLevel),
      maxLevel: new FormControl(skill.maxLevel),
      guaranteedSuccesses: new FormControl(skill.guaranteedSuccesses),
      isOptional: new FormControl(skill.isOptional)
    })).forEach(skillGroup => this.skills.push(skillGroup, { emitEvent }));
  }

  private addMerits(merits: Merit[], emitEvent: boolean): void {
    merits.map(merit => this.formBuilder.group({
      id: new FormControl(merit.id),
      name: new FormControl(merit.name),
      isOptional: new FormControl(merit.isOptional)
    })).forEach(meritGroups => this.merits.push(meritGroups, { emitEvent }));
  }

  private addFlaws(flaws: Flaw[], emitEvent: boolean): void {
    flaws.map(flaw => this.formBuilder.group({
      id: new FormControl(flaw.id),
      name: new FormControl(flaw.name),
      isOptional: new FormControl(flaw.isOptional)
    })).forEach(flawGroup => this.flaws.push(flawGroup, { emitEvent }));
  }

  private addArmors(armors: Armor[], emitEvent: boolean): void {
    armors.map(armor => this.formBuilder.group({
      id: new FormControl(armor.id),
      name: new FormControl(armor.name),
      baseArmorClass: new FormControl(armor.baseArmorClass),
      baseMovementInhibitoryFactor: new FormControl(armor.baseMovementInhibitoryFactor),
      isOptional: new FormControl(armor.isOptional),
      material: new FormControl(armor.material),
      additionalArmorClass: new FormControl(armor.additionalArmorClass),
      additionalMovementInhibitoryFactor: new FormControl(armor.additionalMovementInhibitoryFactor)
    })).forEach(armorGroup => this.armors.push(armorGroup, { emitEvent }));
  }

  private addWeapons(weapons: Weapon[], emitEvent: boolean): void {
    weapons.map(weapon => this.formBuilder.group({
      id: new FormControl(weapon.id),
      name: new FormControl(weapon.name),
      baseInitiativeModifier: new FormControl(weapon.baseInitiativeModifier),
      baseAttackModifier: new FormControl(weapon.baseAttackModifier),
      baseDefenseModifier: new FormControl(weapon.additionalDefenseModifier),
      attackTypes: new FormControl(weapon.attackTypes),
      isOptional: new FormControl(weapon.isOptional),
      additionalInitiativeModifier: new FormControl(weapon.additionalInitiativeModifier),
      additionalAttackModifier: new FormControl(weapon.additionalAttackModifier),
      additionalDefenseModifier: new FormControl(weapon.additionalDefenseModifier),
      material: new FormControl(weapon.material)
    })).forEach(weaponGroup => this.weapons.push(weaponGroup, { emitEvent }));
  }
}