import React, { useEffect, useState } from 'react';
import { getProject,updateProject} from '../../Services/projectService';
import { Project, ProjectStatus,UpdateProject } from '../../Types/ProjectTypes';
import { useParams, useNavigate } from 'react-router-dom';
import '../../Styles/EditProjectPage.css';

const EditProject: React.FC = () => {
  const { projectId } = useParams<{ projectId: string }>();
  const [project, setProject] = useState<Partial<UpdateProject>>({});
  const navigate = useNavigate();

  useEffect(() => {
    const loadProject = async () => {
      if (projectId) {
        const projectData = await getProject(Number(projectId));
        setProject(projectData);
      }
    };
    loadProject();
  }, [projectId]);

  const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
    setProject({
      ...project,
      [e.target.name]: e.target.value,
    });
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    if (projectId && project) {
      await updateProject(Number(projectId), project as UpdateProject);
      navigate('/');
    }
  };

  return (
    <div className="edit-project-page">
      <h2>Edit Project</h2>
      <form onSubmit={handleSubmit}>
        <input name="projectName" value={project.projectName || ''} onChange={handleChange} placeholder="Project Name" />
        <input name="description" value={project.description || ''} onChange={handleChange} placeholder="Description" />
        <input type="date" name="startDate" value={project.startDate || ''} onChange={handleChange} />
        <input type="date" name="endDate" value={project.endDate || ''} onChange={handleChange} />
        <input type="number" name="budget" value={project.budget || ''} onChange={handleChange} placeholder="Budget" />
        <input name="owner" value={project.owner || ''} onChange={handleChange} placeholder="Owner" />
        <select name="status" value={project.status || ProjectStatus.NotStarted} onChange={handleChange}>
          <option value={ProjectStatus.NotStarted}>Not Started</option>
          <option value={ProjectStatus.InProgress}>In Progress</option>
          <option value={ProjectStatus.Completed}>Completed</option>
        </select>
        <button type="submit">Save Changes</button>
      </form>
    </div>
  );
};

export default EditProject;