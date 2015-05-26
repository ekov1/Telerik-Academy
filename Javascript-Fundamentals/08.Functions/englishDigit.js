//Write a function that returns the last digit of given integer as an English word.

var input = '12309';

englishDigit(input);
englishDigitAlt(input);

function englishDigit(num) {
    if (isNaN(num)) {
        console.log('Not a number!');
        return;
    }

    var result = 'The last digit of your number is: ';

    switch (num[num.length-1]) {
        case '0': result += 'zero';
            break;
        case '1': result += 'one';
            break;
        case '2': result += 'two';
            break;
        case '3': result += 'three';
            break;
        case '4': result += 'four';
            break;
        case '5': result += 'five';
            break;
        case '6': result += 'six';
            break;
        case '7': result += 'seven';
            break;
        case '8': result += 'eight';
            break;
        case '9': result += 'nine';
            break;
    }

    console.log(result);
}

function englishDigitAlt(num) {
    if (isNaN(num)) {
        console.log('Not a number!');
        return;
    }

    var result = 'The last digit of your number is: ',
        digits = ['zero', 'one', 'two', 'three', 'four', 'five', 'six', 'seven', 'eight', 'nine'];

    result += digits[num[num.length-1]];

    console.log(result);
}