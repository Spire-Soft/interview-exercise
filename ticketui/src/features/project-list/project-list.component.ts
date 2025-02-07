import { Component, input } from '@angular/core';
import { Project } from '../../interfaces/project';
import { User } from '../../interfaces/user';
import { MatListModule } from '@angular/material/list';

@Component({
  selector: 'app-project-list',
  imports: [MatListModule],
  templateUrl: './project-list.component.html',
  styleUrl: './project-list.component.scss'
})
export class ProjectListComponent {
  list = input<Project[]>();

  displayUserNames(users: User[]): string {
    return users.map((u) => u.name).join(', ');
  }

}
