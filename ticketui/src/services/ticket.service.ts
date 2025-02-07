import { Injectable } from '@angular/core';
import { Ticket } from '../interfaces/ticket';

@Injectable({
  providedIn: 'root'
})
export class TicketService {
  private url = 'http://localhost:5019/v1/tickets';

  async getTicketCount(): Promise<number> {
    const data = await fetch(`${this.url}/count`);
    return (await data.json()) ?? 0;
  }

  async getTickets(): Promise<Ticket[]> {
    const data = await fetch(this.url);
    return (await data.json()) ?? [];
  }

}
