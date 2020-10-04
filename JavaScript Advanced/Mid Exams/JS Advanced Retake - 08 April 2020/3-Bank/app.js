class Bank {
    _bankName;

    constructor(bankName) {
        this._bankName = bankName;
        this.allCustomers = []
    }

    newCustomer(customer) {
        let firstName = customer.firstName;
        let lastName = customer.lastName;
        let personalId = customer.personalId;

        if (this.allCustomers.find(x => x.personalId === customer.personalId)) {
            throw new Error(`${firstName} ${lastName} is already our customer!`)
        }

        let newCustomer = {
            firstName: firstName,
            lastName: lastName,
            personalId: personalId,
            totalMoney: 0,
            transactions: []
        }
        this.allCustomers.push(newCustomer);
        return customer;
    }

    depositMoney(personalId, amount) {
        let customer = this.allCustomers.find(x => x.personalId === personalId)
        if (!customer) {
            throw new Error("We have no customer with this ID!")
        }

        customer.totalMoney += Number(amount)

        let transactionId = customer.transactions.length + 1;
        let transaction = `${transactionId}. ${customer.firstName} ${customer.lastName} made deposit of ${amount}$!`
        customer.transactions.unshift(transaction);
        return `${customer.totalMoney}$`;
    }

    withdrawMoney(personalId, amount) {
        let customer = this.allCustomers.find(x => x.personalId === personalId)

        if (!customer) {
            throw new Error("We have no customer with this ID!")
        }

        if (customer.totalMoney < Number(amount)) {
            throw new Error(`${customer.firstName} ${customer.lastName} does not have enough money to withdraw that amount!`)
        }
        
        let transactionId = customer.transactions.length + 1;
        let transaction = `${transactionId}. ${customer.firstName} ${customer.lastName} withdrew ${amount}$!`
        customer.transactions.unshift(transaction);

        customer.totalMoney -= Number(amount);

        return `${customer.totalMoney}$`
    }

    customerInfo(personalId) {
        let customer = this.allCustomers.find(x => x.personalId === personalId)

        if (!customer) {
            throw new Error("We have no customer with this ID!")
        }

        let result = `Bank name: ${this._bankName}\nCustomer name: ${customer.firstName} ${customer.lastName}\nCustomer ID: ${customer.personalId}\nTotal Money: ${customer.totalMoney}$\nTransactions:\n${customer.transactions.join('\n')}`;

        return result;
    }
}
