import axios from 'axios';
import { Project , CreateProject} from '../Types/ProjectTypes';
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
    return response.data.data;
};

// Add a new project
export const addProject = async (project: CreateProject) => {
    const response = await api.post('/', project);
    return response.data;
};

// Update a project
export const updateProject = async (id:number, project: CreateProject) => {
    const response = await api.put(`/${id}`, project);
    return response.data;
};

// Delete a project
export const deleteProject = async (id:number) => {
    await api.delete(`/${id}`);
};