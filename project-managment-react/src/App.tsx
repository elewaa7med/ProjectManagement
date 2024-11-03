import React from 'react';
import Register from './Components/Register';
import Login from './Components/Login';

import './App.css';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Projects from './Components/Project/Projects';
import AddProject from './Components/Project/AddProject';


function App() {
  return (
    <Router>
      <Routes>
      <Route path="/" element={<Projects />} />
      <Route path="/Projects/AddProject" element={<AddProject />} />
      <Route path="/register" element={<Register />} />
      <Route path="/login" element={<Login />} />
      </Routes>
    </Router>
  );
};

export default App;
