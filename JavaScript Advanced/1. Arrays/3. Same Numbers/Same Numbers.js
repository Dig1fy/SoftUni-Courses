function sameNumbers(number) {

    let numAsString = number.toString().split('');
    let first = numAsString[0];

    let sum = numAsString.reduce((a,b)=>Number(a)+Number(b));
    let areEqual = numAsString.every((a) => a === first);

    let result = '';
    result += areEqual + '\n' + sum;
    return result;
}