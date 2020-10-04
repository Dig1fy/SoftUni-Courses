function sumBottlesOfJuice(inputArr) {
    let result = {}, obj = {};

    inputArr.forEach(row => {
        let keyValuePair = row.split(' => ');

        if (obj[keyValuePair[0]] === undefined) {
            obj[keyValuePair[0]] = +keyValuePair[1];
        } else {
            obj[keyValuePair[0]] += +keyValuePair[1];
        }

        let bottleQuantity = Math.floor(+obj[keyValuePair[0]] / 1000);

        if (bottleQuantity > 0) {
            result[keyValuePair[0]] = bottleQuantity;
        }
    });

    let output = Object.entries(result);
    for (let i = 0; i < output.length; i++) {
        console.log(output[i].join(' => '));
        
    }
}