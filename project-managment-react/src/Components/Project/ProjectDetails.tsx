import React, { useEffect, useState } from 'react';
import { getProject} from '../../Services/projectService';
import { Project} from '../../Types/ProjectTypes';

import { useParams } from 'react-router-dom';
import '../../Styles/ViewProjectPage.css';

const ProjectDetails: React.FC = () => {
  const { projectId } = useParams<{ projectId: string }>();
  const [project, setProject] = useState<Project | null>(null);

  useEffect(() => {
    const loadProject = async () => {
      if (projectId) {
        const projectData = await getProject(Number(projectId));
        console.log(projectData);
        setProject(projectData);
      }
    };
    loadProject();
  }, [projectId]);

  if (!project) {
    return <div>Loading...</div>;
  }

  return (
    <div className="view-project-page">
      <h2>Project Details</h2>
      <p><strong>Project Name:</strong> {project.projectName}</p>
      <p><strong>Description:</strong> {project.description}</p>
      <p><strong>Start Date:</strong> {project.startDate}</p>
      <p><strong>End Date:</strong> {project.endDate}</p>
      <p><strong>Budget:</strong> {project.budget}</p>
      <p><strong>Status:</strong> {project.status}</p>
      <p><strong>Owner:</strong> {project.owner}</p>
    </div>
  );
};

export default ProjectDetails;