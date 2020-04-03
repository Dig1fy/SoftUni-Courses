(function () {
    let html = {
        inputRef: document.querySelector('#location'),
        submitBtnRef: document.querySelector('#submit'),
        currentDayRef: document.querySelector('#current'),
        upcomingDaysRef: document.querySelector('#upcoming'),
        visibleRef: document.querySelector('#forecast')
    }

    html.submitBtnRef.addEventListener('click', eventHandler);

    const weatherSymbols = {
        Sunny: '☀',
        'Partly sunny': '⛅',
        Overcast: '☁',
        Rain: '☂',
        Degrees: '°'

    }

    let baseUrl = `https://judgetests.firebaseio.com/`
    let locationsUrl = x => adjustUrl(`locations.json`);
    let todayCondition = code => adjustUrl(`forecast/today/${code}.json`)
    let threeDayCondition = code => adjustUrl(`forecast/upcoming/${code}.json`)

    function adjustUrl(url) {
        return `${baseUrl}/${url}`
    }

    function fetchTemplate(url) {
        return fetch(url)
            .then(checkStatus)
            .then(toJson)
    }
    
    function eventHandler() {
        let location = html.inputRef.value;
        document.querySelector('#notification').textContent = '';

        fetchTemplate(locationsUrl())
            .then(data => {
                let current = data.find((x) => x.name === location)

                if (!current) {
                    throw new Error('Error (Invalid location)')
                }

                Promise.all([
                    fetchTemplate(todayCondition(current.code)),
                    fetchTemplate(threeDayCondition(current.code))
                ]).then(showWeatherConditions)
                    .catch(errorHandler)

            })
            .catch(errorHandler);
    }

    function checkStatus(c) {
        if (c.status === 200) {
            return c
        } else {
            throw new Error('Status code is !== 200')
        }
    }

    const toJson = (x) => x.json();

    function errorHandler(e) {
        html.visibleRef.style.display = 'none'
        document.querySelector('#notification').textContent = `New error occured: ${e.message}`
    }

    function showWeatherConditions([todayData, threeDaysData]) {
        html.currentDayRef.innerHTML = ''; //no matter how many times you click on "Get Weather", only one forecast will show. 
        html.upcomingDaysRef.innerHTML = '';
        oneDayForecast(todayData);
        threeDaysForecast(threeDaysData);
    }

    function oneDayForecast(todayData) {
        let { condition, high, low } = todayData.forecast;

        html.visibleRef.style.display = 'block'

        let forecastDiv = createElements('div', ['forecasts']);
        let spanSymbol = createElements('span', ['condition', 'symbol'], weatherSymbols[condition]);
        let spanCondition = createElements('span', ['condition'])

        let degreesTemplate = `${low}${weatherSymbols['Degrees']}/${high}${weatherSymbols['Degrees']}`

        let spanCurrentDay = createElements('span', ['forecast-data'], todayData.name)
        let spanDegrees = createElements('span', ['forecast-data'], degreesTemplate);
        let spanWeather = createElements('span', ['forecast-data'], condition);

        spanCondition.appendChild(spanCurrentDay)
        spanCondition.appendChild(spanDegrees)
        spanCondition.appendChild(spanWeather)

        forecastDiv.appendChild(spanSymbol);
        forecastDiv.appendChild(spanCondition);
        html.currentDayRef.appendChild(forecastDiv);
    }

    function threeDaysForecast(threeDaysData) {
        let forecastDiv = createElements('div', ['forecast-info']);

        threeDaysData.forecast.forEach(x => {
            let { condition, high, low } = x;

            let spanCondition = createElements('span', ['upcoming'])

            let degreesTemplate = `${low}${weatherSymbols['Degrees']}/${high}${weatherSymbols['Degrees']}`

            let spanSymbol = createElements('span', ['symbol'], weatherSymbols[condition]);
            let spanDegrees = createElements('span', ['forecast-data'], degreesTemplate);
            let spanWeather = createElements('span', ['forecast-data'], condition);

            spanCondition.appendChild(spanSymbol);
            spanCondition.appendChild(spanDegrees);
            spanCondition.appendChild(spanWeather);
            forecastDiv.appendChild(spanCondition);
            html.upcomingDaysRef.appendChild(forecastDiv);
        })
    }

    function createElements(tagName, classNames, textContent) {
        let element = document.createElement(tagName);

        if (classNames) {
            element.classList.add(...classNames);
        }

        if (textContent) {
            element.textContent = textContent;
        }

        return element;
    }
}())