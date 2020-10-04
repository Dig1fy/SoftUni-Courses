let ChristmasMovies = require('./solution.js');
let assert = require('chai').assert;
//90 out of 100.

describe('ChristmasMovies', () => {
    let movie;
    beforeEach(() => {
        movie = new ChristmasMovies();
    })
    describe('constructor', () => {
        it('constructor should initialize the class correctly', () => {
            assert.deepEqual(movie.movieCollection, [])
            assert.deepEqual(movie.watched, {})
            assert.deepEqual(movie.actors, [])
        })
    })

    describe('buyMovie', () => {
        it('should throw Error if the movie is in our movieCollection', () => {
            let newM = new ChristmasMovies()
            newM.buyMovie('GIJoe', ["Stefo, Mischelle"])
            assert.throw(() => newM.buyMovie('GIJoe', 'Stefo'), Error, 'You already own GIJoe in your collection!')
        })
        it('should return correct output if params are correct', () => {
            let newM = new ChristmasMovies();
            assert.equal(newM.buyMovie('a', ['x', 'y', 'x']), `You just got a to your collection in which x, y are taking part!`)
        })
    })

    describe('discardMovie', () => {
        it('Should throw an Error if the movies aint in our collection', () => {
            assert.throw(() => movie.discardMovie('Go'), Error, 'Go is not at your collection!')
            assert.throw(() => movie.discardMovie(''), Error, ' is not at your collection!')
        })
        it('Should throw an Error if the movies is not watched', () => {
            movie.buyMovie('Go', 'x');
            assert.throw(() => movie.discardMovie('Go'), Error, 'Go is not watched!');
        })
        it('Should work correctly if movie exists and has benn watched', () => {
            movie.buyMovie('Go', 'x')
            movie.watchMovie('Go')
            assert.deepEqual(movie.discardMovie('Go'), 'You just threw away Go!')
        })
    })

    describe('watchMovie', () => {
        it('Should throw an Error if movie does not exist in our collection', () => {
            assert.throw(() => movie.watchMovie('x'), Error, 'No such movie in your collection!')
        })
        it('should increment watch count correctly', () => {
            movie.buyMovie('Go')
            movie.watchMovie('Go')
            assert.equal(movie.watched['Go'], 1)

            movie.watchMovie('Go')
            assert.equal(movie.watched['Go'], 2)
        });
    })

    describe('favouriteMovie', () => {
        it('Should work correctly', () => {
            movie.buyMovie('Go')
            movie.buyMovie('No')
            movie.watchMovie('No')
            assert.equal(movie.favouriteMovie(), 'Your favourite movie is No and you have watched it 1 times!')
            movie.watchMovie('No')
            movie.watchMovie('Go')
            assert.equal(movie.favouriteMovie(), 'Your favourite movie is No and you have watched it 2 times!')
        })
        it('Should throw an Error if no movies have been watched', () => {
            assert.throw(() => movie.favouriteMovie('X'), Error, 'You have not watched a movie yet this year')
        })
    })

    describe('mostStarredActor', () => {
        it('Should work correctly', () => {
            movie.buyMovie('Go', "X")
            assert.equal(movie.mostStarredActor(), 'The most starred actor is X and starred in 1 movies!')
            movie.buyMovie('No', "X")
            assert.equal(movie.mostStarredActor(), 'The most starred actor is X and starred in 2 movies!')
        });
        it('Should throw na Error if no movies have been watched yet', () => {
            assert.throws(() => movie.mostStarredActor(), Error, 'You have not watched a movie yet this year!')
        })
    })
})