import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Signal, signal } from '@angular/core';

export interface User {
  id: number;
  name: string;
}

export interface Project {
  id: number;
  name: string;
  users: User[];
}

export interface TicketTask {
  id: number;
  description: string;
  userName: string;
}

export interface Ticket {
  id: number;
  description: string;
  projectName: string;
  userName: string;
  ticketTasks: TicketTask[];
}

@Injectable({
  providedIn: 'root'
})
export class DataService {
  private apiUrl = 'http://localhost:5019/v1';

  private projectsSignal = signal<Project[]>([]);
  private ticketsSignal = signal<Ticket[]>([]);
  private projectsErrorSignal = signal<string>('');
  private ticketsErrorSignal = signal<string>('');

  get projects(): Signal<Project[]> {
    return this.projectsSignal;
  }

  get tickets(): Signal<Ticket[]> {
    return this.ticketsSignal;
  }

  get projectsError(): Signal<string> {
    return this.projectsErrorSignal;
  }

  get ticketsError(): Signal<string> {
    return this.ticketsErrorSignal;
  }

  constructor(private http: HttpClient) {
    this.loadProjects();
    this.loadTickets();
  }

  // Load projects from the API
  private loadProjects(): void {
    console.log('Loading projects...');
    this.http.get<Project[]>(`${this.apiUrl}/projects`)
      .subscribe({
        next: projects => this.projectsSignal.set(projects),
        error: error => {
          console.error('Error fetching projects:', error);
          this.projectsErrorSignal.set('Failed to load projects.');
        }
      });
  }

  // Load tickets from the API
  private loadTickets(): void {
    console.log('Loading tickets...');
    this.http.get<Ticket[]>(`${this.apiUrl}/tickets`)
      .subscribe({
        next: tickets => this.ticketsSignal.set(tickets),
        error: error => {
          console.error('Error fetching tickets:', error);
          this.ticketsErrorSignal.set('Failed to load tickets.');
        }
      });
  }
}