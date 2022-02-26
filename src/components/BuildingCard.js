import icons from "../assets/icons/icon";
import elements from "../assets/elements/elements";

function BuildingCard({ title, image, cost, production, health, effect }) {
    return (
        <div className="h-52 bg-stone-200 rounded-lg shadow-lg grid grid-cols-7 text-stone-700">
            <div className="flex col-span-4 justify-center items-center">
                <img className="w-40" src={image} />
            </div>

            <div className="col-span-3 grid grid-cols-2 pr-2 mt-4 -ml-1">
                <div className="flex items-center">
                    <img src={icons.bricks_d} className="h-10 w-10 mr-1" />
                    <h2 className="text-4xl mr-4">{health}</h2>
                </div>
                <div className="flex items-center">
                    <img src={icons.production_d} className="h-10 w-10 mr-1" />
                    <h2 className="text-4xl mr-4">{production}</h2>
                </div>
                {Object.keys(cost).map((element) => (
                    <div key={title + element} className="flex items-center">
                        <img src={elements[element]} className="h-10 w-10 mr-1" />
                        <h2 className="text-4xl mr-4">{cost[element]}</h2>
                    </div>
                ))}
            </div>
            <div className="flex col-span-1" />
            <div className="flex col-span-5 justify-center items-center">
                <h2 className="text-3xl pb-1">{title}</h2>
            </div>
            <div className="flex col-span-1 justify-center items-center">
                {effect && <img src={icons.tag_d} className="h-12 w-12 mr-4 pb-2" />}
            </div>
        </div>
    );
}

export default BuildingCard;
