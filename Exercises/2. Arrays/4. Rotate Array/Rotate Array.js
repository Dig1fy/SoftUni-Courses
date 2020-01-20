function rotateArray(arr) {

    let rotations = (Number(arr.pop()) % arr.length) + arr.length;

    for (let i = 0; i < rotations; i++) {
        arr.splice(0, 0, arr[arr.length - 1]);
        arr.splice(arr.length - 1, 1);
    }
    return arr.join(' ');
}