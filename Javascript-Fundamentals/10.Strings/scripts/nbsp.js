//Write a function that replaces non breaking white-spaces in a text with &nbsp;


var input = 'We are <mixcase>living</mixcase> in a <upcase>yellow submarine</upcase>. ' +
    'We <mixcase>don\'t</mixcase> have <lowcase>anything</lowcase> else.';


console.log('-------------');
console.log('Original text with regular whitespaces: ' + input);
console.log('Text with replaced whitespaces: ' + replaceNbsp(input));


function replaceNbsp(str) {
    var nbsp = '&nbsp;',
        result = '';

    var i,
        len = str.length;

    for (i = 0; i < len; i += 1) {
        if (str[i] === ' ') {
            result += nbsp;
        } else {
            result += str[i];
        }
    }

    return result;
}