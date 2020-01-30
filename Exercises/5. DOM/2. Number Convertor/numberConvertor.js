function solve() {

    const selectMenuTo = document.getElementById("selectMenuTo");

    document.querySelector("#container > button").addEventListener("click", convert);
    let result = "";

    function convert() {
        let number = Number(document.getElementById('input').value);

        if (selectMenuTo.value === "binary") {
            result = (number.toString(2).toUpperCase());
        } else if (selectMenuTo.value === "hexadecimal") {
            result = (number.toString(16).toUpperCase());
        }

        document.getElementById("result").value = result;
        selectMenuTo.value = "";
    }

    function createSelectMenuOptions() {

        let binaryOption = document.createElement("option");
        binaryOption.textContent = "Binary";
        binaryOption.value = "binary";

        let hexaDecimalOption = document.createElement("option");
        hexaDecimalOption.textContent = "Hexadecimal";
        hexaDecimalOption.value = "hexadecimal";

        selectMenuTo.appendChild(hexaDecimalOption);
        selectMenuTo.appendChild(binaryOption);
    }

    createSelectMenuOptions();
}