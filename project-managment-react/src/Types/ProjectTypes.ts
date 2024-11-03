import { Role } from "./UserTypes";
export interface CreateProject {
  projectName: string;
  description: string;
  startDate: string;
  endDate: string;   
  budget: number;
  owner: string;
  status:ProjectStatus; 
}
export interface Project {
  id: number;
  projectName: string;
  description: string;
  startDate: string;
  endDate: string;   
  budget: number;
  owner: string;
  status:ProjectStatus; 
}

export enum ProjectStatus {
  NotStarted = 1,
  InProgress,
  Completed,
}