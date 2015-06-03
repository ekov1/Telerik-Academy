//Write a function that finds all the occurrences of word in a text.
//The search can be case sensitive or case insensitive.
//Use function overloading.

var input = 'The quick brown fox! jumps over The lazy dog! dog quick brown Fox jumps over The lazy dog. Fox fox fox';
var inputWord = 'Fox';

occurrencesWord(input, inputWord);
occurrencesWord(input, inputWord, true);

function occurrencesWord(input, word, flag) {
    var result;

    if (flag == null) {
        flag = false;
    }

    if (flag) {
        result = input.split(word);
        console.log('Occurrences of word ' + word + ': ' + (result.length-1));

    } else if (!flag) {

        input = input.toLowerCase();
        result = input.split(word.toLowerCase());
        console.log('Occurrences of word ' + word + ': ' + (result.length-1));
    }
}