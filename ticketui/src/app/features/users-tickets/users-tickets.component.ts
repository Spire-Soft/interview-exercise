import { Component, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DataService, Ticket } from '../../services/data.service';
import { Signal } from '@angular/core';

@Component({
  selector: 'app-users-tickets',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './users-tickets.component.html',
  styleUrls: ['./users-tickets.component.scss']
})
export class UsersTicketsComponent {
  tickets: Signal<Ticket[]>;
  ticketsError: Signal<string>;

  constructor(private dataService: DataService) {
    this.tickets = this.dataService.tickets;
    this.ticketsError = this.dataService.ticketsError;
  }
}


