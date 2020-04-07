import { get, put, del, post } from './dbRequester.js';

let html = {
    title: document.querySelector("#title"),
    author: document.querySelector("#author"),
    isbn: document.querySelector("#isbn"),
    submitBtn: document.querySelector("body > form > button"),
    loadAllBooksBtn: document.querySelector("#loadBooks")
}

html.loadAllBooksBtn.addEventListener('click', loadHandler)
html.submitBtn.addEventListener('click', submitHandler);

async function submitHandler(e) {
    e.preventDefault();

    if (await isInputCorrect()) {
        let newBook = {
            title: html.title.value,
            author: html.author.value,
            isbn: html.isbn.value
        }

        await post(`books.json`, newBook)
        deleteInputValues();
    }
}

async function loadHandler(e) {

    try {
        let getData = await get('books.json')
        let table = document.querySelector("body > table > tbody")
        table.innerHTML = '';

        Object.entries(getData).forEach(([id, data]) => {
            let tr = createHTMLElement('tr')
            let td1 = createHTMLElement('td', data.title);
            let td2 = createHTMLElement('td', data.author)
            let td3 = createHTMLElement('td', data.isbn)
            let td4 = createHTMLElement('td');

            let edinBtn = createHTMLElement('button', 'Edit', { name: 'click', func: editHandler })
            let deleteBtn = createHTMLElement('button', 'Delete', { name: 'click', func: deleteHandler })

            tr = appendChildrenToParent([td1, td2, td3], tr)
            td4 = appendChildrenToParent([edinBtn, deleteBtn], td4)
            tr.appendChild(td4);
            tr.addEventListener('click', allocateHandler)
            table.appendChild(tr)
        })
    } catch (e) {
        
        errorHandler(e)
    }
}

async function isInputCorrect() {
    if (!html.title.value) {
        alert("Title cannot be empty");
        return false;
    } else if (!html.author.value) {
        alert("Author cannot be empty");
        return false;
    } else if (!html.isbn.value) {
        alert("ISBN cannot be empty");
        return false;
    }

    return true;
}

async function editHandler(e) {
    let initialBook = {
        title: e.target.parentNode.parentNode.children[0].textContent,
        author: e.target.parentNode.parentNode.children[1].textContent,
        isbn: e.target.parentNode.parentNode.children[2].textContent
    }

    let checkForBook = await findId(initialBook);

    if (checkForBook) {
        let bookId = checkForBook.id;

        let editedBook = {
            title: html.title.value,
            author: html.author.value,
            isbn: html.isbn.value
        }

        if (await isInputCorrect()) {
            deleteInputValues();
            await put(`books/${bookId}.json`, editedBook);
            loadHandler()
        }
    }
}

async function deleteHandler(e) {

    let desiredObj = {
        title: e.target.parentNode.parentNode.children[0].textContent,
        author: e.target.parentNode.parentNode.children[1].textContent,
        isbn: e.target.parentNode.parentNode.children[2].textContent
    }

    let returnedData = await findId(desiredObj);
    e.target.parentNode.parentNode.remove();
    await del(`books/${returnedData.id}.json`);
}

async function findId(objToCheck) {
    let data = await get(`books.json`);
    let obj;

    Object.entries(data).forEach(([bookId, bookInfo]) => {
        if (objToCheck.title === bookInfo.title && objToCheck.author === bookInfo.author && objToCheck.isbn === bookInfo.isbn) {
            obj = {
                id: bookId,
                title: bookInfo.title,
                author: bookId.author,
                isbn: bookInfo.isbn
            }
        }
    })

    return obj;
}

async function allocateHandler(e) {
    if (e.target.tagName !== "BUTTON") {

        html.title.value = e.target.parentNode.children[0].textContent
        html.author.value = e.target.parentNode.children[1].textContent
        html.isbn.value = e.target.parentNode.children[2].textContent
    }
}

function deleteInputValues() {
    html.title.value = '';
    html.author.value = '';
    html.isbn.value = '';
}

function createHTMLElement(tagName, textContent, event) {

    let element = document.createElement(tagName);

    if (textContent) {
        element.textContent = textContent;
    }

    if (event) { // {name: 'click', func: function}
        element.addEventListener(event.name, event.func);
    }

    return element;
}

function appendChildrenToParent(children, parent) {
    children.forEach((c) => parent.appendChild(c));
    return parent;
}

function errorHandler(e) {
    alert(`New error occurred: ${e.message}. Check your data base URL`)
}