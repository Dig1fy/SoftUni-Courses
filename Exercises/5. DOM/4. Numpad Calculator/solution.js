function solve() {
    let output = document.querySelector("#expressionOutput");
    let result = document.querySelector("#resultOutput");
    let clearBtn = document.querySelector('.clear');
    let pad = document.querySelectorAll('.keys')[0];
    let operators = ['+', '-', '/', '*'];

    let objOperations = {
        '+': (a, b) => Number(a) + Number(b),
        '-': (a, b) => Number(a) - Number(b),
        '*': (a, b) => Number(a) * Number(b),
        '/': (a, b) => Number(a) / Number(b)
    }

    if (output === null || result === null || clearBtn === null || pad === null) {
        throw new Error("It might hurt but.... your code just broke");
    }

    clearBtn.addEventListener('click', (clear) => {
        result.textContent = "";
        output.textContent = "";
    })

    pad.addEventListener('click', ({ target: { value } }) => {

        if (!value) {
            return
        }

        if (value === '=') {
            let params = output.innerHTML.split(' ').filter(x => x !== '');

            if (params[2] !== undefined) {
                result.innerHTML = objOperations[params[1]](params[0], params[2]);
                return;
            }

            result.innerHTML = 'NaN';
            return;
        }

        if (operators.includes(value)) {
            output.innerHTML += ` ${value} `;
            return;
        }

        output.innerHTML += value;
    })
}