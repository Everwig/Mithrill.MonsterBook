import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NpcTemplateDetailsComponent } from './npc-template-details.component';

describe('NpcTemplateDetailsComponent', () => {
  let component: NpcTemplateDetailsComponent;
  let fixture: ComponentFixture<NpcTemplateDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NpcTemplateDetailsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NpcTemplateDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
