function solve() {
	let input = document.querySelector('#input');
	let inputValue = Array.from(input.value).reduce((a, b) => +a + +b).toString();
	let sumOfDigits = 0;

	for (let i = 0; i < inputValue.length; i++) {
		sumOfDigits += Number(inputValue[i]);
	}
	
	if (sumOfDigits.toString().length !== 1) {
		while (sumOfDigits.toString().length !== 1) {
			sumOfDigits = Array.from(sumOfDigits.toString()).reduce((a, b) => +a + +b);
		}
	}

	let adjustedInputNumbers = input.value.substring(sumOfDigits, input.value.length - Number(sumOfDigits));
	let arrayOfSections = adjustedInputNumbers.match(/[01]{1,8}/gm);
	let result = "";

	arrayOfSections.forEach(element => {
		let pattern = /[a-zA-Z ]+/gm;
		let currentSymbol = String.fromCharCode(parseInt(element, 2));

		if (pattern.test(currentSymbol)) {
			result += currentSymbol;
		}
	});

	document.querySelector('#resultOutput').innerHTML = result;
}