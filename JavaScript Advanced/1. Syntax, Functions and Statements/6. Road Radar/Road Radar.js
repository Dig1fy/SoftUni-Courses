function speedLimit(arr) {

    let area = arr[1];
    let speed = Number(arr[0]);
    let limits = {
        motorway: 130,
        interstate: 90,
        city: 50,
        residential: 20
    }

    let result = determineTheOutput(area, limits, speed);

    if (result != null) {
        return result;
    } else {
        return
    }

    function determineTheOutput(area, limits) {
        let output = '';
        let allowedSpeed = limits[area];

        let speedDifference = speed - allowedSpeed;
        if (speedDifference <= 0) {
            return;
        }
        if (speedDifference <= 20) {
            output = 'speeding';
        } else if (speedDifference > 20 && speedDifference <= 40) {
            output = 'excessive speeding';
        } else {
            output = 'reckless driving';
        }

        return output;
    }
}