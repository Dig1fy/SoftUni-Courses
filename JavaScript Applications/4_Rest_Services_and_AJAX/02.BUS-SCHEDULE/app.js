function solve() {

    const displayInfoRef = document.querySelector("#info > span");
    const departBtnRef = document.querySelector('#depart');
    const arriveBtnRef = document.querySelector('#arrive');
    let currentStopId = 'depot';
    let currentStopName = '';

    function toJson (data){
        if(data.status >= 400){
            throw(data);
        }

        return data.json();
    }
    function depart() {
        fetch(`https://judgetests.firebaseio.com/schedule/${currentStopId}.json`)
            .then(toJson)
            .then(successfullyDeparted)
            .catch(catchError);
    }

    function successfullyDeparted(data) {
        const { name, next } = data;
        currentStopId = next;
        currentStopName = name;
        
        departBtnRef.disabled = true;
        arriveBtnRef.disabled = false;

        displayInfoRef.innerHTML = `Next stop ${currentStopName}`;
    }
    function arrive() {
        displayInfoRef.innerHTML = `Arriving at ${currentStopName}`
        departBtnRef.disabled = false;
        arriveBtnRef.disabled = true;
    }

    function catchError (){
        displayInfoRef.innerHTML = 'Error';
        departBtnRef.disabled = true;
        arriveBtnRef.disabled = true;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();