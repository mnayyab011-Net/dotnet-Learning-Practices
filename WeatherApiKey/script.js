const API_KEY = "485a6abf43bc44288d280826260708";
const API_URL = "https://api.weatherapi.com/v1/current.json";

const $ = (id) => document.getElementById(id);

const cityInput = $("cityInput");
const searchBtn = $("searchBtn");
const loader = $("loader");
const errorBox = $("errorBox");

function showLoader(show) {
    loader.classList.toggle("hidden", !show);
}

function showError(message) {
    errorBox.textContent = message;
    errorBox.classList.add("show");
    setTimeout(() => errorBox.classList.remove("show"), 4000);
}

function getWeatherTip(condition, temp, humidity) {
    const text = condition.toLowerCase();

    if (text.includes("rain") || text.includes("drizzle") || text.includes("storm")) {
        return ["Rainy conditions", "Take an umbrella and consider a light waterproof jacket before heading outside."];
    }

    if (text.includes("snow") || text.includes("sleet")) {
        return ["Cold & snowy", "Dress warmly and take extra care on slippery roads and walkways."];
    }

    if (temp >= 35) {
        return ["Very hot today", "Stay hydrated, avoid prolonged direct sunlight, and keep cool when possible."];
    }

    if (temp >= 28) {
        return ["Warm weather", "Stay hydrated and use sun protection if you plan to spend time outdoors."];
    }

    if (humidity >= 80) {
        return ["High humidity", "The air may feel warmer than the temperature suggests. Keep hydrated."];
    }

    if (text.includes("sunny") || text.includes("clear")) {
        return ["Great weather", "A bright day is ahead. Sunglasses and sunscreen can make outdoor time more comfortable."];
    }

    return ["Comfortable conditions", "Check the live conditions again before making outdoor plans."];
}

function updateWeather(data) {
    const location = data.location;
    const current = data.current;
    const icon = "https:" + current.condition.icon;

    $("cityName").textContent = location.name;
    $("region").textContent = `${location.name}, ${location.country}`;
    $("dateText").textContent = new Date().toLocaleDateString("en-US", {
        weekday: "long",
        year: "numeric",
        month: "long",
        day: "numeric"
    });

    $("temperature").textContent = Math.round(current.temp_c);
    $("condition").textContent = current.condition.text;
    $("weatherIcon").src = icon;
    $("weatherIcon").alt = current.condition.text;
    $("visualIcon").src = icon;
    $("visualIcon").alt = current.condition.text;

    $("feelsLike").textContent = `${Math.round(current.feelslike_c)}°C`;
    $("humidity").textContent = `${current.humidity}%`;
    $("humidity2").textContent = `${current.humidity}%`;
    $("wind").textContent = `${Math.round(current.wind_kph)} km/h`;
    $("wind2").textContent = `${Math.round(current.wind_kph)} km/h`;
    $("windDir").textContent = `${current.wind_dir} ${current.wind_degree}°`;
    $("uv").textContent = current.uv;
    $("visibility").textContent = `${current.vis_km} km`;
    $("visibility2").textContent = `${current.vis_km} km`;
    $("pressure").textContent = `${current.pressure_mb} mb`;

    const [tipTitle, tipText] = getWeatherTip(
        current.condition.text,
        current.temp_c,
        current.humidity
    );

    $("weatherTip").textContent = tipTitle;
    $("tipText").textContent = tipText;

    updateBackground(current.condition.text);
}

function updateBackground(condition) {
    const text = condition.toLowerCase();
    const body = document.body;

    if (text.includes("rain") || text.includes("drizzle") || text.includes("storm")) {
        body.style.background = "linear-gradient(135deg, #071a35 0%, #164b83 55%, #276b9c 100%)";
    } else if (text.includes("snow") || text.includes("sleet")) {
        body.style.background = "linear-gradient(135deg, #19314b 0%, #527da1 55%, #9ec4dd 100%)";
    } else if (text.includes("cloud") || text.includes("overcast") || text.includes("mist") || text.includes("fog")) {
        body.style.background = "linear-gradient(135deg, #08264a 0%, #24649b 55%, #5c9ac3 100%)";
    } else if (text.includes("sunny") || text.includes("clear")) {
        body.style.background = "linear-gradient(135deg, #032052 0%, #0875c9 55%, #22a7e9 100%)";
    } else {
        body.style.background = "linear-gradient(135deg, #03142f 0%, #063b82 48%, #0784d9 100%)";
    }
}

async function fetchWeather(city) {
    if (!city.trim()) {
        showError("Please enter a city name.");
        return;
    }

    showLoader(true);

    try {
        const url = `${API_URL}?key=${API_KEY}&q=${encodeURIComponent(city.trim())}&aqi=yes`;
        const response = await fetch(url);
        const data = await response.json();

        if (!response.ok || data.error) {
            throw new Error(data.error?.message || "Unable to find this city.");
        }

        updateWeather(data);
    } catch (error) {
        showError(error.message || "Something went wrong while loading weather.");
    } finally {
        showLoader(false);
    }
}

searchBtn.addEventListener("click", () => fetchWeather(cityInput.value));

cityInput.addEventListener("keydown", (event) => {
    if (event.key === "Enter") {
        fetchWeather(cityInput.value);
    }
});

fetchWeather("London");
