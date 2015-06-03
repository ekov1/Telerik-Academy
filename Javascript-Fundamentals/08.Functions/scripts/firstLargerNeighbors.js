//Write a function that returns the index of the first element in
//array that is larger than its neighbours or -1, if there’s no such element.

var input = [24, 4, -132, 3, 1, 420, -6, 4, 2, 17, 12, 6, 3, -1, 4,
    6, 1, 5, 3, 8, 7, 2, 9, -4, -3, 14, -11, 409, 5, 8, 55],
    pos;

firstLargerNeighborsTest(input);
firstLargerNeighborsTest([-1, 2, 1, 2, 3, 4, 5]);

function firstLargerNeighbors(arr) {
    var i,
        len = arr.length;

    pos = 0;

    for (i = 1; i < len-1; i += 1) {
        if (arr[i] > arr[i-1] && arr[i] > arr[i+1]) {
            pos = i;
            return 1;
        }
    }
    return -1;
}

function firstLargerNeighborsTest(arr) {
    var result = firstLargerNeighbors(arr);

    if (result) {
        console.log('The element at index ' + pos + ' is the first number larger than its neighbors in the array.');
    } else {
        console.log('No element larger than both its neighbors was found!');
    }
}