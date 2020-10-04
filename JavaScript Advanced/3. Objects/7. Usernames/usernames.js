function solve(input) {
    let sorted = [...new Set(input)]
    .sort((a, b) => a.length - b.length || a.localeCompare(b));
    
    return sorted.join('\n');
}