function greatestCommonDivisor(a,b){
    let copyA = a;
    let copyB = b;

    while (copyB !==0) {
        // let tempMod = copyA % copyB;
        // copyA = copyB;
        // copyB = tempMod;

        [copyA, copyB] = [copyB, copyA % copyB];
    }

    return copyA;
}