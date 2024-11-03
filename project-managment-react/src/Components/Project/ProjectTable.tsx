// src/components/ProjectTable.tsx
import React from 'react';
import { Project, ProjectStatus } from '../../Types/ProjectTypes';
import '../../Styles/ProjectTable.css';

interface ProjectTableProps {
  projects: Project[];
  onView: (projectId: number) => void;
  onEdit: (projectId: number) => void;
  onDelete: (projectId: number) => void;
}

const ProjectTable: React.FC<ProjectTableProps> = ({ projects, onView, onEdit, onDelete }) => {
  const renderStatus = (status: ProjectStatus) => {
    switch (status) {
      case ProjectStatus.NotStarted:
        return 'Not Started';
      case ProjectStatus.InProgress:
        return 'In Progress';
      case ProjectStatus.Completed:
        return 'Completed';
      default:
        return 'Unknown';
    }
  };

  return (
    <table className="project-table">
      <thead>
        <tr>
          <th>Project Name</th>
          <th>Description</th>
          <th>Start Date</th>
          <th>End Date</th>
          <th>Budget</th>
          <th>Status</th>
          <th>Actions</th>
        </tr>
      </thead>
      <tbody>
      {Array.isArray(projects) && projects.map((project) => (
          <tr key={project.id}>
            <td>{project.projectName}</td>
            <td>{project.description}</td>
            <td>{project.startDate}</td>
            <td>{project.endDate}</td>
            <td>{project.budget}</td>
            <td>{renderStatus(project.status)}</td>
            <td>
              <button onClick={() => onView(project.id)}>View</button>
              <button onClick={() => onEdit(project.id)}>Edit</button>
              <button onClick={() => onDelete(project.id)}>Delete</button>
            </td>
          </tr>
        ))}
      </tbody>
    </table>
  );
};

export default ProjectTable;
