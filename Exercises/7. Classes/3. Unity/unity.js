class Rat {
    rats = [];
    constructor(name) {
        this.name = name;
    }

    toString() {
        let string = `${this.name}\n`;
        for (let rat of this.rats) {
            string += `##${rat.name}\n`;
        }

        return string;
    }

    unite(couldBeRat) {
        if (couldBeRat instanceof Rat) {
            this.rats.push(couldBeRat);
        }
    }

    getRats() {
        return this.rats;
    }
}