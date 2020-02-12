describe('stringBuilder', () => {
    describe('constructor', () => {
        it('constructor', () => {
            let sb = () => new StringBuilder(5);
            assert.throw(sb, 'Argument must be string', 'should throw error msg if non string param is given')
        });
    });
    describe('append', () => {
        it('append method', () => {
            let sb = new StringBuilder('111');
            sb.append('text');
            assert.deepEqual(sb._stringArray, ['1', '1', '1', 't', 'e', 'x', 't'], 'appending string should work properly');
        });
        it('append method', () => {
            let sb = new StringBuilder('ss');
            let res = () => sb.append(5);
            assert.throw(res, 'Argument must be string', 'Should throw Error if append param is not a string');
        });
        it('append method', () => {
            let sb = new StringBuilder('ss');
            let res = () => sb.append("");
            assert.deepEqual(sb._stringArray, ['s', 's'], 'Adding empty string should work properly');
        });
    });
    describe('prepend', () => {
        it('prepend method', () => {
            let sb = new StringBuilder('111');
            sb.prepend('text');
            assert.deepEqual(sb._stringArray, ['t', 'e', 'x', 't', '1', '1', '1'], 'prepending string should work properly');
        });
        it('prepend method', () => {
            let sb = new StringBuilder('111');
            let res = () => sb.prepend(5);
            assert.throw(res, 'Argument must be string', 'Prepend of non-string should throw error')
        });
    });
    describe('insertAt', () => {
        it('insertAt method', () => {
            let sb = new StringBuilder('111');
            sb.insertAt('0', 0);
            assert.deepEqual(sb._stringArray, ['0', '1', '1', '1'], 'Inserting should work correctly');
        });
        it('insertAt method', () => {
            let sb = new StringBuilder('111');
            let res = () => sb.insertAt(0, 0);
            assert.throw(res, 'Argument must be string', 'Non-string first param should throw error');
        });
        it('insertAt method', () => {
            actualResult = new StringBuilder('11');
            actualResult.insertAt('2999', 1);
            assert.deepEqual(actualResult._stringArray[1], '2','Test if the string is inserted at index');
        });
    });
    describe('remove', () => {
        it('remove method', () => {
            let sb = new StringBuilder('111');
            sb.remove(0, 3);
            assert.deepEqual(sb._stringArray, [], 'Removing all array elements should work correctly');
        });
        it('remove method', () => {
            let sb = new StringBuilder();
            sb.remove(-1, 3);
            assert.deepEqual(sb._stringArray, [], 'Removing elements from empty array should work correctly');
        });
        it('remove method', () => {
            let sb = new StringBuilder('1');
            sb.remove(0, 0);
            assert.deepEqual(sb._stringArray, ['1'], 'Removing 0 elements should work correctly');
        });
    });
    describe('toString', () => {
        it('toString method', () => {
            let sb = new StringBuilder('111');
            assert.deepEqual(sb._stringArray, ['1', '1', '1']);
        });

    });
    describe('verifyParam', () => {
        it('verifyParam private method', () => {
            let sb = new StringBuilder('111');
            sb._ve
            assert.deepEqual(sb._stringArray, ['1', '1', '1']);
        });
    });
    describe('Type of StringBuilder', function () {
        it('should have the correct function properties', function () {
            assert.isFunction(StringBuilder.prototype.append);
            assert.isFunction(StringBuilder.prototype.prepend);
            assert.isFunction(StringBuilder.prototype.insertAt);
            assert.isFunction(StringBuilder.prototype.remove);
            assert.isFunction(StringBuilder.prototype.toString);
        });
        it('toString', () => {
            let xx = new StringBuilder('123');
            assert.deepEqual(xx.toString(), '123');
        });
    });
});