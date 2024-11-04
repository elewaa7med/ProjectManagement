// src/components/ProjectTable.tsx
import React from 'react';
import { Project, ProjectStatus } from '../../Types/ProjectTypes';
import { useNavigate } from 'react-router-dom';
import '../../Styles/ProjectTable.css';

interface ProjectTableProps {
  projects: Project[];
}

const ProjectTable: React.FC<ProjectTableProps> = ({ projects }) => {
  const navigate = useNavigate();
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
          <tr key={project.projectId}>
            <td>{project.projectName}</td>
            <td>{project.description}</td>
            <td>{project.startDate}</td>
            <td>{project.endDate}</td>
            <td>{project.budget}</td>
            <td>{renderStatus(project.status)}</td>
            <td>
              <button onClick={() => navigate(`/projects/view/${project.projectId}`)}>View</button>
              <button onClick={() => navigate(`/projects/edit/${project.projectId}`)}>Edit</button>
              <button onClick={() => navigate(`/projects/delete/${project.projectId}`)}>Delete</button>
            </td>
          </tr>
        ))}
      </tbody>
    </table>
  );
};

export default ProjectTable;
