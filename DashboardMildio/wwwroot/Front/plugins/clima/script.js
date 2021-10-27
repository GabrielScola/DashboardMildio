const api = {
    key: "0583482e070f549c85d14580286d898d",
    base: "https://api.openweathermap.org/data/2.5",
    lang: "pt_br",
    units: "metric"
}

const city = document.querySelector('.city');
const date = document.querySelector('.date');
const container_img = document.querySelector('.container-img');
const temp_number = document.querySelector('.container-temp div');
const temp_unit = document.querySelector('.container-temp span');
const weather_t = document.querySelector('.weather');
const low_high = document.querySelector('.low-high');
const humidity = document.querySelector('.umidade');
let warning = document.querySelector('.warning');

window.addEventListener('load', () => {
    if ("geolocation" in navigator) {
        navigator.geolocation.getCurrentPosition(setPosition, showError);
    }
    else {
        alert('O seu navegador não suporta geolocalização!');
    }
    function setPosition(position) {
        console.log(position)
        let lat = position.coords.latitude;
        let long = position.coords.longitude;
        coordResults(lat, long);
    }

    function showError(error) {
        alert(`erro: ${error.message}`);
    }
})

function coordResults(lat, long) {
    fetch(`${api.base}/find?lat=${lat}&lon=${long}&lang=${api.lang}&units=${api.units}&appid=${api.key}`)
        .then(response => {
            console.log(response)
            if (!response.ok) {
                throw new Error(`Ocorreu um erro inesperado ao tentar buscar sua geolocalização`)
            }
            return response.json();
        })
        .catch(error => {
            alert(error.message)
        })
        .then(response => {
            displayResults(response)
        });
}

function displayResults(weather) {
    console.log(weather)

    city.innerText = `${weather.list[0].name}, ${weather.list[0].sys.country}`;

    let now = new Date();
    date.innerText = dateBuilder(now);

    let iconName = weather.list[0].weather[0].icon;


    container_img.innerHTML = `<img src="../front/dist/img/${iconName}.png">`;

    let temperature = `${Math.round(weather.list[0].main.temp)}`
    temp_number.innerHTML = temperature;
    temp_unit.innerHTML = `ºC`;

    weather_t.innerHTML = capitalizeFirstLetter(weather.list[0].weather[0].description);

    low_high.innerHTML = `${Math.round(weather.list[0].main.temp_min)}ºC / ${Math.round(weather.list[0].main.temp_max)}ºC`;

    let rain = weather.list[0].main.rain;

    humidity.innerHTML = `Umidade: ${weather.list[0].main.humidity}%`;

    warning.innerHTML = checkWarning(weather);
}

function dateBuilder(d) {
    let days = ["Domingo", "Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sábado"];
    let months = ["Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julio", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro"];

    let day = days[d.getDay()];
    let date = d.getDate();
    let month = months[d.getMonth()];
    let year = d.getFullYear();

    return `${day}, ${date} de ${month} de ${year}`;
}


function capitalizeFirstLetter(string) {
    return string.charAt(0).toUpperCase() + string.slice(1);
}

function checkWarning(weather) {
    let message = '';

    //weather.list[0].main.temp = 20;
    //weather.list[0].rain = true;
    //weather.list[0].main.humidity = 100;

    console.log(weather.list[0].main.temp, weather.list[0].rain, weather.list[0].main.humidity);

    if (weather.list[0].main.temp >= 18 &&
        weather.list[0].main.temp <= 23 &&
        weather.list[0].rain != null &&
        weather.list[0].main.humidity >= 98
    ) {
        console.log('true');
        message = `<div class="small-box bg-danger">
                    <div class="inner">
                        <center><strong>ALERTA</strong><br>Possível contaminação de míldio!</center>
                    </div>
                </div>`
    } else {
        message = '';
        console.log('false')
    }
    return message;
}