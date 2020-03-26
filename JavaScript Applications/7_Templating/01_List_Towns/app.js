let html = {
    loadBtn: document.querySelector('#btnLoadTowns'),
    inputRef: document.querySelector('#towns'),
    containerRef: document.querySelector('#root')
}

html.loadBtn.addEventListener('click', function () {

    let cities = html.inputRef.value.split(',').filter(x => x.trim());

    fetch('http://127.0.0.1:5500/template.hbs')
        .then((response) => response.text())
        .then((tempHbs) => {

            const template = Handlebars.compile(tempHbs)
            const context = { cities }

            let htmlResult = template(context)
            html.containerRef.innerHTML = htmlResult
            html.inputRef.value = ''
        })
        .catch(e => {
            alert(e)
        })
})