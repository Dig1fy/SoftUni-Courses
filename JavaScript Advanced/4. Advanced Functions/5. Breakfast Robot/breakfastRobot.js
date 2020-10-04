/*let x = */() => {
    let ingredients = {};
    ingredients['protein'] = 0;
    ingredients['carbohydrate'] = 0;
    ingredients['fat'] = 0;
    ingredients['flavour'] = 0;

    //listing all required ingredients for the desired product
    let apple = { carbohydrate: 1, flavour: 2 }
    let lemonade = { carbohydrate: 10, flavour: 20 }
    let burger = { carbohydrate: 5, fat: 7, flavour: 3 }
    let eggs = { protein: 5, fat: 1, flavour: 1 }
    let turkey = { protein: 10, carbohydrate: 10, fat: 10, flavour: 10 }

    function restock([microelement, quantity]) {
        ingredients[microelement] += Number(quantity);
        return "Success";
    }

    function prepare([product, quantityOfProducts]) {
        //the message will return either an object - the current product, or an error message
        let checkMessage = checkIfEnoughIngredients(product, Number(quantityOfProducts));

        if (typeof (checkMessage) === 'object') {
            prepareTheProduct(checkMessage, quantityOfProducts);
            return 'Success';
        } else {
            return checkMessage;
        }
    }
    function report() {
        return `protein=${ingredients['protein']} carbohydrate=${ingredients['carbohydrate']} fat=${ingredients['fat']} flavour=${ingredients['flavour']}`;
    }

    //We need to check if we have all the needed ingredients first
    function checkIfEnoughIngredients(productToPrepare, quantity) {
        let currentProduct = {}; 

        //we point to the refference of the current product
        switch (productToPrepare) {
            case 'lemonade': currentProduct = lemonade; break;
            case 'apple': currentProduct = apple; break;
            case 'burger': currentProduct = burger; break;
            case 'eggs': currentProduct = eggs; break;
            case 'turkey': currentProduct = turkey; break;
        }
        for (const key in currentProduct) {
            if (currentProduct[key] * quantity > ingredients[key]) {
                return `Error: not enough ${key} in stock`
            }
        }
        return currentProduct;
    }
    //After checking if all ingredients are available, we proceed with preparing the product
    function prepareTheProduct(product, quantity) {

        let objKeys = Object.keys(product);
        for (const ingredient of objKeys) {
            ingredients[ingredient] -= product[ingredient] * quantity;
        }
    }

    return function (input) {
        let args = input.split(' ');
        let action = args.shift();
        switch (action) {
            case "prepare": return prepare(args);
            case "restock": return restock(args);
            case "report": return report();
        }
    }
}