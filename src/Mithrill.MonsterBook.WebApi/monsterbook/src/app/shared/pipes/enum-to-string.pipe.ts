import { Pipe, PipeTransform } from '@angular/core';

import { Difficulty } from '../../core/model/difficulty.model';
import { Race } from '../../core/model/race.model';

@Pipe({
  name: 'enumToString',
  standalone: true})
export class EnumToStringPipe implements PipeTransform{
  transform(input: string): string {
    if (input in Race) {
      return Race[input as keyof typeof Race];
    }

    if (input in Difficulty) {
      return Difficulty[input as keyof typeof Difficulty];
    }

    return input;
  }

}