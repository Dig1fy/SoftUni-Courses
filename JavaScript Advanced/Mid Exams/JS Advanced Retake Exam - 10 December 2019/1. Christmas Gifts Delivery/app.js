function solution() {
    let inputGifts = document.querySelector("body > div > section:nth-child(1) > div > input[type=text]");
    let listOfGiftsRef = document.querySelector("body > div > section:nth-child(2) > ul");
    let addButton = document.querySelector("body > div > section:nth-child(1) > div > button");
    let sendButtonRef = listOfGiftsRef;
    let sendGiftsRef = document.querySelector("body > div > section:nth-child(3) > ul");
    let discardedGiftsRef = document.querySelector("body > div > section:nth-child(4) > ul");

    addButton.addEventListener('click', addGiftHandler);
    sendButtonRef.addEventListener('click', sendButtonHandler);


    function sendButtonHandler(e) {
        let newLi = document.createElement('li');
        newLi.setAttribute('class', 'gift');
        newLi.textContent = e.target.parentNode.innerText.substring(0, e.target.parentNode.innerText.length - 11);
        e.target.parentNode.remove();
        if (e.target.id === "sendButton") {
            sendGiftsRef.appendChild(newLi);

        } else if (e.target.id === "discardButton") {
            discardedGiftsRef.appendChild(newLi);
        }
    }
    
    function addGiftHandler(e) {

        let newListItem = document.createElement('li');
        newListItem.textContent = inputGifts.value;

        let sendButton = document.createElement('button');
        sendButton.setAttribute('id', 'sendButton');
        sendButton.textContent = "Send";

        let discardButton = document.createElement('button');
        discardButton.setAttribute('id', 'discardButton');
        discardButton.textContent = "Discard"

        newListItem.setAttribute('class', 'gift');
        newListItem.appendChild(sendButton);
        newListItem.appendChild(discardButton);

        listOfGiftsRef.appendChild(newListItem);
        inputGifts.value = "";

        (() => {
            let list, i, switching, b, shouldSwitch;
            list = listOfGiftsRef;
            switching = true;
            /* Make a loop that will continue until
            no switching has been done: */
            while (switching) {
                // start by saying: no switching is done:
                switching = false;
                b = listOfGiftsRef.children;
                // Loop through all list-items:
                for (i = 0; i < (b.length - 1); i++) {
                    // start by saying there should be no switching:
                    shouldSwitch = false;
                    /* check if the next item should
                    switch place with the current item: */
                    if (b[i].textContent.toLowerCase() > b[i + 1].textContent.toLowerCase()) {
                        /* if next item is alphabetically
                        lower than current item, mark as a switch
                        and break the loop: */
                        shouldSwitch = true;
                        break;
                    }
                }
                if (shouldSwitch) {
                    /* If a switch has been marked, make the switch
                    and mark the switch as done: */
                    b[i].parentNode.insertBefore(b[i + 1], b[i]);
                    switching = true;
                }
            }
        })()
    }
}