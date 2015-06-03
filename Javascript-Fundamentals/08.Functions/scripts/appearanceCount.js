//Write a function that counts how many times given number appears in given array.
//Write a test function to check if the function is working correctly.

var input = [24, 4, -132, 3, 1, 420, -6, 4, 2, 17, 12, 6, 3, -1, 4,
    6, 1, 5, 3, 8, 7, 2, 9, -4, -3, 14, -11, 409, 5, 8, 55],
    target = 4;

appearanceCount(input, target);

function appearanceCount(arr, key) {

    var i,
        len = arr.length,
        count = 0;

    for (i = 0; i < len; i += 1) {
        if (arr[i] === key) {
            count += 1;
        }
    }

    console.log('Occurrences of the key ' + key + ': ' + count + ' times. ');
}
