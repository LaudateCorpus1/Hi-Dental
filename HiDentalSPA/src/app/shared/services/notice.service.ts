import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Notice } from '../interfaces/notice.type';

@Injectable()
export class NoticeService {
	onNoticeChanged: BehaviorSubject<Notice>;

	constructor() {
		this.onNoticeChanged = new BehaviorSubject(null);
	}

	setNotice(message: string, type?: 'error' | 'success' | 'info' | 'warning') {
		const notice: Notice = {
			message: message,
			type: type
		};
		this.onNoticeChanged.next(notice);
	}
}
