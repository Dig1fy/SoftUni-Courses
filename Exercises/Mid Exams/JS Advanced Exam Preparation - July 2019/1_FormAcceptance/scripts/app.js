function acceptance() {
	let $elements = {
		companyRef: document.querySelector("#fields > td:nth-child(1) > input[type=text]"),
		productRef: document.querySelector("#fields > td:nth-child(2) > input[type=text]"),
		quantityRef: document.querySelector("#fields > td:nth-child(3) > input[type=text]"),
		scrapeRef: document.querySelector("#fields > td:nth-child(4) > input[type=text]"),
		addItButton: document.querySelector('#fields button'),
		availableStockRef: document.querySelector('#warehouse')
	}

	$elements.addItButton.addEventListener('click', addHandler);

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

	function addHandler() {
		let companyInput = $elements.companyRef.value;
		let productInput = $elements.productRef.value;
		let quantityInput = +$elements.quantityRef.value;
		let scrapeInput = +$elements.scrapeRef.value;
		let quantityWithoutScrape = quantityInput - scrapeInput;
		let newDiv = document.createElement('div');

		if (companyInput && productInput && typeof (quantityInput) === 'number' && typeof scrapeInput == 'number' && quantityWithoutScrape > 0 && scrapeInput) {

			let outOfStockButton = createHTMLElement('button', null, 'Out of stock', [{ k: 'type', v: 'button' }], { name: 'click', func: outOfStock });
			let paragraph = createHTMLElement('p', null, `[${companyInput}] ${productInput} - ${quantityWithoutScrape} pieces`)

			newDiv = appendChildrenToParent([paragraph, outOfStockButton], newDiv);
			$elements.availableStockRef.appendChild(newDiv);

			$elements.companyRef.value = '';
			$elements.productRef.value = '';
			$elements.quantityRef.value = '';
			$elements.scrapeRef.value = '';
		}
	}
	function outOfStock(e) {

		let rem = e.target.parentNode;
		rem.remove();
	}
}