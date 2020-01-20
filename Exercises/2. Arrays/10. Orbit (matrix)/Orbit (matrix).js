function solveTheMatrix(arr) {
    let rows = arr[0];
    let cols = arr[1];
    let rowInitial = arr[2];
    let colInitial = arr[3];

    const funcMatrix = () =>
        Array.from(Array(rows), () => new Array(cols));
    let matrix = funcMatrix();
    matrix[rowInitial][colInitial] = 1;

    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix.length; col++) {
            matrix[row][col] = Math.max(Math.abs(rowInitial - row), Math.abs(colInitial - col)) + 1;
        }
    }

    return matrix.map(x=>x.join(' ')).join('\n');
}