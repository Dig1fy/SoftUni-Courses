describe('Odd or even', () => {
    it('should return undefined with params different than string', () => {
        assert.equal(isOddOrEven(2), undefined, 'number');
        assert.equal(isOddOrEven(Object), undefined, 'object');
        assert.equal(isOddOrEven(true), undefined, 'boolean');
    });
    it('should return EVEN if string length is even', () => {
        assert.equal(isOddOrEven('test'), 'even', '"test" should be even');
    });
    it('should return ODD if string length is odd', () => {
        assert.equal(isOddOrEven('tests'), 'odd', '"tests" should be odd');
    });
})