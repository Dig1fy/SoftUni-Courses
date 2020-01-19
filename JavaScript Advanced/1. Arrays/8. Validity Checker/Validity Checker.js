function validityChecker(arr) {

    let [x1, y1, x2, y2] = [Number(arr[0]), Number(arr[1]), Number(arr[2]), Number(arr[3])];

    function distance(x1, y1, x2, y2) {
        let distanceX = x1 - x2;
        let distanceY = y1 - y2;
        return Math.sqrt(Math.pow(distanceX, 2) + Math.pow(distanceY, 2));
    }

    let result = '';

    result += printResult(x1, y1, 0, 0) + '\n';
    result += printResult(x2, y2, 0, 0) + '\n';
    result += printResult(x1, y1, x2, y2);
    return result;

    function printResult(x, y, z1, z2) {
        let textPattern = `{${x}, ${y}} to {${z1}, ${z2}} is `;

        if (Number.isInteger(distance(x, y, z1, z2))) {
            return textPattern + 'valid';
        } else {
            return textPattern + 'invalid';
        }
    }
}