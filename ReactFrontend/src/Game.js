import title from "./assets/title.png";
import icons from "./assets/icons/icon";
import elements from "./assets/elements/elements";
import buildingImages from "./assets/buildings/buildingImages";
import { ELEMENTS } from "./utils/constants";
import { useEffect, useState } from "react";
import ElementCard from "./components/ElementCard";
import BuildingCard from "./components/BuildingCard";
import BuildingMenu from "./components/BuildingMenu";
import TroopsMenu from "./components/TroopsMenu";
import { getBuildings } from "./utils/api";

function Game() {

    const fetchBuildings = async () => {
        const response = await getBuildings();
        console.log(response);
        setBuildings(response);
    }

    useEffect(() => {
        fetchBuildings();
    }, [])

    const board = Array(25).fill("");
    const [buildings, setBuildings] = useState([]);
    const [showBuildingMenu, setShowBuildingMenu] = useState(false);
    const [showTroopsMenu, setShowTroopsMenu] = useState(false);
    const [selectedElement, setSelectedElement] = useState("");

    return (
        <div className="flex flex-col items-center font-serif">
            <nav className="bg-stone-700 w-screen h-20 px-12 grid grid-cols-3 flex items-center text-3xl shadow-lg z-10">
                <div className="flex justify-start">
                    <h2 className="text-white">Build Phase: Your turn</h2>
                </div>
                <div className="flex justify-center">
                    <img src={title} className="w-56" alt="title" />
                </div>
                <div className="flex justify-end">
                    <h2 className="text-white">End turn</h2>
                </div>
            </nav>
            {!showBuildingMenu && !showTroopsMenu && (
                <button
                    onClick={() => setShowBuildingMenu(true)}
                    className="absolute left-0 mt-36 bg-stone-700 hover:bg-stone-600 text-white text-4xl font-bold py-8 px-5 rounded-tr-lg rounded-br-lg shadow-lg"
                >
                    <img src={icons.building} />
                </button>
            )}
            {!showTroopsMenu && !showBuildingMenu && (
                <button
                    onClick={() => setShowTroopsMenu(true)}
                    className="absolute right-0 mt-36 bg-stone-700 hover:bg-stone-600 text-white text-4xl font-bold py-8 px-5 rounded-tl-lg rounded-bl-lg shadow-lg"
                >
                    <img src={icons.troop} />
                </button>
            )}

            {showBuildingMenu && (
                <BuildingMenu
                    buildings={buildings}
                    setShowBuildingMenu={setShowBuildingMenu}
                    setSelectedElement={setSelectedElement}
                    selectedElement={selectedElement}
                />
            )}

            {showTroopsMenu && (
                <TroopsMenu
                    setShowTroopsMenu={setShowTroopsMenu}
                    setSelectedElement={setSelectedElement}
                    selectedElement={selectedElement}
                />
            )}

            <div className={"flex " + (showBuildingMenu ? "pl-96" : "") + (showTroopsMenu ? "pr-96" : "")}>
                <div
                    className={
                        "flex flex-col justify-between " + (!showTroopsMenu && !showBuildingMenu ? "mr-12" : "mr-4")
                    }
                >
                    <div className="flex flex-col items-center mt-20">
                        <h2 className="text-white text-3xl">Modifiers</h2>
                        <div className="grid grid-cols-2 mt-2">
                            <div className="flex items-center">
                                <img src={icons.sword} className="mr-4" />
                                <h2 className="text-white text-4xl mr-4">12</h2>
                            </div>
                            <div className="flex items-center">
                                <img src={icons.heart} className="mr-4" />
                                <h2 className="text-white text-4xl mr-4">12</h2>
                            </div>
                            <div className="flex items-center">
                                <img src={icons.bricks} className="mr-4" />
                                <h2 className="text-white text-4xl mr-4">12</h2>
                            </div>
                            <div className="flex items-center">
                                <img src={icons.carrot} className="mr-4" />
                                <h2 className="text-white text-4xl mr-4">12</h2>
                            </div>
                        </div>
                    </div>

                    <div className="flex flex-col items-center">
                        <h2 className="text-white text-3xl">Resources</h2>
                        <div className="grid grid-cols-2 mt-2">
                            {Object.values(ELEMENTS).map((element) => (
                                <div className="flex items-center">
                                    <img className="w-20 mr-2" src={elements[element.toUpperCase()]} />
                                    <h2 className="text-white text-4xl mr-2">12</h2>
                                </div>
                            ))}
                        </div>
                    </div>
                </div>

                <div className="grid grid-cols-5 mt-12">
                    {board.map((space, i) => (
                        <div key={i} className="w-28 h-28 border-black border-2 flex flex-col justify-center">
                            <h2 className="text-xl">{space}</h2>
                        </div>
                    ))}
                </div>
                <div
                    className={
                        "flex flex-col justify-between " + (!showTroopsMenu && !showBuildingMenu ? "ml-12" : "ml-4")
                    }
                >
                    <div className="flex flex-col items-center mt-20">
                        <img
                            src={icons.eye}
                            className="w-16 h-16"
                            onMouseEnter={(e) => (e.currentTarget.src = icons.eye_h)}
                            onMouseLeave={(e) => (e.currentTarget.src = icons.eye)}
                        />
                        <img
                            src={icons.u_arrow}
                            className="w-16 h-16 mt-8"
                            onMouseEnter={(e) => (e.currentTarget.src = icons.u_arrow_h)}
                            onMouseLeave={(e) => (e.currentTarget.src = icons.u_arrow)}
                        />
                    </div>
                    <div className="flex flex-col items-center">
                        <h2 className="text-white text-3xl">Production</h2>
                        <div className="grid grid-cols-2 mt-2">
                            {Object.values(ELEMENTS).map((element) => (
                                <div className="flex items-center">
                                    <img className="w-20 mr-2" src={elements[element.toUpperCase()]} />
                                    <h2 className="text-white text-4xl mr-2">12</h2>
                                </div>
                            ))}
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default Game;
