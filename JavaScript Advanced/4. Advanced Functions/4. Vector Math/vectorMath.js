(() => {
    
    let add = (firstVec, secondVec) => [firstVec[0] + secondVec[0], firstVec[1] + secondVec[1]];
    let multiply = (vector, scalar) => [vector[0] * scalar, vector[1] * scalar];
    let length = (vector) => Math.sqrt(vector[0] ** 2 + vector[1] ** 2);
    let dot = (firstVect, secondVec) => (firstVect[0] * secondVec[0] + firstVect[1] * secondVec[1]);
    let cross = (firstVec, secondVec) => (firstVec[0] * secondVec[1] - firstVec[1] * secondVec[0]);

    return {
        add,
        multiply,
        length,
        dot,
        cross
    }
})()