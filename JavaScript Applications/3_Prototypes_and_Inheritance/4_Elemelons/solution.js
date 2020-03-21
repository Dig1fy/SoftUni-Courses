function theElemelons() {
    
    class Melon {
        constructor(weight, melonSort) {
            if (new.target === Melon) {
                throw new Error('Abstract class cannot be instantiated directly')
            }
            this.weight = weight;
            this.melonSort = melonSort;
        }

        get elementIndex() {
            return this.weight * this.melonSort.length;
        }

        toString() {
            return `Sort: ${this.melonSort}\n` + `Element Index: ${this.elementIndex}`;
        }
    }

    class Watermelon extends Melon {

        constructor(weight, melonSort) {
            super(weight, melonSort);
            this.element = 'Water';
        }

        toString() {
            return `Element: ${this.element}\n${super.toString()}`
        }
    }

    class Firemelon extends Melon {

        constructor(weight, melonSort) {
            super(weight, melonSort);
            this.element = 'Fire';
        }

        toString() {
            return `Element: ${this.element}\n${super.toString()}`
        }
    }

    class Earthmelon extends Melon {

        constructor(weight, melonSort) {
            super(weight, melonSort);
            this.element = 'Earth';
        }

        toString() {
            return `Element: ${this.element}\n${super.toString()}`
        }
    }

    class Airmelon extends Melon {

        constructor(weight, melonSort) {
            super(weight, melonSort);
            this.element = 'Air';
        }

        toString() {
            return `"Element: ${this.element}\n${super.toString()}`
        }
    }

    class Melolemonmelon extends Watermelon {
        constructor(weight, melonSort) {
            super(weight, melonSort)
        }

        morph() {
            let allElements = ['Fire', 'Earth', 'Air', 'Water'];
            let currentIndex = allElements.indexOf(this.element);
            if (currentIndex + 1 === allElements.length) {
                this.element = allElements[0];
            } else {
                this.element = allElements[currentIndex + 1]
            }
        }
    }

    return { Melon, Watermelon, Firemelon, Earthmelon, Airmelon, Melolemonmelon }
}