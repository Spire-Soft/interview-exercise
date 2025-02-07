import { Component, input } from '@angular/core';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'app-project-totals',
  imports: [ MatCardModule],
  templateUrl: './project-totals.component.html',
  styleUrl: './project-totals.component.scss'
})
export class ProjectTotalsComponent {
  projectCount = input.required<number>();
  ticketCount = input.required<number>();
}
