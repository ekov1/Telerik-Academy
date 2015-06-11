//The text is as follows: We are living in an yellow submarine. We don't have anything else.
//inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.

//The result is: 9

var input = 'We are living in an yellow submarine. We don\'t have anything else.' +
    ' inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.',
    target = 'In';

console.log('-----------');
console.log('Occurrences of the target string (' + target + ') in the text: ' + substring(input, target));

function substring(str, target) {
    var i,
        len = str.length,
        tarlen = target.length,
        count = 0;

    for (i = 0; i < len; i += 1) {
        if (target.toLowerCase() === str.substr(i, tarlen).toLowerCase()) {
            count += 1;
        }
    }

    return count;
}