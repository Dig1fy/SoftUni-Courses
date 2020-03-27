import { monkeys } from './monkeys.js'

(function () {
    fetch('templates/all-monkeys.hbs')
        .then(x => x.text())
        .then(tempHbs => {

            const template = Handlebars.compile(tempHbs);
            let context = { monkeys }
            let monkeysHTML = template(context);

            let divWrapper = document.querySelector("body > section > div");
            divWrapper.innerHTML = monkeysHTML;

            divWrapper.addEventListener('click', function (e) {
                if (e.target.tagName === "BUTTON") {
                    let currentStyle = e.target.parentNode.querySelector('p');

                    currentStyle.style.display = currentStyle.style.display === "none" ? "block" : "none"
                    e.target.textContent = e.target.textContent === "Info" ? "Hide Info" : "Info"
                }
            })
        })
})()