let Console = require('./solution').Console;
let assert = require('chai').assert;

describe('Console', () => {

    it('single string input should return the same string', () => {
        assert.equal(Console.writeLine('xx'), 'xx')
    })
    it('object should return stringified object', () => {
        let obj = {name: "GOSHO", age: 100};
        let expected = JSON.stringify(obj);
        assert.deepEqual(Console.writeLine(obj), expected)
    })
    it('should throw an error if args[0] !== object/string', () => {
        assert.throw((()=>Console.writeLine(1,2,3)), TypeError, 'No string format given!')
    })
    it('empty args should throw an error', () => {
        assert.throw((()=>Console.writeLine()), TypeError)
    })
    it('throw an eror if arguments > placeholders', () => {
        let str = 'This {0} should {1} incorrect'
        assert.throw(()=>Console.writeLine(str,"one", "be", "what"), RangeError, 'Incorrect amount of parameters given!')
    })
    it('incorrect placeholders should throw an error', ()=>{
        let str = 'This {0} should {0} incorrect'
        assert.throw(()=>Console.writeLine(str,"one", "be"), RangeError, 'Incorrect placeholders given!')
    })
    it('', ()=>{
        let str = 'This {0} should {1} incorrect';
        assert.equal(Console.writeLine(str,"one", "be"), 'This one should be incorrect' )
    })
    it("should recognize the placeholder numbers well", function () {
        assert.throw(() => Console.writeLine("Not {10}", "valid"), RangeError);
    });
})