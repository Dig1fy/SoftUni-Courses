let SkiResort = require('./solution.js');
let assert = require('chai').assert;

describe('SkiResort', function () {
    let res;
    let firstHotel;
    let secondHotel;

    this.beforeEach(() => {
        res = new SkiResort('Fok');
        res.build('HOTEL', 2);
    })

    describe('constructor', () => {
        it('constructor should initialize the class name correctly', () => {
            assert.equal(res.name, 'Fok');
        });
        it('constructor should initialize voters correctly', () => {
            assert.equal(res.voters, 0);
        });
        it('constructor should initialize the class correctly', () => {
            let secondRes = new SkiResort('Go');
            assert.deepEqual(secondRes.hotels, []);
        });
    });

    describe('bestHotel', () => {
        it('0 voters should return message "No votes yet"', () => {
            assert.equal(res.bestHotel, 'No votes yet');
        });
        it('1 or more voters should return correctMessage', () => {
            res.book('HOTEL', 2);
            res.build('MOTEL', 2);
            res.book('MOTEL', 2)
            res.leave('HOTEL', 1, 13.5);
            res.leave('MOTEL', 1, 13);
            assert.equal(res.bestHotel, 'Best hotel is HOTEL with grade 13.5. Available beds: 1');
        });
    });
    describe('build', () => {
        it('should throw an Error if incorrect hotel name is passed', () => {
            let build = () => res.build('', 5);
            assert.throw(build, 'Invalid input');
        });
        it('should throw an Error if beds < 1', () => {
            let build = () => res.build('Gringo', 0);
            assert.throw(build, 'Invalid input');
        });
        it('should work correctly with proper params', () => {
            let build = res.build('Gringo', 10);
            let arr = [];
            let hotel = { beds: 2, name: "HOTEL", points: 0 };
            let hotel2 = { beds: 10, name: "Gringo", points: 0 };
            arr.push(hotel);
            arr.push(hotel2);
            assert.equal(build, 'Successfully built new hotel - Gringo');
            assert.deepEqual(res.hotels, arr);
        });

    });
    describe('book', () => {
        it('should throw an Error if empty hotel name is passed', () => {
            let book = () => res.book('', 5);
            assert.throw(book, 'Invalid input');
        });
        it('should throw an Error if beds < 1', () => {
            let book = () => res.book('HOTEL', 0);
            assert.throw(book, 'Invalid input');
        });
        it('should throw an Error if wrong hotel name is passed', () => {
            let book = () => res.book('GG', 5);
            assert.throw(book, 'There is no such hotel');
        });
        it('should throw an Error if beds > hotel beds', () => {
            let book = () => res.book('HOTEL', 10);
            assert.throw(book, 'There is no free space');
        });
        it('should work properly with correct params', () => {
            let book = res.book('HOTEL', 2);
            assert.equal(book, 'Successfully booked');
            assert.deepEqual(res.hotels, [{ beds: 0, name: 'HOTEL', points: 0 }]);
        });
    });
    describe('leave', () => {
        it('empty hotel name should throw an Error', () => {
            let leave = () => res.leave('', 2, 2);
            assert.throw(leave, 'Invalid input');
        });
        it('beds < 1 should throw an Error', () => {
            let leave = () => res.leave('HOTEL', 0, 5);
            assert.throw(leave, 'Invalid input');
        });
        it('wrong hotel name should throw an Error', () => {
            let leave = () => res.leave('GG', 2, 2);
            assert.throw(leave, 'There is no such hotel');
        });
        it('should work correctly with proper params', () => {
            let leave = res.leave('HOTEL', 1, 2);
            assert.equal(leave, '1 people left HOTEL hotel');
            assert.deepEqual(res.voters, 1);
        });
    });
    describe('averageGrade', () => {
        it('0 voters should return proper message', () => {
            let newResort = new SkiResort('Garg');
            assert.equal(newResort.averageGrade(), 'No votes yet');
        });
        it('> 0 voters should return proper message', () => {
            res.leave('HOTEL', 1, 2);
            let total = 2.00;
            assert.deepEqual(res.averageGrade(), `Average grade: ${total.toFixed(2)}`);
        });
    })
});
