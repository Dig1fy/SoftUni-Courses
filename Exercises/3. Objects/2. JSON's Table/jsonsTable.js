function getHtmlTable(input) {
    let inputArr = input.map(x => JSON.parse(x));

    let createData = content => `<td>${content}</td>`;
    let result = '<table>\n';

    for (let row = 0; row < inputArr.length; row++) {
        result += ` <tr>\n`

        for (const el of Object.values(inputArr[row])) {
            result += `     ${createData(el)}\n`;
        }
        result += ` </tr>\n`;
    }

    result += ' </table>'
    return result;
}