//Write a JavaScript function that reverses a string and returns it.
//Example:
//input	    output
//sample    elpmas

var input = 'Pesho e pich';

console.log('-----');
console.log('Original string: ' + input);
console.log('Reversed string: ' + reverse(input));

function reverse(str) {
    var result = '';

    for (var i = str.length - 1; i >= 0; i -= 1) {
        result += str[i];
    }

    return result;
}