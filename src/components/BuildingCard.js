function BuildingCard({title, image}) {
    return (
        <div className="w-4/5 h-36 bg-stone-300 rounded-lg shadow-lg flex flex-col items-center justify-center">
           <img className="w-24" src={image}/>
           <h2 className="text-stone-700 text-3xl">{title}</h2>
        </div>
    );
}

export default BuildingCard;
