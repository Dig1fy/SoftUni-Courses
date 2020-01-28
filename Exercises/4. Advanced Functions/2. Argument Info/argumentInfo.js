function getTypesInfo(...args) {
    let kvps = {};

    for (let arg of args) {

        let type = typeof (arg);
        console.log(`${type}: ${arg}`);

        if (!kvps[type]) {
            kvps[type] = 0;
        }

        kvps[type]++;
    }

    Object.keys(kvps)
        .sort((a, b) => kvps[b] - kvps[a])
        .forEach(k => console.log(`${k} = ${kvps[k]}`))
}