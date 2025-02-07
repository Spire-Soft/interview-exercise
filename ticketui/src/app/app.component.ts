import { Component, computed, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ProjectListComponent } from '../features/project-list/project-list.component';
import { ProjectTotalsComponent } from '../features/project-totals/project-totals.component';
import { ProjectService } from '../services/project.service';
import { Project } from '../interfaces/project';
import { TicketService } from '../services/ticket.service';
import { TicketTableComponent } from '../features/ticket-table/ticket-table.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, ProjectListComponent, ProjectTotalsComponent, TicketTableComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  projectList = signal<Project[]>([]);
  projectCount = computed(() => this.projectList().length);
  ticketCount = signal(0);

  constructor(projectService: ProjectService, ticketService: TicketService){

    projectService.getProjects().then((list: Project[]) => {
      this.projectList.set(list);
    });

    ticketService.getTicketCount().then((count: number) => {
      this.ticketCount.set(count);
    });
  }
}
