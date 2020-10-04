function printEveryNthElement(arr) {
    let step = arr.pop();
    let result = [];

    for (let i = 0; i < arr.length; i += Number(step)) {
        result.push(arr[i]);
    }

    return result.join('\n');
}