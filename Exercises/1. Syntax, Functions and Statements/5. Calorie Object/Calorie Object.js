function calories(input) {
    let result = {};

    for (let i = 0; i < input.length; i += 2) {
        result[input[i]] = Number(input[i + 1]);
    }

    return result;
}