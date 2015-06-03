//Write a function that reverses the digits of given decimal number.

var input = 123.45;
var input2 = 5620;
var input3 = -255;

reverseNumber(input);
reverseNumber(input2);
reverseNumber(input3);


function reverseNumber(num) {
    if (isNaN(num)) {
        console.log('Not a number!');
        return;
    }

    var result = '',
        numToString = num.toString();

    for (var i = numToString.length - 1; i >= 0; i -= 1) {
        result += numToString[i];
    }

    //Trailing zeroes and minus
    var numToArray = result.split('');
    while(numToArray[0] == 0) {
        if (numToArray[0]) {
            numToArray.shift();
        }
    }

    if (numToArray[numToArray.length-1] == '-') {
        numToArray.pop();
        numToArray.unshift('-');
    }

    console.log('Resulting number: ' + numToArray.join(''));
}