//Write a script that finds the max and min number from a sequence of numbers.

function MinMaxSequence() {
    var numbers = [24, 4, -132, 3, 1, 420, -6, 4, 2, 17, 12, 6, 3,
        -1, 4, 6, 1, 5, 3, 8, 7, 2, 9, -4, -3, 14, -11, 409, 5, 8, 55],
        min = Number.MAX_VALUE,
        max = Number.MIN_VALUE,
        i;

    for (i = 0; i < numbers.length; i+=1) {
        if(min > numbers[i]) {
            min = numbers[i];
        }
        if(max < numbers[i]) {
            max = numbers[i];
        }
    }

    console.log('Min value: ' + min + ' Max value: ' + max)
}

MinMaxSequence();