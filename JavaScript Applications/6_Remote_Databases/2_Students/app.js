import { get, post, del } from './dbRequester.js'

let html = {
    tBodyRef: document.querySelector("#results > tbody"),
    submitBtn: document.querySelector("body > form > button"),
    idCounter: document.querySelector("#data-id"),
    extractBtnRef: document.querySelector("#extractAll"),
    deleteBtn: document.querySelector('#deleteBtn')
}

html.idCounter.disabled = true;
setInitialCounter();

html.submitBtn.addEventListener('click', submitHandler)
html.extractBtnRef.addEventListener('click', extractHandler)
html.deleteBtn.addEventListener('click', deleteHanlder);

async function submitHandler(e) {
    e.preventDefault()

    let newObj = {
        id: html.idCounter.value,
        firstName: document.querySelector("#firstName").value,
        lastName: document.querySelector("#lastName").value,
        facultyNumber: document.querySelector("#facultyNumber").value,
        grade: document.querySelector("#grade").value,
    }

    try {
        checkInputValues(newObj);
        html.idCounter.value++;

        let response = await post(newObj)

        if (response) {
            document.querySelector("#firstName").value = '';
            document.querySelector("#lastName").value = '';
            document.querySelector("#facultyNumber").value = '';
            document.querySelector("#grade").value = '';
        } else {
            throw new Error('Please double check your url!')
        }
    } catch (e) {
        errorHandler(e);
    }
}

async function extractHandler() {

    html.tBodyRef.innerHTML = '';
    let data = await get()

    if (data) {
        Object.entries(data).forEach(([firebaseId, objInfo]) => {

            let tr = document.createElement('tr');
            let tdId = createHtmlElement('td', objInfo.id)
            let tdfirstName = createHtmlElement('td', objInfo.firstName)
            let tdlastName = createHtmlElement('td', objInfo.lastName)
            let tdfacultyNumber = createHtmlElement('td', objInfo.facultyNumber)
            let tdgrade = createHtmlElement('td', objInfo.grade)
            tr = appendChildren([tdId, tdfirstName, tdlastName, tdfacultyNumber, tdgrade], tr)

            html.tBodyRef.appendChild(tr)
        })
    }
}

async function deleteHanlder(e) {
    let data = await del()
    html.idCounter.value = 1;
    extractHandler()
}

function createHtmlElement(tagName, value) {
    let el = document.createElement(tagName);
    el.textContent = value;
    return el;
}

function appendChildren(children, parent) {
    children.forEach(x => parent.appendChild(x));
    return parent;
}

function errorHandler(e) {
    alert(e.message);
}

async function setInitialCounter() {
    try {
        let data = await get()

        if (data) {
            html.idCounter.value = Object.values(data).length + 1;
        } else {
            html.idCounter.value = 1
        }
    } catch (e) {
        alert('This URL seems to be broken. Please try again in 6 hours!');
    }
}

function checkInputValues(newObj) {
    if (!newObj.firstName || !newObj.lastName || !newObj.facultyNumber || !newObj.grade) {
        throw new Error('You need to fulfill all fields.');
    }
    if (isNaN(newObj.facultyNumber)) {
        throw new Error('Faculty number should contain only digits');
    }
    if (isNaN(newObj.grade)) {
        throw new Error('Grade should be a number');
    }
    if (!isNaN(newObj.firstName)) {
        throw new Error('First name cannot be a number');
    }
    if (!isNaN(newObj.lastName)) {
        throw new Error('Last name cannot be a number');
    }
}