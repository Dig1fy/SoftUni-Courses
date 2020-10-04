function lockedProfile() {
    const $buttons = [...document.getElementsByTagName('button')];
    $buttons.forEach(btn => btn.addEventListener('click', showHide));
 
    function showHide(event) {
        const currentButton = event.target;
        const profile = currentButton.parentNode;
        const moreInformation = profile.getElementsByTagName('div')[0];
        const lockStatus = profile.querySelector('input[type="radio"]:checked').value;
 
        if (lockStatus === 'unlock') {
            if (currentButton.textContent === 'Show more') {
                moreInformation.style.display = 'inline-block';
                currentButton.textContent = 'Hide it';
            } else if (currentButton.textContent === 'Hide it') {
                moreInformation.style.display = 'none';
                currentButton.textContent = 'Show more';
            }
        }
    }
}