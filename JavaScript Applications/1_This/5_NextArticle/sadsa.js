function solve(input) {
    let actions = {
        add: (a, params) => [...a, params],
        remove: (a, params) => a.filter(x => x !== params),
        print: (a, _) => {
            console.log(a.join(','))
            return a;
        }
    }

    let arr = [];
    return input
        .map(x => x.split(' '))
        .forEach(([command, params]) => {
           arr = actions[command](arr, params);
        })

    //reduce((arr, [command, params]) => actions[command](arr, params), [])  works too. Remove arr == + arr = []
}
// solve(['add hello', 'add again', 'remove hello', 'add again', 'print'])
// solve(['add pesho', 'add george', 'add peter', 'remove peter', 'print'])
// solve(['add JSFundamentals', 'print', 'add JSAdvanced', 'print', 'add JSApplications', 'print']);