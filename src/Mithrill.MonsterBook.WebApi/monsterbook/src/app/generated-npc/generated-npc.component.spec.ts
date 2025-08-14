import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GeneratedNpcComponent } from './generated-npc.component';

describe('GeneratedNpcComponent', () => {
  let component: GeneratedNpcComponent;
  let fixture: ComponentFixture<GeneratedNpcComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GeneratedNpcComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GeneratedNpcComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
