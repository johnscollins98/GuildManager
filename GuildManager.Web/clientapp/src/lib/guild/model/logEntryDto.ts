export interface LogEntryDto {
  sourceApplication: 'Discord' | 'Guild Wars 2',
  time: string;
  headline: string; // main action
  actions?: string[]; // sub-actions
}