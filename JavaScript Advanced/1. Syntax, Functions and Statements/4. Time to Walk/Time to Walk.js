function timeToWalk(steps, stepsLength, speed) {

    let length = steps * stepsLength;
    let timeToRest = Math.floor(length / 500);
    let totalTime = length / speed / 1000 * 60;
    let resultTime = Math.ceil((totalTime + timeToRest) * 60);

    let result = new Date(null, null, null, null, null, resultTime);
    return result.toTimeString().split(' ')[0];
}