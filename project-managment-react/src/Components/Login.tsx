import React, { useState } from 'react';
import { Link ,useNavigate} from 'react-router-dom';
import {jwtDecode } from 'jwt-decode';
import { CustomJwtPayload } from '../Types/JwtPayload'; 
import authService from '../Services/authService';

import '../Styles/Authentication.css';

const Login: React.FC = () => {
    const [username, setUsername] = useState<string>('');
    const [password, setPassword] = useState<string>('');
    const navigate = useNavigate();
    const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        try {
            const credentials = { username, password };
            const token = await authService.login(credentials);
            const userRole = jwtDecode<CustomJwtPayload>(token).role;
            localStorage.setItem('token', token);
            localStorage.setItem('role', userRole);
            navigate("/")
        } catch (error) {
            console.error("Login failed:", error);
        }
    };

    return (
        <div className="wrapper">
            <div className="title"><span>Login Form</span></div>
            <form onSubmit={handleSubmit} className="login-form">
                <div className="row">
                    <i className="fas fa-user"></i>
                    <input type="text" name="username" value={username} onChange={(e) => setUsername(e.target.value)} required  placeholder="User Name"/>
                </div>
                <div className="row">
                    <i className="fas fa-lock"></i>
                    <input type="password" name="password" value={password} onChange={(e) => setPassword(e.target.value)} required  placeholder="Password"/>
                </div>
                <div className="row button">
                    <button type="submit">Login</button>
                </div>
                <div className="signup-link">Don’t have an account? <Link to="/register">Register here</Link></div>
            </form>
        </div>
    );
}

export default Login;
