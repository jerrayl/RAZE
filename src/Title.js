import { useNavigate } from "react-router-dom";
import title from "./assets/title.png";

function Game() {
    const navigate = useNavigate();

    return (
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
    );
}

export default Game;
