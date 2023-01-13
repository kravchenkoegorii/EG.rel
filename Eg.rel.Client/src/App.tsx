import React from "react";
import { Login } from "./pages/Login";
import { Registration } from "./pages/Registration";
import "./App.css";
import {BrowserRouter, Routes} from "react-router-dom";
//import { Layout } from "./pages/Layout"; <Route path="/" element={<Layout />} />

const App = () => {
  return (
      <div className="App">
        <BrowserRouter>
          <Routes>
            <Route path="/login" element={<Login />} />
            <Route path="/registration" element={<Registration />} />

          </Routes>
        </BrowserRouter>
      </div>
  );
};

export default App;
