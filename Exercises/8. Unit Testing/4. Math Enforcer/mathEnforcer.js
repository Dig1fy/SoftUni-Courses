describe('mathEnforcer', () => {
    it('addFive method', () => {
        assert.equal(mathEnforcer.addFive(5.5), 10.5, 'floating number should work properly');
        assert.equal(mathEnforcer.addFive(5), 10, 'should add 5 correctly');
        assert.equal(mathEnforcer.addFive(-5), 0, 'should work with negative param correctly');
        assert.equal(mathEnforcer.addFive('5'), undefined, 'string param should return undefined');
    });
    it('substractTen method', () => {
        assert.equal(mathEnforcer.subtractTen(5.5), -4.5, 'floating number should work properly');
        assert.equal(mathEnforcer.subtractTen(-5), -15, 'should subtract negative param correctly');
        assert.equal(mathEnforcer.subtractTen(0), -10, 'should subtract 10 correctly');
        assert.equal(mathEnforcer.subtractTen('5'), undefined, 'string param should return undefined');
    });
    it('sum method', () => {
        assert.equal(mathEnforcer.sum(5.5, 4.5), 10, 'floating number should work properly');
        assert.equal(mathEnforcer.sum(1, 0), 1, 'real number should work properly');
        assert.equal(mathEnforcer.sum(-1, -10), -11, 'negative params should work properly');
        assert.equal(mathEnforcer.sum('5.5', 4.5), undefined, 'non Number first param should return undefined');
        assert.equal(mathEnforcer.sum(5.5, '4.5'), undefined, 'non Number second param should return undefined');
    });

})