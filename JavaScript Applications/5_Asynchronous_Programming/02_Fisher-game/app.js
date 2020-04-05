(() => {

    let html = {
        addBtnRef: document.querySelector("#addForm > button"),
        loadBtnRef: document.querySelector("body > aside > button"),
        baseUrl: `https://fisher-game.firebaseio.com/catches`,
        h1ErrorRef: document.querySelector('#error'),
        refreshErrorText: () => html.h1ErrorRef.textContent = ''
    }
    const template = document.querySelector("#catches > div")
    html.addBtnRef.addEventListener('click', addHandler);
    html.loadBtnRef.addEventListener('click', loadHandler);

    async function addHandler() {

        let currentCatch = {
            angler: document.querySelector("#addForm > input.angler").value,
            weight: document.querySelector("#addForm > input.weight").value,
            species: document.querySelector("#addForm > input.species").value,
            location: document.querySelector("#addForm > input.location").value,
            bait: document.querySelector("#addForm > input.bait").value,
            captureTime: document.querySelector("#addForm > input.captureTime").value,
        }

        try {
            html.refreshErrorText();

            if (isInputCorrect(currentCatch)) {
                let headers = {
                    method: 'post',
                    headers: { 'Content-type': 'application/json' },
                    body: JSON.stringify(currentCatch),
                }

                let response = await fetch(`${html.baseUrl}.json`, headers);
                let data = await response.json();
                let currentCatchID = data.name;
            }

        } catch (e) {
            errorHandler(e);
        }
    }

    async function loadHandler(e) {

        document.querySelector("#catches").innerHTML = '';
        html.refreshErrorText();

        try {
            let response = await fetch(`${html.baseUrl}.json`);
            let data = await response.json();
            Object.entries(data).forEach(([id, dataInfo]) => {
                let catchTemplate = template.cloneNode(true);
                let finalItemToAdd = fillTheTemplate(catchTemplate, id, dataInfo)
                document.querySelector("#catches").appendChild(finalItemToAdd);
            })

        } catch (e) {
            errorHandler(e);
        }
    }

    function errorHandler(e) {
        html.h1ErrorRef.textContent = `New error occured: ${e.message}`
    }

    function isInputCorrect(currentCatch) {
        let areAllObjectValuesFullfilled = Object.values(currentCatch).some(x => !x)

        if (areAllObjectValuesFullfilled) {
            throw new Error("You need to fullfill all fields")
        }

        if (!(isNaN(currentCatch.angler) && isNaN(currentCatch.species) && isNaN(currentCatch.location) && isNaN(currentCatch.bait))) {
            throw new Error("Only 'weight' and 'capture time' should be numbers!")
        }

        return true
    }

    function fillTheTemplate(catchTemplate, id, dataInfo) {
        document.querySelector("div > input.angler")
        catchTemplate.setAttribute('data-id', id);
        catchTemplate.querySelector('.angler').setAttribute('value', dataInfo.angler)
        catchTemplate.querySelector('.weight').setAttribute('value', dataInfo.weight)
        catchTemplate.querySelector('.species').setAttribute('value', dataInfo.species)
        catchTemplate.querySelector('.location').setAttribute('value', dataInfo.location)
        catchTemplate.querySelector('.bait').setAttribute('value', dataInfo.bait)
        catchTemplate.querySelector('.captureTime').setAttribute('value', dataInfo.captureTime)

        let deleteBtn = catchTemplate.querySelector('.delete');
        deleteBtn.addEventListener('click', deleteHandler);
        let updateBtn = catchTemplate.querySelector('.update');
        updateBtn.addEventListener('click', updateHandler);

        return catchTemplate;
    }

    async function deleteHandler(e) {
        try {
            html.refreshErrorText();
            let id = e.target.parentNode.getAttribute('data-id');
            let headers = { method: 'delete' };
            e.target.parentNode.remove();
            let response = await fetch(`${html.baseUrl}/${id}.json`, headers);
        } catch (e) {
            errorHandler(e)
        }
    }

    async function updateHandler(e) {
        html.refreshErrorText();

        let parentInfo = e.target.parentNode;
        let id = parentInfo.getAttribute('data-id');
        let updateUrl = `${html.baseUrl}/${id}.json`;

        let updatedObj = {
            angler: parentInfo.querySelector('.angler').value,
            weight: parentInfo.querySelector('.weight').value,
            species: parentInfo.querySelector('.species').value,
            location: parentInfo.querySelector('.location').value,
            bait: parentInfo.querySelector('.bait').value,
            captureTime: parentInfo.querySelector('.captureTime').value,
        }

        try {
            await fetch(updateUrl, {
                method: 'PUT',
                body: JSON.stringify(updatedObj)
            })
        } catch (e) {
            errorHandler(e);
        }
    }
})()