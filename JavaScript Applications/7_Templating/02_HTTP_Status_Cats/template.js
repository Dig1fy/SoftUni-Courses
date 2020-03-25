(() => {

    let btnRef = document.querySelector('#allCats');

    fetch('http://127.0.0.1:5500/templates/template.hbs')
        .then(x => x.text())
        .then(createHtml)
        .catch(e => alert(e.message))

    btnRef.addEventListener('click', function (e) {
        if (e.target.tagName === "BUTTON") {
            let btn = e.target.parentNode.querySelector('div > .status');
            btn.style.display = btn.style.display === "none" ? "inline" : "none";
            e.target.textContent = e.target.textContent === "Hide status code" ? "Show status code" : "Hide status code";
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