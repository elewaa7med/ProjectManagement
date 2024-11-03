import React, { useState } from 'react';
import { addProject } from '../../Services/projectService';
import { CreateProject, ProjectStatus } from '../../Types/ProjectTypes';
import { useNavigate } from 'react-router-dom';
import '../../Styles/AddProjectPage.css';

const AddProject: React.FC = () => {
  const [project, setProject] = useState<Partial<CreateProject>>({
    status: ProjectStatus.NotStarted,
  });
  const navigate = useNavigate();

  const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
    setProject({
      ...project,
      [e.target.name]: e.target.value,
    });
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    if (project.projectName) {
      await addProject(project as CreateProject);
      navigate('/');
    }
  };

  return (
    <div className="add-project-page">
      <h2>Add New Project</h2>
      <form onSubmit={handleSubmit}>
        <input name="projectName" placeholder="Project Name" onChange={handleChange} />
        <input name="description" placeholder="Description" onChange={handleChange} />
        <input type="date" name="startDate" placeholder="Start Date" onChange={handleChange} />
        <input type="date" name="endDate" placeholder="End Date" onChange={handleChange} />
        <input type="number" name="budget" placeholder="Budget" onChange={handleChange} />
        <input name="owner" placeholder="Owner" onChange={handleChange} />
        <select name="status" value={project.status} onChange={handleChange}>
          <option value={ProjectStatus.NotStarted}>Not Started</option>
          <option value={ProjectStatus.InProgress}>In Progress</option>
          <option value={ProjectStatus.Completed}>Completed</option>
        </select>
        <button type="submit">Add Project</button>
      </form>
    </div>
  );
};

export default AddProject;