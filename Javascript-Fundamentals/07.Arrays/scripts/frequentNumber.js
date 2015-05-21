//Write a script that finds the most frequent number in an array.


var input = [4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3];

mostFrequentNumber(input);

function mostFrequentNumber(arr) {
    var currentFreq = 0,
        largestFreq = 0,
        num = 0,
        mostPopularNum = 0,
        len = arr.length;

    arr.sort(function(a, b) {
        return a - b;
    });

    for (var i = 0; i < len-1; i += 1) {
        if (num == arr[i] || i == 0) {
            num = arr[i];
            ++currentFreq;
        }

        if (currentFreq > largestFreq) {
            largestFreq = currentFreq;
            mostPopularNum = arr[i];
        }
        if (len - 1 > i && arr[i + 1] != num) {
            num = arr[i + 1];
            currentFreq = 0;
        }
    }

    console.log('The most popular number in the array is ' + mostPopularNum + ' with ' + largestFreq + ' occurrences.')
}
