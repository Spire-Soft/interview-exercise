import { Injectable } from '@angular/core';
import { Project } from '../interfaces/project';

@Injectable({
  providedIn: 'root'
})
export class ProjectService {
  private url = 'http://localhost:5019/v1/projects'; // GET v1/projects

  async getProjects(): Promise<Project[]> {
    const data = await fetch(this.url);
    return (await data.json()) ?? [];
  }
}
