import axios from 'axios';
import { Project , CreateProject, UpdateProject} from '../Types/ProjectTypes';
import { ApiResponse } from '../Types/ResponseTypes';

const api = axios.create({
    baseURL: 'http://localhost:5109/api/project',
    headers: {
        'Content-Type': 'application/json',
        'Authorization': "Bearer "+localStorage.getItem('token'),
    },
});

// Get all projects
export const getProjects = async (pageId:number =1, pageSize:number =10) => {
    const response = await api.get<ApiResponse<Project[]>>('/', {
        params: {
            pageId: pageId,
            pageSize: pageSize,
        }
    });
    console.log(response.data.data);
    return response.data.data;
};
export const getProject = async (projectId: number) => {
    const response = await api.get<ApiResponse<Project>>(`/${projectId}`);
    return response.data.data;
  };
// Add a new project
export const addProject = async (project: CreateProject) => {
    const response = await api.post<ApiResponse<Project>>('/', project);
    return response.data;
};

// Update a project
export const updateProject = async (id:number, project: UpdateProject) => {
    console.log(project);
    try{
    const response = await api.put(`/${id}`, project);
    return response.data;
}catch(exception ){
    console.log(exception);
}
};

// Delete a project
export const deleteProject = async (id:number) => {
    await api.delete(`/${id}`);
};