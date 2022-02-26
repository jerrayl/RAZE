export const ELEMENTS = {
    FIRE : "FIRE",
    WATER: "WATER",
    EARTH: "EARTH",
    AIR: "AIR",
    FOOD: "FOOD",
    ARCANE: "ARCANE"
}


export const buildings = [
    {
        name : "Bakery",
        code: "FOOD-1",
        cost : [
            {[ELEMENTS.FIRE] : 2},
            {[ELEMENTS.EARTH] : 1}
        ],
        production : 1,
        health: 1,
        effect: null
    },
    {
        name : "Farm",
        code: "FOOD-2",
        cost : [
            {[ELEMENTS.WATER] : 3},
            {[ELEMENTS.EARTH] : 2}
        ],
        production : 2,
        health: 1,
        effect: null
    },
    {
        name : "Tavern",
        code: "FOOD-3",
        cost : [
            {[ELEMENTS.FIRE] : 4},
            {[ELEMENTS.WATER] : 3},
            {[ELEMENTS.EARTH] : 1}
        ],
        production : 3,
        health: 3,
        effect: null
    },
    {
        name : "Sawmill",
        code: "FIRE-1",
        cost : [
            {[ELEMENTS.WATER] : 1},
            {[ELEMENTS.EARTH] : 1},
            {[ELEMENTS.AIR] : 1}
        ],
        production : 1,
        health: 1,
        effect: null
    },
    {
        name : "Oilfield",
        code: "FIRE-2",
        cost : [
            {[ELEMENTS.WATER] : 3},
            {[ELEMENTS.EARTH] : 2}
        ],
        production : "",
        health: "",
        effect: ""
    },
    {
        name : "Magic Forge",
        code: "FIRE-3",
        cost : [
            {[ELEMENTS.WATER] : 3},
            {[ELEMENTS.EARTH] : 2}
        ],
        production : "",
        health: "",
        effect: ""
    },
    {
        name : "Well",
        code: "WATER-1",
        cost : [
            {[ELEMENTS.WATER] : 3},
            {[ELEMENTS.EARTH] : 2}
        ],
        production : "",
        health: "",
        effect: ""
    },
    {
        name : "Potion Lab",
        code: "WATER-2",
        cost : [
            {[ELEMENTS.WATER] : 3},
            {[ELEMENTS.EARTH] : 2}
        ],
        production : "",
        health: "",
        effect: ""
    },
    {
        name : "Distillation Plant",
        code: "WATER-3",
        cost : [
            {[ELEMENTS.WATER] : 3},
            {[ELEMENTS.EARTH] : 2}
        ],
        production : "",
        health: "",
        effect: ""
    },
    {
        name : "Mine",
        code: "EARTH-1",
        cost : [
            {[ELEMENTS.WATER] : 3},
            {[ELEMENTS.EARTH] : 2}
        ],
        production : "",
        health: "",
        effect: ""
    },
    {
        name : "Quarry",
        code: "EARTH-2",
        cost : [
            {[ELEMENTS.WATER] : 3},
            {[ELEMENTS.EARTH] : 2}
        ],
        production : "",
        health: "",
        effect: ""
    },
    {
        name : "Occult Crystal",
        code: "EARTH-3",
        cost : [
            {[ELEMENTS.WATER] : 3},
            {[ELEMENTS.EARTH] : 2}
        ],
        production : "",
        health: "",
        effect: ""
    },
    {
        name : "Windmill",
        code: "AIR-1",
        cost : [
            {[ELEMENTS.WATER] : 3},
            {[ELEMENTS.EARTH] : 2}
        ],
        production : "",
        health: "",
        effect: ""
    },
    {
        name : "Airship Tower",
        code: "AIR-2",
        cost : [
            {[ELEMENTS.WATER] : 3},
            {[ELEMENTS.EARTH] : 2}
        ],
        production : "",
        health: "",
        effect: ""
    },
    {
        name : "Meteorology Tower",
        code: "AIR-3",
        cost : [
            {[ELEMENTS.WATER] : 3},
            {[ELEMENTS.EARTH] : 2}
        ],
        production : "",
        health: "",
        effect: ""
    },
    {
        name : "Castle",
        code: "CASTLE",
        cost : [
            {[ELEMENTS.ARCANE] : 5}
        ],
        production : "",
        health: "",
        effect: ""
    },
]