//Write a function that formats a string using placeholders.
//The function should work with up to 30 placeholders and all types.
//    Examples:

//var str = stringFormat('Hello {0}!', 'Peter');
//str = 'Hello Peter!';
//var frmt = '{0}, {1}, {0} text {2}';
//var str = stringFormat(frmt, 1, 'Pesho', 'Gosho');
//str = '1, Pesho, 1 text Gosho'

var input = '{0}, {1}, {0} text {2}';

console.log('-----------');
console.log(format(input, 1, 'Pesho', 'Gosho'));

function format(){
    var args = arguments,
        string = args[0],
        placeholder;

    for (var ind = 1; ind < args.length; ind++) {
        placeholder ='{' + (ind - 1) + '}';

        while(string.indexOf(placeholder) > -1) {
            string = string.replace(placeholder, args[ind]);
        }
    }

    return string;
}
