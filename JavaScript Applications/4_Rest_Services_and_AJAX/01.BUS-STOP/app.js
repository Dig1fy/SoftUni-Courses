function getInfo() {

    const stopIdRef = document.querySelector('#stopId');
    const stopNameRef = document.querySelector('#stopName');
    const bussesRef = document.querySelector('#buses');
    const requestUrl = `https://judgetests.firebaseio.com/businfo/${stopIdRef.value}.json`;

    fetch(requestUrl)
        .then(res => res.json())
        .then(data => {
            bussesRef.textContent = '';
            stopIdRef.value = '';

            let { name, buses } = data;
            stopNameRef.textContent = name;
            Object.entries(buses).forEach(([busNumber, timeToArrive]) => {

                let newLi = document.createElement('li');
                newLi.textContent = `Bus ${busNumber} arrives in ${timeToArrive}`
                bussesRef.appendChild(newLi);
            })
        })
        .catch(x => {
            stopNameRef.textContent = "Error"
        })
}