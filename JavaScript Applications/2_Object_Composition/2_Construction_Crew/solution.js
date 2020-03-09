function solution(worker) {
    // let currentWorker = Object.assign({}, worker);
    let currentWorker = ({}, { ...worker });
    if (currentWorker.dizziness) {
        currentWorker.levelOfHydrated += 0.1 * currentWorker.weight * currentWorker.experience;

        currentWorker.dizziness = false;
    }
    console.log(currentWorker);
}
solution({
    weight: 120,
  experience: 20,
  levelOfHydrated: 200,
  dizziness: true 

})