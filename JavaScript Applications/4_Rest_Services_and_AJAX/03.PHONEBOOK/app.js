function attachEvents() {
    const loadBtnRef = document.querySelector('#btnLoad');
    const createBtnRef = document.querySelector('#btnCreate');
    const personInputRef = document.querySelector("#person");
    const phoneInputRef = document.querySelector("#phone");
    const ulRef = document.querySelector('#phonebook');

    loadBtnRef.addEventListener('click', loadPhoneBook);
    createBtnRef.addEventListener('click', createPhonebook);

    function loadPhoneBook() {
        ulRef.innerHTML = '';
        fetch('https://phonebook-nakov.firebaseio.com/phonebook.json')
            .then(toJson)
            .then(data => {
                Object.entries(data).forEach(([id, data]) => {
                    if (data) {
                        let { person, phone } = data;

                        let newLi = document.createElement('li');
                        newLi.textContent = `${person}: ${phone}`

                        let delBtn = document.createElement('button');
                        delBtn.setAttribute('data-target', id)
                        delBtn.textContent = 'Delete';
                        delBtn.addEventListener('click', () => {
                            let currentId = id;
                            fetch(`https://phonebook-nakov.firebaseio.com/phonebook/${currentId}.json`, { method: 'DELETE' })
                                .then(x => {
                                    loadPhoneBook() //If you want to manually load the DB after deleting the record, wrap this function invocation in comment.
                                })
                        });

                        newLi.appendChild(delBtn)
                        ulRef.appendChild(newLi)

                    }
                })
            })
            .catch(errorHandler);
    }

    function createPhonebook(e) {
        let person = personInputRef.value;
        let phone = phoneInputRef.value;

        if (person && phone) {

            let headers = {
                method: 'post',
                headers: { 'Content-type': 'application/json' },
                body: JSON.stringify({ person, phone }),
            }

            fetch('https://phonebook-nakov.firebaseio.com/phonebook.json', headers)
                .then(toJson)
                .then(x => {
                    personInputRef.value = '';
                    phoneInputRef.value = '';
                    loadPhoneBook(); //If you want to manually load the DB after creating new record, wrap this function invocation in comment.
                })
                .catch(errorHandler)
        }
    }

    function toJson (data){
        if(data.status > 400){
            throw (data);
        } else {
            return data.json();
        }
    }
    function errorHandler() {
        throw new Error('Something went wrong');
    }
}

attachEvents();