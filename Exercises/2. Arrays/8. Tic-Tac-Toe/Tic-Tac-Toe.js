function ticTacToe(arr) {            //90 out of 100... for some reason

    const matrixFunction = () => Array.from(Array(3), () => new Array(3).fill(false));
    const matrix = matrixFunction();
    let player = 'X';
    let result = '';
    let swapPlayers = (x) => (x === 'X') ? 'O' : 'X'; //switching between 'X'(first) and 'O'(second) players

    for (let i = 0; i < arr.length; i++) {
        let row = +arr[i].split(' ')[0];
        let col = +arr[i].split(' ')[1];

        if (matrix[row][col] !== false && matrix.some(row => row.some(x => x === false))) {
            result += "This place is already taken. Please choose another!" + '\n';
            continue;
        } else if (matrix[row][col] === false) {
            matrix[row][col] = player;
            if (checkForWinner(matrix, player)) {
                result += `Player ${player} wins!` + '\n';
                break;
            }
        } else if (matrix.every(x => x !== false)) {
            result += "The game ended! Nobody wins :(" + '\n';
            break;
        }

        player = swapPlayers(player);
    }

    result += matrix.map(row => row.join('\t')).join('\n');
    return result;

    function checkForWinner(matrix, player) {
        for (let row = 0; row < matrix.length; row++) {
            let rowCount = '';
            let colCount = '';
            let firstDiagonalCount = '';
            let secondDiagonalCount = '';

            for (let col = 0; col < matrix.length; col++) {
                rowCount += (matrix[row][col]);
                colCount += (matrix[col][row]);
                firstDiagonalCount += (matrix[col][col]);
                secondDiagonalCount += (matrix[col][matrix.length - col - 1]);
            }
            if (rowCount === player.repeat(3) ||
                colCount === player.repeat(3) ||
                firstDiagonalCount === player.repeat(3) ||
                secondDiagonalCount === player.repeat(3)) {
                return true;
            }
        }
        
        return false;
    }
}