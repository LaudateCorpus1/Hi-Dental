import { Component, OnInit } from '@angular/core';
import { CalendarOptions, DateSelectArg, EventClickArg, EventApi, CalendarApi, Calendar } from '@fullcalendar/angular';
import { INITIAL_EVENTS, createEventId } from './event-utils';
import esLocale from '@fullcalendar/core/locales/es';
import enLocale from '@fullcalendar/core/locales/en-au';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Combobox, BaseService } from 'src/app/shared/services/HTTPClient/base.service';
import { NzNotificationService } from 'ng-zorro-antd';
@Component({
  selector: 'app-agenda',
  templateUrl: './agenda.component.html',
  styleUrls: ['./agenda.component.css']
})
export class AgendaComponent implements OnInit {


   // Variable Modal Cita
  textTitleModal = 'Nueva cita ';
  editLoading = false;
  isOkLoading =  false;
  isHorizontal = false;
  loadingButton = false;
  isPrincipalChecked = false;
  dateStartAppointment: Date;
  dateEndAppointment: Date;


  validateForm: FormGroup;


  comboboxPacientes: Combobox[] = [];
  pacienteSeletedForm: Combobox;
  // oficinaSeletedFilter: Combobox = { code: '', grupoID: null, title: 'Todas las oficinas', Group: null };


  constructor(
    public base: BaseService,
    private fb: FormBuilder,
    private notification: NzNotificationService

    ) { }
  calendarVisible = true;
  isVisible = false;
  calendarOptions: CalendarOptions = {
    headerToolbar: {
      left: 'prev,next today',
      center: 'title',
      right: 'listWeek,timeGridDay,timeGridWeek,dayGridMonth'

    },
    height: 550,
    eventOverlap: false,
    initialView: 'timeGridWeek',
    initialEvents: INITIAL_EVENTS,
    weekends: true,
    editable: true,
    selectable: true,
    slotDuration: '00:15:00',
    selectMirror: true,
    locale: esLocale,
    dayMaxEvents: true,
    select: this.handleDateSelect.bind(this),
    eventClick: this.handleEventClick.bind(this),
    eventsSet: this.handleEvents.bind(this)
  };
  locales = [esLocale, enLocale];
  currentEvents: EventApi[] = [];
  ngOnInit() {
    this.CreateForm();

  }

  handleCalendarToggle() {
    this.calendarVisible = !this.calendarVisible;
  }

  handleWeekendsToggle() {
    const { calendarOptions } = this;
    calendarOptions.weekends = !calendarOptions.weekends;
  }

  handleDateSelect(selectInfo: DateSelectArg) {


  //  const title = prompt('Please enter a new title for your event');
    const calendarApi = selectInfo.view.calendar;
    calendarApi.unselect(); // clear date selection
    this.isVisible = true;
    this.dateStartAppointment = selectInfo.start;
    this.dateEndAppointment = selectInfo.end;

    console.log(selectInfo.start);
    console.log(selectInfo.end);
    // if (title) {
    //   calendarApi.addEvent({
    //     id: createEventId(),
    //     title,
    //     start: selectInfo.startStr,
    //     end: selectInfo.endStr,
    //     allDay: selectInfo.allDay,
    //   });
    // }
  //   this.currentEvents.forEach(x=>{

  //  });
  }
  CreateForm() {
    this.validateForm = this.fb.group({
      formLayout: ['vertical'],
      title: [null, [Validators.required]],
      address: [null, [Validators.required]],
      description: [null, [Validators.required]],
      phoneNumber: [null, [Validators.required]],
      isPrincipal: [false, [Validators.required]],
      office: [null, [Validators.required]],
    });
  }
  get f() { return this.validateForm.controls; }

  handleEventClick(clickInfo: EventClickArg) {
    console.log(clickInfo.event.extendedProps.userAttendedID);
    if (confirm(`Are you sure you want to delete the event '${clickInfo.event.title}'`)) {
      clickInfo.event.remove();
    }
  }

  handleEvents(events: EventApi[]) {
    this.currentEvents = events;
  }

  showModal(): void {
    this.isVisible = true;
  }

  handleOk(): void {
    console.log('Button ok clicked!');
    this.isVisible = false;
  }

  handleCancel(): void {
    console.log('Button cancel clicked!');
    this.isVisible = false;
  }
  submitForm(){
   console.log('submit');

  }
   getDateDiff(startDate, endDate) {
    const diff = endDate.getTime() - startDate.getTime();
    const days = Math.floor(diff / (60 * 60 * 24 * 1000));
    const hours = Math.floor(diff / (60 * 60 * 1000)) - (days * 24);
    const minutes = Math.floor(diff / (60 * 1000)) - ((days * 24 * 60) + (hours * 60));
    const seconds = Math.floor(diff / 1000) - ((days * 24 * 60 * 60) + (hours * 60 * 60) + (minutes * 60));
    return { day: days, hour: hours, minute: minutes, second: seconds };
}

getDateDiffToString(){
   const diff = this.getDateDiff(this.dateStartAppointment, this.dateEndAppointment);
   if (diff.hour > 0 && diff.minute > 0){
      return diff.hour + ' horas y ' + diff.minute + ' minutos' ;
  }
   if (diff.hour > 0 ){
    return diff.hour + ' horas';
}
   if (diff.minute > 0 ){
  return diff.minute + ' minutos';
}
}



}
