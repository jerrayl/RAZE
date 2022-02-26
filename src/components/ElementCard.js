function ElementCard({title, image, setSelectedElement}) {
    return (
        <div onClick={() => setSelectedElement(title.toUpperCase())} className="w-36 h-36 bg-stone-300 hover:bg-stone-400 cursor-pointer rounded-lg shadow-lg flex flex-col items-center justify-center">
           <img className="w-24" src={image}/>
           <h2 className="text-stone-700 text-3xl">{title}</h2>
        </div>
    );
}

export default ElementCard;
