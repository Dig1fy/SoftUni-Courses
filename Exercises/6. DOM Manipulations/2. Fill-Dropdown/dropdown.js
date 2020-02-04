function addItem() {
    let elements = {
        itemText: document.querySelector('#newItemText'),
        itemValue: document.querySelector('#newItemValue'),
        optionMenu: document.querySelector('#menu')
    }

    let option = document.createElement('option');
    option.textContent = elements.itemText.value;
    option.value = elements.itemValue.value;

    elements.optionMenu.appendChild(option);
    elements.itemText.value = '';
    elements.itemValue.value = '';
}
