const baseUrl = `https://students-7b392.firebaseio.com/students.json`; //You can put your firebase url here if you'd like to use your data base

function makeHeaders(method, data) {
    const headers = {
        method: method,
        headers: {
            'Content-Type': 'application/json'
        }
    }
    if (method === 'POST') {
        headers.body = JSON.stringify(data);
    }
    return headers;
}

async function get() {
    const headers = makeHeaders('GET');
    const data = await fetchRequest(baseUrl, headers);
    return data;
}
async function post(body) {
    const headers = makeHeaders('POST', body);
    const data = fetchRequest(baseUrl, headers);
    return data;
}
async function del() {
    const headers = makeHeaders('DELETE');
    return fetchRequest(baseUrl, headers);
}
async function fetchRequest(url, headers) {
    return fetch(url, headers)
        .then(checkForErrors)
        .then(data => data.json())
        .catch(console.error)
}
function checkForErrors(req) {
    if (!req.ok) {
        throw new Error(`${req.status} - ${req.statusText}`);
    }

    return req;
}
export { get, post, del }