function toggle() {
    const button = document.querySelector('body > div .button');

    const paragraph = document.querySelector('#extra ');

    if (button.textContent === 'More') {

        button.textContent = 'Less';
        paragraph.style.display = 'block';
    } else {
        button.textContent = 'More';
        paragraph.style.display = 'none';
    }
}