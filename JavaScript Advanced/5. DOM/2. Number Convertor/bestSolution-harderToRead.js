function solve() {

    let optionList = document.querySelectorAll("#selectMenuTo")[0];
    let button = document.querySelector("button");
    let input = document.querySelector("#input");

    let obj = {
        binary: (number)=> number.toString(2),
        hexadecimal: (number) => Number(number).toString(16).toUpperCase()
    }
    optionList.innerHTML = `
<option selected value=""></option>
<option value="hexadecimal">Hexadecimal</option>
<option value="binary">Binary</option>
`
    button.addEventListener('click', () => {
        document.getElementById("result").value = obj[optionList.value](Number(input.value));
        optionList.value = '';
    })
}