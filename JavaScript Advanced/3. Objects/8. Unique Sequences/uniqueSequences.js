function printUniqueArrays(params) {
    let unique = new Map();

    for (const row of params) {
        let arr = JSON.parse(row).sort((a, b) => b - a);
        let stringified = `[${arr.join(', ')}]`;
        unique.set(stringified, arr.length);
    }

    let result = [...unique]
        .sort((a, b) => a[1] - b[1])
        .map(kvp => kvp[0])
        .join('\n');

    console.log(result);
}