import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NpcDashboardComponent } from './npc-dashboard.component';

describe('NpcDashboardComponent', () => {
  let component: NpcDashboardComponent;
  let fixture: ComponentFixture<NpcDashboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NpcDashboardComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NpcDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
