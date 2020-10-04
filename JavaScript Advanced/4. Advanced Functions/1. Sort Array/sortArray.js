function sortArray(arr, argument) {
    return argument === 'asc' 
    ? arr.sort((a, b) => a - b) 
    : arr.sort((a, b) => b - a);
}