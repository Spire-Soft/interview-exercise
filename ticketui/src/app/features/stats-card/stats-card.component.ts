import { Component, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DataService } from '../../services/data.service';
import { Signal, computed } from '@angular/core';

@Component({
  selector: 'app-stats-card',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './stats-card.component.html',
  styleUrls: ['./stats-card.component.scss']
})
export class StatsCardComponent{
  totalProjects: Signal<number | string>;
  totalTickets: Signal<number | string>;
  projectsError: Signal<string>;
  ticketsError: Signal<string>;

  constructor(private dataService: DataService) { 
    this.totalProjects = computed(() => this.dataService.projects().length || '0');
    this.totalTickets = computed(() => this.dataService.tickets().length || '0');
    this.projectsError = this.dataService.projectsError;
    this.ticketsError = this.dataService.ticketsError;
  }
}

