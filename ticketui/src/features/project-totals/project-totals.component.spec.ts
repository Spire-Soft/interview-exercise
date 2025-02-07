import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProjectTotalsComponent } from './project-totals.component';

describe('ProjectTotalsComponent', () => {
  let component: ProjectTotalsComponent;
  let fixture: ComponentFixture<ProjectTotalsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ProjectTotalsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProjectTotalsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
