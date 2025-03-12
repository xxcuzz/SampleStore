import { trigger, state, style, transition, animate } from '@angular/animations';

export const slideDownAnimation = trigger('slideDown', [
  state(
    'closed',
    style({
      height: '0',
      overflow: 'hidden',
    })
  ),
  state(
    'open',
    style({
      height: '*',
      overflow: 'hidden',
    })
  ),
  transition('open <=> closed', animate('0.3s')),
]);