(function () {
    Array.prototype.last = function () {
        return this[this.length - 1];
    }

    Array.prototype.skip = function (n) {
        return this.slice(n)
    }

    Array.prototype.take = function (n) {
        return this.slice(0, n);
    }

    Array.prototype.sum = function () {
        return this.reduce((a, b) => a + b);
    }

    Array.prototype.average = function () {
        return this.reduce((a, b) => a + b) / this.length
    }
}())

// let x = [1, 2, 3, 4];
// console.log(x.last());
// console.log(x.skip(2));
// console.log(x.take(2));
// console.log(x.sum());
// console.log(x.average());