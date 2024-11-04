import React from 'react';
import Register from './Components/Register';
import Login from './Components/Login';

import './App.css';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Projects from './Components/Project/Projects';
import AddProject from './Components/Project/AddProject';
import EditProject from './Components/Project/EditProject';
import ProjectDetails from './Components/Project/ProjectDetails';


function App() {
  return (
    <Router>
      <Routes>
        <Route path="/register" element={<Register />} />
        <Route path="/login" element={<Login />} />
        <Route path="/" element={<Projects />} />
        <Route path="/Projects/add" element={<AddProject />} />
        <Route path="/projects/view/:projectId" element={<ProjectDetails />} />
        <Route path="/projects/edit/:projectId" element={<EditProject />} />
        {/* <Route path="/projects/delete/:projectId" element={<DeleteProjectPage />} /> */}
      </Routes>
    </Router>
  );
};

export default App;
