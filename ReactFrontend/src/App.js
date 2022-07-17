import "./App.css";
import React, { useEffect } from "react";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Title from "./Title";
import Game from "./Game";
import { setSessionId } from "./utils/api";

function App() {
    
    useEffect(() => {
        if (sessionStorage.sessionId)
            setSessionId(sessionStorage.sessionId)
    }, [])

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
