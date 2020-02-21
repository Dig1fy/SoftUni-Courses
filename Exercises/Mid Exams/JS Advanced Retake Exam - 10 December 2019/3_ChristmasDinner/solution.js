class ChristmasDinner {
    constructor(budget) {
        this.budget = budget;
        this.dishes = [];
        this.products = [];
        this.guests = {};
    }

    get budget() {
        return this._budget;
    }

    set budget(value) {
        if ((value) < 0) {
            throw new Error("The budget cannot be a negative number");
        }

        this._budget = value;
    }

    shopping(product) {
        let type = product[0];
        let price = +product[1];

        if (price > this.budget) {
            throw new Error('Not enough money to buy this product');
        }

        this.products.push(type);
        this.budget -= price;
        return `You have successfully bought ${type}!`;
    }

    recipes(recipe) {
        let recipeName = recipe.recipeName;
        let productsList = recipe.productsList;

        for (const product of productsList) {
            if (!this.products.includes(product)) {
                throw new Error('We do not have this product');
            }
        }

        this.dishes.push(recipe);
        return `${recipeName} has been successfully cooked!`
    }

    inviteGuests(currentName, dish) {
        if (!this.dishes.map(x => x['recipeName'].includes(dish))) {
            throw new Error('We do not have this dish');
        } else if (this.guests.hasOwnProperty(currentName)) {
            throw new Error('This guest has already been invited');
        }

        this.guests[currentName] = dish;
        return `You have successfully invited ${currentName}!`
    }

    showAttendance() {
        let result = [];
        let arr = Object.entries(this.guests);
        for (const guest of arr) {
            let guestName = guest[0];
            let dishName = guest[1];
            let dishIngredients = this.dishes.find(x => x.recipeName === dishName);

            result.push(`${guestName} will eat ${dishName}, which consists of ${dishIngredients.productsList.join(', ')}`);
        }

        return result.join('\n').trim();
    }
}



// let dinner = new ChristmasDinner(300);

// dinner.shopping(['Salt', 1]);
// dinner.shopping(['Beans', 3]);
// dinner.shopping(['Cabbage', 4]);
// dinner.shopping(['Rice', 2]);
// dinner.shopping(['Savory', 1]);
// dinner.shopping(['Peppers', 1]);
// dinner.shopping(['Fruits', 40]);
// dinner.shopping(['Honey', 10]);

// dinner.recipes({
//     recipeName: 'Oshav',
//     productsList: ['Fruits', 'Honey']
// });
// dinner.recipes({
//     recipeName: 'Folded cabbage leaves filled with rice',
//     productsList: ['Cabbage', 'Rice', 'Salt', 'Savory']
// });
// dinner.recipes({
//     recipeName: 'Peppers filled with beans',
//     productsList: ['Beans', 'Peppers', 'Salt']
// });

// dinner.inviteGuests('Ivan', 'Oshav');
// dinner.inviteGuests('Petar', 'Folded cabbage leaves filled with rice');
// dinner.inviteGuests('Georgi', 'Peppers filled with beans');

// console.log(dinner.showAttendance());