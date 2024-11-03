import React, { useEffect, useState } from 'react';
import { getProjects } from '../../Services/projectService';
import { Project } from '../../Types/ProjectTypes';
import ProjectTable from './ProjectTable';
import { useNavigate } from 'react-router-dom';
import '../../Styles/ProjectsPage.css';

const Projects: React.FC = () => {
  const [projects, setProjects] = useState<Project[]>([]);
  const [page, setPage] = useState(1);
  const [limit] = useState(10); // Adjust as needed
  const navigate = useNavigate();

  useEffect(() => {
    const loadProjects = async () => {
      const data = await getProjects(page, limit);
      setProjects(data);
    };
    loadProjects();
  }, [page]);

  const handleAddProject = () => {
    navigate('/Projects/AddProject');
  };

  return (
    <div className="projects-page">
      <h1>Projects</h1>
      <button className="add-project-button" onClick={handleAddProject}>Add Project</button>
      <ProjectTable
        projects={projects}
        onView={(projectId) => navigate(`/projects/view/${projectId}`)}
        onEdit={(projectId) => navigate(`/projects/edit/${projectId}`)}
        onDelete={(projectId) => console.log('Delete project', projectId)}
      />
      <div className="pagination">
        <button onClick={() => setPage(page - 1)} disabled={page === 1}>Previous</button>
        <span>Page {page}</span>
        <button onClick={() => setPage(page + 1)}>Next</button>
      </div>
    </div>
  );
};

export default Projects;