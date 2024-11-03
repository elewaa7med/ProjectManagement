import React, { useState } from 'react';
import { Link ,useNavigate} from 'react-router-dom';
import authService from '../Services/authService';
import { Role } from '../Types/UserTypes'; 
import '../Styles/Authentication.css';

const Register: React.FC = () => {
    const [username, setUsername] = useState<string>('');
    const [password, setPassword] = useState<string>('');
    const [roleId, setRole] = useState<Role>(Role.Manager); 
    const navigate = useNavigate();
    const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        try {
            const register = { username, password, roleId };
            const result =await authService.register(register);
            if(result){}
                navigate("/login");
        } catch (error) {
            console.error("Registration failed:", error);
        }
    };

    return (
        <div className="wrapper">
            <div className="title"><span>Register Form</span></div>
            <form onSubmit={handleSubmit} className="register-form">
                <div className="row">
                    <i className="fas fa-user"></i>
                    <input type="text" name="username" value={username} onChange={(e) => setUsername(e.target.value)} required placeholder="User Name"/>
                </div>
                <div className="row">
                    <i className="fas fa-lock"></i>
                    <input type="password" name="password" value={password} onChange={(e) => setPassword(e.target.value)} required placeholder="Password"/>
                </div>
                <div className="row">
                    <select name="roleId" value={roleId} onChange={(e) => setRole(Number(e.target.value))} required>
                        <option value={Role.Manager}>Manager</option>
                        <option value={Role.Employee}>Employee</option>
                    </select>
                </div>
                <div className="row button">
                    <button type="submit">Register</button>
                </div>
                <div className="signup-link">have an account? <Link to="/login">Login here</Link></div>
            </form>
        </div>
    );
};

export default Register;
