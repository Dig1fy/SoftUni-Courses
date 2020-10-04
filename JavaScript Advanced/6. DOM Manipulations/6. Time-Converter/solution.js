function attachEventsListeners() {

    let daysInput = document.querySelector('#days');
    let hoursInput = document.querySelector('#hours');
    let minutesInput = document.querySelector('#minutes');
    let secondsInput = document.querySelector('#seconds');

    let daysBtn = document.querySelector('#daysBtn');
    let hoursBtn = document.querySelector('#hoursBtn');
    let minutesBtn = document.querySelector('#minutesBtn');
    let secondsBtn = document.querySelector('#secondsBtn');

    daysBtn.addEventListener('click', () => {
        let days = daysInput.value;
        hoursInput.value = days * 24;
        minutesInput.value = hoursInput.value * 60;
        secondsInput.value = minutesInput.value * 60;
    })

    hoursBtn.addEventListener('click', function () {
        let hours = hoursInput.value;
        daysInput.value = hours / 24;
        minutesInput.value = hours * 60;
        secondsInput.value = minutesInput.value * 60;
    });

    minutesBtn.addEventListener('click', function () {
        let minutes = minutesInput.value;
        hoursInput.value = minutes / 60;
        daysInput.value = minutes / 60 / 24;
        secondsInput.value = minutes * 60;
    });

    secondsBtn.addEventListener('click', function () {
        let seconds = secondsInput.value;
        hoursInput.value = seconds / 60 / 60;
        minutesInput.value = seconds / 60;
        daysInput.value = seconds / 60 / 60 / 24;
    });
}