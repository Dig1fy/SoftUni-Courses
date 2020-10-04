function areMatrixDiagonalsEqual(arr) {

    let desiredSum = arr[0].reduce((a, b) => +a + +b);

    for (let row = 0; row < arr.length; row++) {
        let rowSum = 0;
        let colSum = 0;

        for (let col = 0; col < arr.length; col++) {
            rowSum += +arr[row][col];
            colSum += +arr[col][row];
        }

        if (rowSum !== desiredSum || colSum !== desiredSum) {
            return false;
        }
    }

    return true;
}