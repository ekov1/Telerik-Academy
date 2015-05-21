//Sorting an array means to arrange its elements in increasing order.
//Write a script to sort an array.
//Use the selection sort algorithm: Find the smallest element, move it at the first position,
//find the smallest from the rest, move it at the second position, etc.

var len = arr.length,
    sortedArr = [],
    crnt = 0;

function selectionSort(arr) {

    console.log(arr.join(', '));

    for (var i = 0; i < len; i+=1) {
        sort(arr);
    }

    console.log(sortedArr.join(', '));
}

function sort(arr) {
    var smallest = Number.MAX_VALUE,
    smallestElement;

    for (var j = 0; j < len; j+=1) {
        if(arr[j] == null) continue;
        if(smallest > arr[j]) {
            smallest = arr[j];
            smallestElement = j;
        }
    }

    sortedArr[crnt] = arr[smallestElement];
    crnt++;
    arr[smallestElement] = null;
}

var input = [24, 4, -132, 3, 1, 420, -6, 4, 2, 17, 12, 6];

selectionSort(input);