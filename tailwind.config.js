const colors = require("tailwindcss/colors");

module.exports = {
    content: ["./src/**/*.{html,js}"],
    theme: {
        colors: {
            stone: colors.stone,
            white: colors.white
        },
        fontFamily: {
            serif: ["Lora", "serif"]
        },
        extend: {}
    },
    plugins: [],
    extend: {
        backgroundImage: {
            "background-1": "url('/assets/background1.jpg')",
            "background-2": "url('/assets/background2.jpg')"
        }
    }
};
