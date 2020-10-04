function spiralMatrix(rows, cols) {

    let [count, maxCount, minRow, minCol, maxRow, maxCol] = [0, rows * cols, 0, 0, rows - 1, cols - 1];
    let matrix = [];

    for (let r = 0; r < rows; r++) {
        matrix[r] = [];
    }

    while (count < maxCount) {
        //--> right
        for (let col = minCol; col <= maxCol && count < maxCount; col++) {
            matrix[minRow][col] = ++count;
        }
        minRow++;
        //-->down
        for (let row = minRow; row <= maxRow && count < maxCount; row++) {
            matrix[row][maxCol] = ++count;
        }
        maxCol--;
        //-->left
        for (let col = maxCol; col >= minCol && count < maxCount; col--) {
            matrix[maxRow][col] = ++count;
        }
        maxRow--;
        //-->up
        for (let row = maxRow; row >= minRow && count < maxCount; row--) {
            matrix[row][minCol] = ++count;
        }

        minCol++;
    }

    return matrix.map(row => row.join(' ')).join('\n');
}