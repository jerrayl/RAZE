import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import title from "./assets/title.png";
import { HubConnectionBuilder } from '@microsoft/signalr';

function Game() {
    const navigate = useNavigate();

    const [email, setEmail] = useState("");

    const login = async () => {
        const response = await connection.invoke("login", {email: email});
        console.log(response);
    }

    const [ connection, setConnection ] = useState(null);

    useEffect(() => {
        const newConnection = new HubConnectionBuilder()
            .withUrl(`https://localhost:5001/signalr`)
            .withAutomaticReconnect()
            .build();

        setConnection(newConnection);
    }, []);

    useEffect(() => {
        if (connection) {
            connection.start()
                .then(result => {
                    console.log('Connected!');
    
                    connection.on('Request', message => {
                        console.log(message);
                    });
                })
                .catch(e => console.log('Connection failed: ', e));
        }
    }, [connection]);

    return (
        <>
            <div className="flex right-3 top-3 fixed"><input className="bg-stone-600 p-2 rounded-tl-md rounded-bl-md outline-none text-stone-200" value={email} onChange={e => setEmail(e.target.value)}/><button className="bg-stone-700 hover:bg-stone-600 py-2 w-16 rounded-tr-md rounded-br-md text-white" onClick={login}>Login</button></div>
            <div className="flex flex-col items-center font-serif">
                <img src={title} className="w-1/2" alt="title" />
                <button className="bg-stone-700 hover:bg-stone-600 text-white text-4xl font-bold py-10 w-96 rounded-xl"
                    onClick={() => navigate("/game")}>
                    Play
                </button>
                <button className="mt-4 bg-stone-700 hover:bg-stone-600 text-white text-4xl font-bold py-10 w-96 rounded-xl">
                    Tutorial
                </button>
                <button className="mt-4 bg-stone-700 hover:bg-stone-600 text-white text-4xl font-bold py-10 w-96 rounded-xl">
                    Credits
                </button>
            </div>
        </>
    );
}

export default Game;
