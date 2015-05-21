//Write a script that finds the index of given element in a sorted
// array of integers by using the binary search algorithm.

var input = [24, 4, -132, 3, 1, 420, -6, 4, 2, 17, 12, 6, 3, -1, 4,
    6, 1, 5, 3, 8, 7, 2, 9, -4, -3, 14, -11, 409, 5, 8, 55],
    target = 9;

binarySearch(input, target);

function binarySearch(arr, key) {
    var len = arr.length,
        iMax = len - 1,
        iMin = 0,
        iMid = len / 2,
        keyFound = false;

    arr.sort(function(a, b) {
        return a - b;
    });

    while(iMax >= iMin) {
        iMid = ((iMin + iMax) / 2) | 0;
        if (arr[iMid] == key)
        {
            console.log('Target = ' + key + ' found at index ' + iMid);
            keyFound = true;
            break;
        }
        else if (arr[iMid] < key)
        {
            iMin = iMid + 1;
        }
        else
        {
            iMax = iMid - 1;
        }
    }

    if (!keyFound)
    {
        console.log('Target = ' + key + ' not found! Lo siento mucho, se?or!');
    }


}