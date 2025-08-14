
import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Difficulty, GeneratedNpc, GeneratedSummon, NpcsClient, SummonType } from '../shared/services/web-api-client';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-generated-npc',
  imports: [
    CommonModule
  ],
  templateUrl: './generated-npc.component.html',
  styleUrl: './generated-npc.component.scss'
})
export class GeneratedNpcComponent {
  x: Observable<GeneratedNpc>;
  y: Observable<GeneratedSummon>;

  constructor(private npcsClient: NpcsClient) {
    this.x = this.getGenerated();
    this.y = this.getSummon();
  }

  getGenerated(): Observable<GeneratedNpc> {
    return this.npcsClient.getGenerated(55, true, true, true, true, Difficulty.Godly);
  }

  getSummon(): Observable<GeneratedSummon> {
    return this.npcsClient.getSummon(SummonType.Unholy, 10);
  }
}
