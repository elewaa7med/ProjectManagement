export interface Login {
    username: string; 
    password: string; 
}

export interface Register {
    username: string; 
    password: string; 
    roleId: Role
}


export enum Role{
    Manager=1,
    Employee=2,
}