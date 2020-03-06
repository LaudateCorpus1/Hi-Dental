export interface Notice {
	type?: 'error' | 'success' | 'info' | 'warning';
	message: string;
}
