//Write a function that checks if the element at given position in given
//array of integers is bigger than its two neighbours (when such exist).

var input = [24, 4, -132, 3, 1, 420, -6, 4, 2, 17, 12, 6, 3, -1, 4,
    6, 1, 5, 3, 8, 7, 2, 9, -4, -3, 14, -11, 409, 5, 8, 55],
    targetPos = 7;

largerNeighborsTest(input, targetPos);
largerNeighborsTest(input, -1);

function largerNeighbors(arr, pos) {
    var len = arr.length;

    if (pos >= len || pos < 0) {
        return -1;
    }

    if (pos < len-1 && pos != 0) {
        if (arr[pos] > arr[pos-1] && arr[pos] > arr[pos+1]) {
            return 1;
        } else {
            return 0;
        }
    }
}

function largerNeighborsTest(input, targetPos) {
    var result = largerNeighbors(input, targetPos);
    if (result === 1) {
        console.log('The number ' + input[targetPos] + ' at position ' + targetPos + ' is larger than its neighbors!');
    } else if (result === 0) {
        console.log('The number ' + input[targetPos] + ' at position ' + targetPos + ' isn\'t larger than both its neighbors');
    } else {
        console.log('Number has no TWO neighboring elements or doesn\'t exist at all');
    }
}