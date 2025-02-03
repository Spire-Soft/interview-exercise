import { Component, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DataService, Project } from '../../services/data.service';
import { Signal } from '@angular/core';

@Component({
  selector: 'app-project-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './project-list.component.html',
  styleUrls: ['./project-list.component.scss']
})
export class ProjectListComponent {
  projects: Signal<Project[]>;
  projectsError: Signal<string>;

  constructor(private dataService: DataService) {
    this.projects = this.dataService.projects;
    this.projectsError = this.dataService.projectsError;
  }
}