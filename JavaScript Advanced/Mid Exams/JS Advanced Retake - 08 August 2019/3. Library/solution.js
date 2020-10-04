class Library {

    constructor(libraryName) {
        this.libraryName = libraryName;
        this.subscribers = [];
        this.subscriptionTypes = {
            normal: this.libraryName.length,
            special: this.libraryName.length * 2,
            vip: Number.MAX_SAFE_INTEGER
        }
    }
    subscribe(name, type) {
        let desiredTypes = ['normal', 'special', 'vip'];
        let currentSubscriber;

        if (!desiredTypes.some(x => x === type)) {
            throw new Error(`The type ${type} is invalid`);
        }

        let isSubscribed = this.subscribers.some((x) => x.name === name);

        if (!isSubscribed) {
            currentSubscriber = {
                name: name,
                type: type,
                books: []
            }

            this.subscribers.push(currentSubscriber)
        } else {
            currentSubscriber = this.subscribers.filter(x => x.name === name)[0];
            currentSubscriber.type = type;
        }

        return currentSubscriber;
    }

    unsubscribe(name) {
        let isSubToRemove = this.subscribers.some(x => x.name === name);

        if (!isSubToRemove) {
            throw new Error(`There is no such subscriber as ${name}`);
        } else {
            this.subscribers = this.subscribers.filter(x => x.name !== name);
            return this.subscribers;
        }
    }

    receiveBook(subscriberName, bookTitle, bookAuthor) {
        if (!this.subscribers.some(x => x.name === subscriberName)) {
            throw new Error(`There is no such subscriber as ${subscriberName}`)
        } else {
            let currentSubscriber = this.subscribers.filter(x => x.name === subscriberName)[0];

            let subType = currentSubscriber.type;

            if ((currentSubscriber.books.length + 1) <= this.subscriptionTypes[subType]) {
                currentSubscriber.books.push({
                    title: bookTitle, author: bookAuthor
                });
            } else {
                throw new Error(`You have reached your subscription limit ${this.subscriptionTypes[currentSubscriber.type]}!`)
            }                                                            //${currentSubscriber.type}

            return currentSubscriber;
        }
    }

    showInfo() {
        let result = '';
        if (this.subscribers.length === 0) {
            return `${this.libraryName} has no information about any subscribers`
        }
        for (const person of this.subscribers) {
            result += `Subscriber: ${person.name}, Type: ${person.type}\n`;

            let allBooks = [];
            for (const e of person.books) {
                allBooks.push(`${e.title} by ${e.author}`);
            }

            result += `Received books: ${allBooks.join(', ')}\n`;
        }

        return result;
    }
}

// let lib = new Library('Lib');

// lib.subscribe('Peter', 'normal');
// lib.subscribe('John', 'vip');
// lib.subscribe('John', 'normal');
// lib.subscribe('GG', 'special');
// lib.unsubscribe('GG');

// lib.receiveBook('John', 'A Song of Ice and Fire', 'George R. R. Martin');
// lib.receiveBook('John', 'A Song of Ice and Fire', 'George R. R. Martin');
// lib.receiveBook('John', 'A Song of Ice and Fire', 'George R. R. Martin');
// lib.receiveBook('John', 'A Song of Ice and Fire', 'George R. R. Martin');
// lib.receiveBook('John', 'A Song of Ice and Fire', 'George R. R. Martin');
// lib.receiveBook('John', 'A Song of Ice and Fire', 'George R. R. Martin');

// // lib.receiveBook('John', 'A Song of Ice and Fire', 'George R. R. Martin');
// lib.receiveBook('Peter', 'Lord of the rings', 'J. R. R. Tolkien');
// lib.receiveBook('John', 'Harry Potter', 'J. K. Rowling');
// console.log(lib.showInfo());
