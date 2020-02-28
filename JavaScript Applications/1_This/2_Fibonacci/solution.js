function fibonacci() {

    let current = 1;
    let previous = 0;

    return function () {

        let result = previous + current;
        previous = current;
        current = result;

        return previous;
    }
}

// let x = fibonacci();
// console.log(x());
// console.log(x());
// console.log(x());
// console.log(x());
// console.log(x());
// console.log(x());
// console.log(x());
// console.log(x());