function solve() {
    //30 additional lines of code and still 91 out of 100.. 
    let $elements = {
        titleRef: document.querySelectorAll('body > form > input')[0],
        yearRef: document.querySelectorAll('body > form > input')[1],
        priceRef: document.querySelectorAll('body > form > input')[2],
        addButtonRef: document.querySelector('body > form > button'),
        newBooksSectionRef: document.querySelector('#outputs > section:nth-child(2) > div'),
        oldBooksSectionRef: document.querySelector('#outputs > section:nth-child(1) > div'),
        totalPriceRef: document.querySelector("body > h1:nth-child(3)")
    }

    $elements.addButtonRef.addEventListener('click', addBookHandler);

    function addBookHandler(e) {
        e.preventDefault();
        let currentTitle = $elements.titleRef.value;
        let currentYear = $elements.yearRef.value;
        let currentPrice = $elements.priceRef.value;

        if (currentTitle && currentYear >= 0 && currentPrice >= 0 && currentPrice && currentYear) {

            let newDiv = createHTMLElement('div', 'book');
            let divParagraph = createHTMLElement('p', null, `${currentTitle} [${currentYear}]`);
            let buyBtn = createHTMLElement('button', null, `Buy it only for ${(Number(currentPrice)).toFixed(2)} BGN`, null, { name: 'click', func: buyItHandler });
            let moveBtn = createHTMLElement('button', null, 'Move to old section', null, { name: 'click', func: moveHandler });

            newDiv = appendChildrenToParent([divParagraph, buyBtn], newDiv);
            if (currentYear >= 2000) {
                newDiv = appendChildrenToParent([moveBtn], newDiv);
                $elements.newBooksSectionRef.appendChild(newDiv);
            } else {
                buyBtn.textContent = (`Buy it only for ${(Number(buyBtn.textContent.match(/\d+.\d*/g)) * 0.85).toFixed(2)} BGN`);
                $elements.oldBooksSectionRef.appendChild(newDiv);
            }

            $elements.titleRef.value = '';
            $elements.priceRef.value = '';
            $elements.yearRef.value = '';
        }
    }
    function moveHandler(e) {

        let buyBtnRef = e.target.parentNode.querySelector('button');
        let newPrice = (Number(buyBtnRef.textContent.match(/\d+.\d*/g)) * 0.85);
        buyBtnRef.textContent = `Total Store Profit: ${newPrice.toFixed(2)} BGN`;
        $elements.oldBooksSectionRef.appendChild(e.target.parentNode);
        e.target.remove();
    }
    function buyItHandler(e) {

        let totalPrice = Number($elements.totalPriceRef.textContent.match(/\d+.\d*/g));
        let btnPrice = e.target.parentNode.querySelector('button');
        totalPrice += Number(btnPrice.textContent.match(/\d+.\d*/g));
        $elements.totalPriceRef.textContent = `Total Store Profit: ${totalPrice.toFixed(2)} BGN`;
        e.target.parentNode.remove();
    }
    function createHTMLElement(tagName, className, textContent, attributes, event) {

        let element = document.createElement(tagName);

        if (className) {
            element.classList.add(className);
        }

        if (textContent) {
            element.textContent = textContent;
        }

        if (attributes) {
            attributes.forEach((a) => element.setAttribute(a.k, a.v));
        }

        if (event) {
            element.addEventListener(event.name, event.func);
        }

        return element;
    }

    function appendChildrenToParent(children, parent) {
        children.forEach((c) => parent.appendChild(c));
        return parent;
    }
}