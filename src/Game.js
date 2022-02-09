import title from "./assets/title.png";
import icons from "./assets/icons/icon";
import elements from "./assets/elements/elements";
import { ELEMENTS, buildings } from "./utils/constants";
import { useState } from "react";

function Game() {
    const displayBuildingName = (building) => (
        <h2 className="text-white text-lg">
            {building.name} {building.production}
        </h2>
    );
    const board = Array(25).fill("");
    const [showBuildingMenu, setShowBuildingMenu] = useState(false);
    //{ELEMENTS.keys().map((element) => (
    //    <img src={elements[element]} />
    //))}
    return (
        <div className="flex flex-col items-center font-serif">
            <nav className="bg-stone-700 w-screen h-24 flex justify-around items-center px-8 text-3xl shadow-lg z-10">
                <h2 className="text-white">Build Phase: Your turn</h2>
                <img src={title} className="w-48" alt="title" />
                <h2 className="text-white">End turn</h2>
            </nav>
            {!showBuildingMenu && (
                <button
                    onClick={() => setShowBuildingMenu(true)}
                    className="absolute left-0 mt-36 bg-stone-700 hover:bg-stone-600 text-white text-4xl font-bold py-10 px-5 rounded-tr-lg rounded-br-lg shadow-lg"
                >
                    <img src={icons.building} />
                </button>
            )}
            <button className="absolute right-0 mt-36 bg-stone-700 hover:bg-stone-600 text-white text-4xl font-bold py-10 px-5 rounded-tl-lg rounded-bl-lg shadow-lg">
                <img src={icons.troop} />
            </button>

            {showBuildingMenu && (
                <div
                    onClick={() => setShowBuildingMenu(false)}
                    className="absolute mt-24 bg-stone-700 w-96 h-screen left-0"
                >
                    <div className="flex items-center px-4 py-4">
                        <img src={icons.building} />
                        <h2 className="text-white text-4xl pl-4">Buildings</h2>
                    </div>
                    {buildings.filter((building) => building.production > 2).map(displayBuildingName)}
                </div>
            )}

            <div className="grid grid-cols-5 mt-12">
                {board.map((space, i) => (
                    <div key={i} className="w-24 h-24 border-black border-2 flex flex-col justify-center">
                        <h2 className="text-xl">{space}</h2>
                    </div>
                ))}
            </div>
        </div>
    );
}

export default Game;
