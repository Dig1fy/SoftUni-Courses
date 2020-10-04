
function solve() {

    let addBtn = document.getElementsByTagName('button')[0];
    let inputReference = document.querySelector("input[type=text]");
    let firstLetter = '';


    addBtn.addEventListener('click', function () {

        let inputText = inputReference.value;

        firstLetter = inputText[0].toUpperCase();
        let index = firstLetter.charCodeAt(0) - 65;

        let olElements = document.querySelectorAll("ol li");
        let currentWord = inputText[0].toUpperCase() + inputText.substring(1).toLowerCase();

        if (olElements[index].textContent === '') {
            olElements[index].textContent += currentWord;
        } else {
            olElements[index].textContent += ", " + currentWord;
        }

        inputReference.value = '';
    });
}