describe('lookUpChar', () => {
    it('should return undefined with non-string first param and/or non-number second param', () => {
        assert.equal(lookupChar('2', 0), '2', 'string / number => correct answer');
        assert.equal(lookupChar('2', Object), undefined, 'string / object => undefined');
        assert.equal(lookupChar('222', '2'), undefined, 'string/string => undefined');
        assert.equal(lookupChar('2', true), undefined, 'string / boolean => undefined');
        assert.equal(lookupChar(Object, 2), undefined, 'object/number => undefined');
        assert.equal(lookupChar(Object, '2'), undefined, 'object/string => undefined');
        assert.equal(lookupChar(Object, true), undefined, 'object/boolean => undefined');
        assert.equal(lookupChar(true, 2), undefined, 'boolean/number => undefined');
        assert.equal(lookupChar('222', 2.5), undefined, 'string/floating number => undefined');
        assert.equal(lookupChar(true, '2'), undefined, 'boolean/string => undefined');
        assert.equal(lookupChar(true, true), undefined, 'boolean/boolean => undefined');
        assert.equal(lookupChar(true, Object), undefined, 'boolean/object => undefined');
        assert.equal(lookupChar(222, '2'), undefined, 'number/string => undefined');
        assert.equal(lookupChar(22.2, true), undefined, 'floating number/boolean => undefined');
        assert.equal(lookupChar(222, Object), undefined, 'number/object => undefined');
        assert.equal(lookupChar(222, 2), undefined, 'number/number => undefined');
    });
    it('should return "Incorrect index" if index < array.length', () => {
        assert.equal(lookupChar('111', -1), 'Incorrect index');
    });
    it('should return "Incorrect index" if index < array.length', () => {
        assert.equal(lookupChar('111', 3), 'Incorrect index');
        assert.equal(lookupChar("", 2), "Incorrect index");
        assert.equal(lookupChar('111', 111), 'Incorrect index');
    });
    it('Correct input should return correct answers', () => {
        assert.equal(lookupChar('Gaga', 2), 'g', 'correct answer');
        assert.equal(lookupChar('Ooo', 0), 'O', 'correct answer');
        assert.equal(lookupChar('111', 1), '1', 'correct answer');
    });
})