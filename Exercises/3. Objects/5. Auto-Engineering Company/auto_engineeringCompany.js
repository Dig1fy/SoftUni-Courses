function solve(input) {
    let dict = new Map();

    for (const row of input) {
        let [brand, model, quantity] = row.split(' | ');
        let producedCount = Number(quantity);

        if (!dict.get(brand)) {
            dict.set(brand, new Map().set(model, producedCount));
        } else if (!dict.get(brand).get(model)) {
            dict.get(brand).set(model, producedCount);
        } else {
            dict.set(brand, dict.get(brand).set(model, dict.get(brand).get(model) + producedCount));
        }
    }

    let result = [...dict]
        .map(b => b[0] + '\n' + [...b[1]]
            .map(kvp => `###${kvp[0]} -> ${kvp[1]}`)
            .join('\n'))
        .join('\n');
        
        return result;
}