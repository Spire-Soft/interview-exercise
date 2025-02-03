import { Component } from '@angular/core';
import { ProjectListComponent } from './features/project-list/project-list.component';
import { StatsCardComponent } from './features/stats-card/stats-card.component';
import { UsersTicketsComponent } from './features/users-tickets/users-tickets.component';
import { WelcomeComponent } from './features/welcome/welcome.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [ProjectListComponent, StatsCardComponent, UsersTicketsComponent, WelcomeComponent],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'ticketui';
}


