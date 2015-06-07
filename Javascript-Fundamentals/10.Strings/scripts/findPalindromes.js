//Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".

function reverse(str) {
    var result = '';

    for (var i = str.length - 1; i >= 0; i -= 1) {
        result += str[i];
    }

    return result;
}

var input = 'These are examples of polindromes: civic, deified, deleveled,devoved, dewed, Hannah, kayak, level, madam, ' +
    'racecar, radar, redder, refer, repaper, reviver, rotator, rotor, sagas, solos, sexes, stats, tenet' +
    'Palindromes in bulgarian: доход, dovod, казак, kapak, нежен, ' +
    'потоп, рефер, hliab, това не е палиндром, това също, товва, napisano e na maimunica narochno :D';

console.log('---------------');
console.log('Original text from which palindromes are to be extracted: ' + input);
console.log('\n\rAll found palindromes: ');
console.log(extractPalindromes(input));

function extractPalindromes(str) {
    var separators = /[ ,\.:!?\']/g,
        words = str.split(separators).filter(function(word) {
        return !!word;
    }),
        palindromes = [];

    for (var word of words) {
        if (word === reverse(word) && word.length > 2) {
            palindromes.push(word);
        }
    }

    return palindromes;
}