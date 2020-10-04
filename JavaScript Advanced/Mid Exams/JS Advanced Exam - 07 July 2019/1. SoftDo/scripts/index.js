function mySolution() {    
    let $elements = { //keeping all html references in $element 
        textAreaRef: document.querySelector('#inputSection > textarea'),
        userNameRef: document.querySelector('#inputSection > div > input'),
        sendButtonRef: document.querySelector('#inputSection > div > button'),
        pendingQuestionsRef: document.querySelector('#pendingQuestions'),
        openQuestionsRef: document.querySelector('#openQuestions')
    }

    $elements.sendButtonRef.addEventListener('click', sendHandler);

    function sendHandler() { //TODO - remove the initial input values
        let userName = $elements.userNameRef.value;
        let currentQuestion = $elements.textAreaRef.value;

        if (!userName) {
            userName = 'Anonymous'
        }

        let divSection = createHTMLElement('div', 'pendingQuestion');
        let img = createHTMLElement('img', null, null, [{ k: 'src', v: './images/user.png' },
        { k: 'width', v: '32' }, { k: 'height', v: '32' }])
        let spanUsername = createHTMLElement('span', null, `${userName}`);
        let paragraphQuestion = createHTMLElement('p', null, `${currentQuestion}`);

        let divActions = createHTMLElement('div', 'actions');
        let archiveButton = createHTMLElement('button', 'archive', 'Archive', null, { name: 'click', func: archiveHandler });
        let openButton = createHTMLElement('button', 'open', 'Open', null, { name: 'click', func: openHandler });

        divActions = appendChildrenToParent([archiveButton, openButton], divActions);
        divSection = appendChildrenToParent([img, spanUsername, paragraphQuestion, divActions], divSection);
        $elements.pendingQuestionsRef.appendChild(divSection);

        $elements.textAreaRef.value = '';
        $elements.userNameRef.value = '';
    }

    function openHandler(e) {
        e.target.parentNode.parentNode.className = 'openQuestion';
        let mainDivWrapper = e.target.parentNode.parentNode;

        let currentDiv = e.target.parentNode;


        currentDiv.innerHTML = '';   //Deleting the "Archive" and "Open" buttons
        let replyBtn = createHTMLElement('button', 'reply', 'Reply');
        currentDiv.appendChild(replyBtn);

        let divReplySection = createHTMLElement('div', null, null, [{ k: 'class', v: 'replySection' }, { k: 'style', v: 'display: none;' }]);
        let inputElement = createHTMLElement('input', 'replyInput', null, [{ k: 'type', v: 'text' }, { k: 'placeholder', v: 'Reply to this question here...' }]);
        let sendAnswerBtn = createHTMLElement('button', 'replyButton', 'Send');
        let ol = createHTMLElement('ol', 'reply', null, [{ k: 'type', v: '1' }])
        // Appending input, sendBtn and ol -> should be children of divReplySection
        divReplySection = appendChildrenToParent([inputElement, sendAnswerBtn, ol], divReplySection);
        mainDivWrapper.appendChild(divReplySection);

        sendAnswerBtn.addEventListener('click', () => { //Added the event here so the inputElement is being accessible
            let li = document.createElement('li');
            li.textContent = inputElement.value;
            ol.appendChild(li);
        })

        replyBtn.addEventListener('click', (e) => {
            if (e.target.textContent === 'Reply') {
                replyBtn.textContent = 'Back';
                divReplySection.style.display = 'block';
            } else {
                replyBtn.textContent = 'Reply';
                divReplySection.style.display = 'none';
            }
        })

        $elements.openQuestionsRef.appendChild(mainDivWrapper);

    }

    function archiveHandler(e) {
        e.target.parentNode.parentNode.remove();
    }

    function createHTMLElement(tagName, className, textContent, attributes, event) {

        let element = document.createElement(tagName);

        if (className) {
            element.classList.add(className);
        }

        if (textContent) {
            element.textContent = textContent;
        }

        if (attributes) {  // attributes = [{k: "type", v: "button"}, {...} ...]
            attributes.forEach((a) => element.setAttribute(a.k, a.v));
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
}