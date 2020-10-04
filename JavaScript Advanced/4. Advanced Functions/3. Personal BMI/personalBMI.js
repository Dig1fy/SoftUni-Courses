function getBMIStatus(...args) {
    let [name, age, weight, height] = args;

    let person = {
        name,
        personalInfo: {
            age: age,
            weight: weight,
            height: height
        }
    };
    let BMI = Math.round(weight / ((height / 100) ** 2));


    let status = BMI < 18.5
        ? 'underweight' : BMI < 25
            ? 'normal' : BMI < 30
                ? 'overweight' : 'obese';

    person.BMI = BMI;
    person.status = status;

    if (status === 'obese') {
        person.recommendation = 'admission required';
    }
    
    return person;
}