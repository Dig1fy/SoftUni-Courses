class CheckingAccount {
    constructor(clientId, email, firstName, lastName) {
        this.clientId = clientId;
        this.email = email;
        this.firstName = firstName;
        this.lastName = lastName;
    }

    get clientId() {
        return this._clientId;
    }
    set clientId(someId) {
        if (typeof someId !== 'string' || someId.length !== 6 || isNaN(someId)) {
            throw new TypeError('Client ID must be a 6-digit number');
        } else {
            this._clientId = someId;
        }
    }

    get email() {
        return this._email;
    }

    set email(mail) {
        let pattern = /^[a-zA-Z0-9]+@[a-zA-Z.]+$/g;
        let isMatch = pattern.test(mail);
        if (!isMatch) {
            throw new TypeError('Invalid e-mail');
        } else {
            this._email = mail;
        }
    }

    get firstName() {
        return this._firstName;
    }

    set firstName(input) {
        let lettersPattern = /^[a-zA-Z]+$/g;
        let isLetterMatch = lettersPattern.test(input);

        if (input.length < 3 || input.length > 20) {
            throw new TypeError('First name must be between 3 and 20 characters long')
        } else if (!isLetterMatch) {
            throw new TypeError('First name must contain only Latin characters');
        }

        this._firstName = input;
    }

    get lastName() {
        return this._lastName;
    }

    set lastName(input) {
        let lettersPattern = /^[a-zA-Z]+$/g;
        let isLetterMatch = lettersPattern.test(input);

        if (input.length < 3 || input.length > 20) {
            throw new TypeError('Last name must be between 3 and 20 characters long')
        } else if (!isLetterMatch) {
            throw new TypeError('Last name must contain only Latin characters');
        }

        this._lastName = input;
    }
}