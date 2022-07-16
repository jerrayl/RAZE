import "./App.css";
import React from "react";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Title from "./Title";
import Game from "./Game";

function App() {
    return (
        <div className="h-screen bg-[url('./assets/background1.jpg')] bg-cover">
            <Router>
                <Routes>
                    <Route path="/" element={<Title />}/>
                    <Route path="/game" element={<Game />}/>
                </Routes>
            </Router>
        </div>
    );
}

export default App;
