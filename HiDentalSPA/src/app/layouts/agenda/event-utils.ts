import { EventInput } from '@fullcalendar/angular';

let eventGuid = 0;
const TODAY_STR = new Date().toISOString().replace(/T.*$/, ''); // YYYY-MM-DD of today

export const INITIAL_EVENTS: EventInput[] = [
  {
    id: createEventId(),
    title: 'Sandy German',
    start: TODAY_STR,
    state: '',
    pacienteID: '',
    userAttendedID: '' 

  }, 
  {
    id: createEventId(),
    title: 'Jencarlos',
    start: TODAY_STR,
    state: '',
    pacienteID: '3003',
    userAttendedID: '30303' 
  }

];

export function createEventId() {
  return String(eventGuid++);
}
