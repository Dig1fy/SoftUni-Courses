function solve(arr) {

    let biggestNumber = Number.MIN_SAFE_INTEGER;
    let result = [];

    for (let i = 0; i < arr.length; i++) {
        const currentElement = Number(arr[i]);
        if (currentElement >= biggestNumber) {
            biggestNumber = currentElement;
            result.push(biggestNumber);
        }
    }
    return result.join('\n');
}