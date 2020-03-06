let SoftUniFy = require('./solution');
let assert = require('chai').assert;


describe('SoftUniFy', () => {
    let x;
    beforeEach(() => {
        x = new SoftUniFy();
    })
    describe('Constructor', () => {
        it('Should initialize the class correctly', () => {
            assert.deepEqual(x.allSongs, {})
        })
    })
    describe('downloadSong', () => {
        it('Should add new artist correctly', () => {

            assert.deepEqual(x.downloadSong('G', 'I', 'Joe'), {
                allSongs: {
                    G: {
                        rate: 0,
                        songs: ['I - Joe'],
                        votes: 0
                    }
                }
            })
        })
    })
    describe('playSong', () => {
        it('Should return the correct output', () => {
            x.downloadSong('Gosho', 'I', 'Joe')
            x.downloadSong('Pesho', 'U', 'Joe')
            assert.deepEqual((x.playSong('I')), `Gosho:\nI - Joe\n`);
        })
        it('Should return a proper text if the songs is not in our system', () => {

            // let actual = x.playSong('Yo');
            let expected = `You have not downloaded a Yo song yet. Use SoftUniFy's function downloadSong() to change that!`;
            assert.equal(x.playSong('Yo'), expected);
        })
    })
    describe('songsList', () => {
        it('Should return proper text if we list is empty', () => {
            assert.equal(x.songsList, 'Your song list is empty')
        })
        it('Should return the list of songs correctly', () => {
            x.downloadSong('Gosho', 'I', 'Joe')
            assert.deepEqual(x.songsList, 'I - Joe')
        })
    })
    describe('rateArtist', () => {
        it('Should return appropriate text if the artist does not exist', () => {
            assert.equal(x.rateArtist(), 'The undefined is not on your artist list.')
        })
        it('Should rate the artist correctly', () => {

        })
        it('', () => {
            x.downloadSong('Eminem', 'I', 'Joe')
            assert.equal(x.rateArtist('Eminem'), 0)
            assert.equal(x.rateArtist('Eminem', 50), 50)
        })
    })
})