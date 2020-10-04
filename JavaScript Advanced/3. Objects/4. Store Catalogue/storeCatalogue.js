function compare(arrInput) {
    let arr = arrInput.map(x => x.split(' : ').join(': ')).sort((a, b) => a.localeCompare(b));

    let result = {};
    arr.forEach(currentValue => {
        let kvp = currentValue.split(' : ');

        if (result[kvp[0][0]] === undefined) {
            result[kvp[0][0]] = [currentValue];

        } else {
            result[kvp[0][0]].push(currentValue);
        }
    });

    let output = '';

    for (const key in result) {
        output += key + '\n';
        result[key].forEach(el => {
            output += `  ${el}\n`;
        });
    }

    return output;

}