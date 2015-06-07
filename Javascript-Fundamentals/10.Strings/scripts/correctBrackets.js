// Write a JavaScript function to check if in a given
// expression the brackets are put correctly.
// Example of correct expression: ((a+b)/5-d).
// Example of incorrect expression: )(a+b)).

console.log('---------------------');
console.log('((a+b)/5-d) - ' + isCorrect('((a+b)/5-d)'));
console.log(')(a+b)) - ' + isCorrect(')(a+b))'));

function isCorrect(expr) {
    var check = 0;

    for (var ind = 0; ind < expr.length; ind+=1) {
        if(expr[ind] === '('){
            check++;
        } else if (expr[ind] === ')') {
            check--;
        }

        if (check < 0) {
            return 'Incorrect placement of brackets';
        }
    }

    return check ? 'Incorrect placement of brackets' : 'Correct placement of brackets';
}