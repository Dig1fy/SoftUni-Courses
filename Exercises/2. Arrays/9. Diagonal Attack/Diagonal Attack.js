function diagonalAttack(matrix) {
    matrix = matrix.map(x => x.split(' ').map(Number));
    let mainDiagonal = 0;
    let secondDiagonal = 0;

    for (let row = 0; row < matrix.length; row++) {
        mainDiagonal += matrix[row][row];
        secondDiagonal += matrix[row][matrix.length - row - 1];
    }

    if (mainDiagonal !== secondDiagonal) {
        return printTheMatrix(matrix);
    } else {
        for (let row = 0; row < matrix.length; row++) {
            for (let col = 0; col < matrix.length; col++) {
                if (row !== col && row !== matrix.length - col - 1) {
                    matrix[row][col] = mainDiagonal;
                }
            }
        }

        return printTheMatrix(matrix);
    }

    function printTheMatrix(matrix) {
        return matrix
            .map(row => row.join(' '))
            .join('\n');
    }
}