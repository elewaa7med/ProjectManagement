import { JwtPayload } from 'jwt-decode';

export interface CustomJwtPayload extends JwtPayload {
  role: string; // or 'Manager' | 'Employee' if you want stricter typing
}