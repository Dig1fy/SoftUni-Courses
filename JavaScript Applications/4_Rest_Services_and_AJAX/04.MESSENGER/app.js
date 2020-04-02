function attachEvents() {
    const displayAreaRef = document.querySelector("#messages");
    const nameInputRef = document.querySelector("#author");
    const messageInputRef = document.querySelector("#content");
    const sendBtnRef = document.querySelector("#submit");
    const refreshBtnRef = document.querySelector("#refresh");
    const dBUrl = 'https://rest-messanger.firebaseio.com/messanger.json';
    let textToDisplay = '';

    sendBtnRef.addEventListener('click', sendMessage);
    refreshBtnRef.addEventListener('click', showAllMessages);

    function sendMessage() {
        let person = nameInputRef.value;
        let message = messageInputRef.value;

        if ( person && message){
            let newMessageObj = {
                author: person,
                content: message
            }
    
            let headers = {
                method: 'post',
                headers: { 'Content-type': 'application/json' },
                body: JSON.stringify(newMessageObj),
            }
    
            fetch(dBUrl, headers)
                .then(x => x.json())
                .then(x => {
                    nameInputRef.value = '';
                    messageInputRef.value = '';
                })
                // .then(x => showAllMessages())   //This will automatically refresh and show the newly posted message. 
                .catch(errorHandler);
        }        
    }

    function showAllMessages() {
        textToDisplay = ''
        fetch(dBUrl)
            .then(x => x.json())
            .then(data => {
                if (data) {

                    Object.entries(data).forEach(([msgId, data]) => {
                        let currentName = data.author;
                        let currentMessage = data.content;
                        textToDisplay += `${currentName}: ${currentMessage}\n`;

                        //If there are too many or inappropriate messages, just unwrap this comment and the request will delete all of them. 
                        // fetch(`https://rest-messanger.firebaseio.com/messanger/${msgId}.json`, {method: 'DELETE'})
                        // .then(x=>{showAllMessages()}) 
                    })

                    displayAreaRef.textContent = textToDisplay;
                    displayAreaRef.scrollTop = displayAreaRef.scrollHeight;
                }
            })
            .catch(errorHandler);
    }

    function errorHandler(err) {
        if (err.message) {
            displayAreaRef.textContent = `Error: ${err.message}`;
        } else {
            displayAreaRef.textContent = `Error: ${err.status} (${err.statusText})`;
        }
    }
}

attachEvents();