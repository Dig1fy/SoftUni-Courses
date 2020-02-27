let PizzUni = require('./solution');
let assert = require('chai').assert;

describe('PizzUni', () => {

    let pizz;
    beforeEach(() => {
        pizz = new PizzUni;
    })

    describe('constructor', () => {
        it('Constructor should initialize the class correctly', () => {
            assert.deepEqual(pizz.registeredUsers, []);
            assert.deepEqual(pizz.orders, []);
            assert.deepEqual(pizz.availableProducts, {
                pizzas: ['Italian Style', 'Barbeque Classic', 'Classic Margherita'],
                drinks: ['Coca-Cola', 'Fanta', 'Water']
            });
        })
    })
    describe('registerUser', () => {
        it('Should throw an Error if the email exists', () => {
            pizz.registerUser('Fa');
            assert.throw(() => pizz.registerUser('Fa'), Error, 'This email address (Fa) is already being used!')
        })
        it('Should register user correctly and return the user', () => {
            pizz.registerUser('Fa');
            assert.deepEqual(pizz.registeredUsers, [{
                email: 'Fa',
                orderHistory: []
            }])

            assert.deepEqual(pizz.registerUser('Go'), {
                email: 'Go',
                orderHistory: []
            })
        })
    })

    describe('makeAnOrder', () => {
        it('Should throw an Error if user does not exist', () => {
            assert.throw(() => pizz.makeAnOrder('Go', 'Barbeque Classic', 'Fanta'), Error, 'You must be registered to make orders!')
        })
        it('Should throw an Error if pizza does not exist', () => {
            pizz.registerUser('Go');
            assert.throw(() => pizz.makeAnOrder('Go', 'BBarbeque Classic', 'Fanta'), Error, 'You must order at least 1 Pizza to finish the order.')
        })
        it('Should skip the drink if it is not in the menu', () => {
            pizz.registerUser('Go');
            pizz.makeAnOrder('Go', 'Barbeque Classic', 'Fantaaa');
            assert.deepEqual(pizz.orders, [{
                orderedPizza: 'Barbeque Classic',
                email: 'Go',
                status: 'pending'
            }])
        })
        it("User order history", function () {
            pizz.registerUser('email.com');
            pizz.makeAnOrder('email.com', 'Italian Style', 'Water');
            const order = [
                {
                    orderedPizza: 'Italian Style',
                    orderedDrink: 'Water'
                }
            ]
            assert.deepEqual(pizz.registeredUsers[0].orderHistory, order);
        });
        it('Should work correctly with all proper params', () => {
            pizz.registerUser('Go');
            pizz.makeAnOrder('Go', 'Barbeque Classic', 'Fanta');
            assert.deepEqual(pizz.orders, [{
                orderedPizza: 'Barbeque Classic',
                orderedDrink: 'Fanta',
                email: 'Go',
                status: 'pending'
            }])
        })
        it('Should return correct value from the property', () => {
            pizz.registerUser('Go');
            assert.equal(pizz.makeAnOrder('Go', 'Barbeque Classic', 'Fanta'), 0);

        })
    })
    describe('completeOrder', () => {
        it('should change the status "pending" correctly', () => {
            pizz.registerUser('Go');
            pizz.registerUser('Bo');
            pizz.makeAnOrder('Go', 'Barbeque Classic', 'Fanta');
            pizz.makeAnOrder('Bo', 'Barbeque Classic', 'Fanta');
            assert.deepEqual(pizz.completeOrder(), {
                orderedPizza: 'Barbeque Classic',
                orderedDrink: 'Fanta',
                email: 'Go',
                status: 'completed'
            })
            assert.deepEqual(pizz.orders.length, 2)
        })
    })
    describe('detailsAboutMyOrder', () => {
        it('Should return the correct status', () => {
            pizz.registerUser('Go');
            pizz.registerUser('Bo');
            pizz.makeAnOrder('Go', 'Barbeque Classic', 'Fanta');
            pizz.makeAnOrder('Bo', 'Barbeque Classic', 'Fanta');
            pizz.completeOrder();
            assert.deepEqual(pizz.detailsAboutMyOrder(1), 'Status of your order: pending');
            assert.deepEqual(pizz.detailsAboutMyOrder(0), 'Status of your order: completed');
            assert.deepEqual(pizz.detailsAboutMyOrder(3), undefined);
        })
    })
    describe('doesTheUserExist', () => {
        it('Should return correct bool', () => {
            pizz.registerUser('Go');
            assert.equal(pizz.doesTheUserExist('Bo'), undefined);
            assert.deepEqual(pizz.doesTheUserExist('Go'), {
                email: 'Go',
                orderHistory: []
            })
        })
    })
})