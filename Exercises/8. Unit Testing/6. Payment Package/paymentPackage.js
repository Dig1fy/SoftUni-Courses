describe('PaymentPackage', () => {
    describe('constructor', () => {
        it('constructor should initialize the class correctly', () => {
            let test = new PaymentPackage('pocketMoney', 500);
            assert.deepEqual(test.name, 'pocketMoney');
            assert.deepEqual(test.value, 500);
            assert.deepEqual(test.VAT, 20);
            assert.deepEqual(test.active, true);
        });
        it('constructor should initialize the class correctly', () => {
            let res = () => new PaymentPackage('pocketMoney', -500)
            assert.throw(res, 'Value must be a non-negative number');
        });
    });
    describe('name method', () => {
        it('changing name with empty string should throw error', () => {
            let test = new PaymentPackage('pocketMoney', 500);
            let res = () => test.name = "";
            assert.throw(res, 'Name must be a non-empty string');
        });
        it('changing name with non-string value should throw error', () => {
            let test = new PaymentPackage('pocketMoney', 500);
            let res = () => test.name = 5;
            assert.throw(res, 'Name must be a non-empty string');
        });
        it('changing name with proper value should work correctly', () => {
            let test = new PaymentPackage('pocketMoney', 500);
            test.name = "Muh";
            assert.deepEqual(test._name, 'Muh');
        });
    });
    describe('value method', () => {
        it('changing value with non-number value should throw an error', () => {
            let test = new PaymentPackage('pocketMoney', 500);
            let res = () => test.value = "5";
            assert.throw(res, 'Value must be a non-negative number');
        });
        it('changing value with negative number should throw an error', () => {
            let test = new PaymentPackage('pocketMoney', 500);
            let res = () => test.value = -5;
            assert.throw(res, 'Value must be a non-negative number');
        });
        it('Value should work correctly with proper param', () => {
            let test = new PaymentPackage('pocketMoney', 500);
            test.value = 2.5;
            assert.deepEqual(test._value, 2.5);
        });
        it('Value should work correctly with proper param', () => {
            let test = new PaymentPackage('pocketMoney', 500);
            test.value = 0;
            assert.deepEqual(test._value, 0);
        });
    });
    describe('VAT method', () => {
        it('changing VAT with non-number value should throw an error', () => {
            let test = new PaymentPackage('pocketMoney', 500);
            let res = () => test.VAT = "5";
            assert.throw(res, 'VAT must be a non-negative number');
        });
        it('changing VAT with negative number should throw an error', () => {
            let test = new PaymentPackage('pocketMoney', 500);
            let res = () => test.VAT = -5;
            assert.throw(res, 'VAT must be a non-negative number');
        });
        it('changing VAT with proper value should work correctly', () => {
            let test = new PaymentPackage('pocketMoney', 500);
            assert.deepEqual(test._VAT, 20);
            test.VAT = 2.5;
            assert.deepEqual(test._VAT, 2.5);
            test.VAT = 0;
            assert.deepEqual(test._VAT, 0);
        });
    });
    describe('active method', () => {
        it('changing "active" with non-boolean value should throw an error', () => {
            let test = new PaymentPackage('pocketMoney', 500);
            let res = () => test.active = "5";
            assert.throw(res, 'Active status must be a boolean');
        });
        it('changing "active" with proper value should work correctly', () => {
            let test = new PaymentPackage('pocketMoney', 500);
            assert.deepEqual(test._active, true);
            test.active = false;
            assert.deepEqual(test._active, false);
        });
    });
    describe('toString method', () => {
        it('should return correct data', () => {
            let est = new PaymentPackage('HR Services', 1500);
            let test = est.toString();
            const output = [
                `Package: ${est._name}` + (est._active === false ? ' (inactive)' : ''),
                `- Value (excl. VAT): ${est._value}`,
                `- Value (VAT ${est._VAT}%): ${est._value * (1 + est._VAT / 100)}`
            ].join('\n');
            assert.deepEqual(test, output);
        });
        it('should append "inactive" if "active" is false', () => {
            let est = new PaymentPackage('HR Services', 1500);
            est.active = false;
            let test = est.toString();
            const output = [
                `Package: ${est._name}` + (est._active === false ? ' (inactive)' : ''),
                `- Value (excl. VAT): ${est._value}`,
                `- Value (VAT ${est._VAT}%): ${est._value * (1 + est._VAT / 100)}`
            ].join('\n');
            assert.deepEqual(test, output);
        });
    });
});