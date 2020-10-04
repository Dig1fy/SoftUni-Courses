class Stringer {
    constructor(string, length) {
        this.innerString = string;
        this.innerLength = Number(length);
    }

    increase(length) {
        this.innerLength += Number(length);
    }

    decrease(length) {
        this.innerLength -= Number(length);
        if (this.innerLength < 0) {
            this.innerLength = 0;
        }
    }

    toString() {
        if (this.innerLength === 0) {
            return '...'
        } else if (this.innerString.length > this.innerLength) {
            return (this.innerString.substr(0, this.innerLength) + '...');
        }
    }
}