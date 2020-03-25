(() => {

    let btnRef = document.querySelector('#allCats');

    fetch('http://127.0.0.1:5500/templates/template.hbs')
        .then(x => x.text())
        .then(createHtml)
        .catch(e => alert(e.message))

    btnRef.addEventListener('click', function (e) {
        if (e.target.tagName === "BUTTON") {
            let btn = e.target.parentNode.querySelector('div > .status');

            if (btn.style.display === "none") {
                btn.style.display = "inline"
                e.target.textContent = "Hide status code";
            } else {
                btn.style.display = "none"
                e.target.textContent = "Show status code";
            }
        }
    })

    function createHtml(catsTemplate) {
        const template = Handlebars.compile(catsTemplate)
        const context = { cats: window.cats }
        const catsHtml = template(context);

        const ul = document.querySelector("#allCats > ul");
        ul.innerHTML = catsHtml
    }
})()