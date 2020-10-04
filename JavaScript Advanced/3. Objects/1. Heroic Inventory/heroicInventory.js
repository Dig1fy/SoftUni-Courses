function generateJSONfromObject(arr) {
    let result = [];

    for (let i = 0; i < arr.length; i++) {
        const elements = arr[i].split(' / ');
        let object = {};
        let heroItems = [];
        
        if (elements.length > 2) {
            heroItems = elements[2].split(', ');
        }
        object = {
            name: elements[0],
            level: +elements[1],
            items: heroItems
        }
        result.push(object);
    }

    return JSON.stringify(result);
}