//Write a script that finds the maximal increasing sequence in an array.

var input = [3, 2, 4, 1, 3, 4, 5, 77, 2, 2, 4];

maxIncreasingSequence(input);

function maxIncreasingSequence(arr) {
    var elementPos = 0,
        count = 1,
        bestCount = 0;

    for (var i = 0; i < arr.length-1; i+=1) {

        if(arr[i] < arr[i+1]) {
            count++;
        } else {
            count = 1;
        }

        if(count > bestCount) {
            bestCount = count;
            elementPos = i+2;
        }

    }

    var result = [];

    for (i = bestCount; i > 0; i -= 1) {
        result.push(arr[elementPos-i]);
    }
    console.log('Longest increasing sequence of numbers is: ' + result.join(', '));
}
