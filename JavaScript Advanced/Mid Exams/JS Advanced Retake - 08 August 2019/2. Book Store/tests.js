let BookStore = require('./solution.js');
let assert = require('chai').assert;

describe('BookStore', () => {
    let store;
    beforeEach(() => {
        store = new BookStore('Sword');
    })
    describe('constructor', () => {
        it('constructor should initialize a class correctly', () => {
            assert.equal(store.name, 'Sword');
            assert.deepEqual(store.books, []);
            assert.deepEqual(store.workers, []);
        })
    })

    describe('stockBooks', () => {
        it('Should push new autor-book correctly', () => {
            store.stockBooks(['Inferno-Dan Braun']);
            assert.deepEqual(store.books[0].author, 'Dan Braun')
            assert.deepEqual(store.books[0].title, 'Inferno')
            assert.deepEqual(store.books.length, 1);
            assert.deepEqual(store.stockBooks(['A-B']), [
                {title: 'Inferno', author: 'Dan Braun'}, {title: 'A', author: 'B'}
            ])
        })
    })
    describe('hire', () => {
        it('should work correctly if author does not exist', () => {
            store.hire('Gosho', 'seller');
            assert.deepEqual(store.workers[0], {
                name: 'Gosho',
                position: 'seller',
                booksSold: 0
            })
            assert.deepEqual(store.hire('Pe', 'seller'), `Pe started work at Sword as seller`)
        })
        it('should throw an Error if the worker exists', () => {
            store.hire('Gosho', 'seller');
            assert.throw(() => store.hire('Gosho', 'seller'), Error, 'This person is our employee')
        })
    })

    describe('fire', () => {
        it('should throw an Error if the person does not exist', () => {
            assert.throw(() => store.fire('AsanDjibri'), Error, `AsanDjibri doesn't work here`)
        })
        it('should remove the person from the "workers" and return proper text', () => {
            store.hire('Joe', 'seller');
            assert.equal(store.workers.some(x => x.name === 'Joe'), true);

            assert.equal(store.fire('Joe'), 'Joe is fired');
            assert.equal(store.workers.some(x => x.name === 'Joe'), false);
        })
    })

    describe('sellBook', () => {
        it('throw an Error if the book does not exist', () => {
            assert.throw(() => store.sellBook('Ko', 'Gosho'), Error, 'This book is out of stock')
        })
        it('throw an Error if the worker does not exist', () => {
            store.stockBooks(['It-Ivan']);
            assert.throw(() => store.sellBook('It', 'Gosho'), Error, 'Gosho is not working here')
        })
        it('Should work correctly if proper params are given', () => {
            store.stockBooks(['It-Ivan']);
            store.hire('Ivan', 'seller');
            store.sellBook('It', 'Ivan');
            assert.equal(store.books.length, 0);
            assert.equal(store.workers.find(x => x.name === 'Ivan').booksSold, 1);
        })
    })

    describe('printWorkers', ()=>{
        it('should return proper text output', ()=>{
            store.stockBooks(['It-DB']);
            
            store.hire('Ivan', 'seller');
            store.hire('Gosho', 'prostitute');
            store.sellBook('It', 'Gosho');

            let expected = `Name:Ivan Position:seller BooksSold:0\nName:Gosho Position:prostitute BooksSold:1`;
            assert.equal(store.printWorkers(),expected )

        })
    })


})