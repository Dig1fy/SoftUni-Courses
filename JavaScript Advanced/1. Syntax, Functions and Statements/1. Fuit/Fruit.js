function solve(fruit, weight, price) {

    weight /= 1000;
    let neededMoney = weight * price;

    console.log(`I need $${neededMoney.toFixed(2)} to buy ${weight.toFixed(2)} kilograms ${fruit}.`);
}