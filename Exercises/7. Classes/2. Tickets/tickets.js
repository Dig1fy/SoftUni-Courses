function ticket(arr, str) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    let unsortedTickets = [];

    for (const ticket of arr) {
        let [destination, price, status] = ticket.split('|');
        unsortedTickets.push(new Ticket(destination, Number(price), status))
    }

    let sortedTickets = [];

    switch (str) {
        case 'destination':
            sortedTickets = unsortedTickets.sort((a, b) => a.destination.localeCompare(b.destination));
            break;
        case 'price':
            sortedTickets = unsortedTickets.sort((a, b) => a.price - b.price);
            break;
        case 'status':
            sortedTickets = unsortedTickets.sort((a, b) => a.status.localeCompare(b.status));
            break;
    }

    return sortedTickets;
}