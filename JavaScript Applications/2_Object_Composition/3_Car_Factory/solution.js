function solution(car) {

    const engineTypes = [
        { power: 90, volume: 1800 },
        { power: 120, volume: 2400 },
        { power: 200, volume: 3500 }
    ]

    return {
        model: car.model,
        engine: engineTypes.find(x => car.power < x.power),
        carriage: {
            type: car.carriage,
            color: car.color
        },
        wheels: Array(4).fill(car.wheelsize % 2 === 0 ? car.wheelsize - 1 : car.wheelsize)
    }
}