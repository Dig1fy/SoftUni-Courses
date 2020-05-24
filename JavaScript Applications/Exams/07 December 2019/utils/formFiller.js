export default function fillFormWithData(formRef, formValue) {
    if (!formValue) {
        return;
    }

    Object.entries(formValue).map(([inputName, value]) => {
        if (!formRef.elements.namedItem(inputName)) {
            return;
        }
       console.log(inputName + " " + value);
        formRef.elements.namedItem(inputName).value = value;
    });
}