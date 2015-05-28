//Task1 Exchange if greater

function exchangeIfGreater(a, b) {
    if (a > b) {
        var temp = a;
        a = b;
        b = temp;
    }

    console.log('A: ' + a + '|| B: ' + b);
}

//Task2 Multiplication sign

function multiplicationSign(a, b, c) {
    if(a===0 || b===0 || c===0) {
        console.log("Resulting sign is: 0");
        return;
    }

    if((a > 0 && b > 0 && c > 0) ||
        (a < 0 && b < 0 && c > 0) ||
        (a < 0 && b > 0 && c < 0) ||
        (a > 0 && b < 0 && c < 0)) {
        console.log("Resulting sign is: +");
    }
    else {
        console.log("Resulting sign is: -");
    }
}

//Task3 The largest of three

function largestOfThreeNumbers(a, b, c) {
    if (a > b) {
        if (a > c) {
            console.log(a);
        } else {
            console.log(c);
        }
    } else {
        if (b > c) {
            console.log(b);
        } else {
            console.log(c);
        }
    }
}

//Task4 Sort three numbers

function sortThreeNumbers(a, b, c) {
    var result, temp;

    if (a <= b) {
        if (b <= c) {
            temp = a;
            a = c;
            c = temp;
        } else if (a <= c){
            temp = a;
            a = b;
            b = c;
            c = temp;
        } else {
            temp = a;
            a = b;
            b = temp;
        }
    } else {
        if (b < c){
            temp = b;
            b = c;
            c = temp;
        }
    }
    result = (a + ', ' + b + ', ' + c);
    console.log(result);
}



//Task5 Digit as word

function digitAsWord(digit) {
    var result;
    switch (Number(digit)) {
        case 1: result = 'one'; break;
        case 2: result = 'two'; break;
        case 3: result = 'three'; break;
        case 4: result = 'four'; break;
        case 5: result = 'five'; break;
        case 6: result = 'six'; break;
        case 7: result = 'seven'; break;
        case 8: result = 'eight'; break;
        case 9: result = 'nine'; break;
        default: result = "not a digit"; break;
    }

    console.log(result);
}

//Task6 Quadratic equation

function quadraticEquation(a, b, c) {
    var D, x1, x2;
    D = b*b - 4*a*c;

    if(D === 0) {
        x1 = -b/2*a;
        console.log('x1 = x2 = ' + x1);
    }
    else if(D > 0) {
        x1 = (-b + Math.sqrt(D))/(2*a);
        x2 = (-b - Math.sqrt(D))/(2*a);
        console.log('x1 = ' + x1 + '; x2 = ' + x2);
    }
    else {
        console.log('There are no real roots');
    }
}

//Task 7 Largest of five numbers

function largestOfFiveNumbers(a, b, c, d, e) {
    var result;

    if(a > b) {
        if(a > c) {
            if(a > d) {
                if(a > e) {
                    result = a;
                }
            }
        }
    } else if(b > c) {
        if(b > d) {
            if(b > e) {
                result = b;
            }
        }
    } else if(c > d) {
        if(c > a) {
            if(c > e) {
                result = c;
            }
        }
    } else if(d > a) {
        if(d > b) {
            if(d > e) {
                result = d;
            }
        }
    } else if(e > a) {
        if(e > b) {
            if(e > c) {
                if(e > d) {
                    result = e;
                }
            }
        }
    }

    console.log('The largest of all 5 numbers is: ' + result);
}

//Task 8 Number as word

function numberAsWord(num) {
    var ones = ['', 'one', 'two', 'three', 'four', 'five', 'six', 'seven', 'eight', 'nine'];
    var tenToTwenty = ['ten', 'eleven', 'twelve', 'thirteen', 'fourteen',
        'fifteen', 'sixteen', 'seventeen', 'eighteen', 'nineteen'];
    var tens = ['', '', 'twenty', 'thirty', 'forty', 'fifty', 'sixty', 'seventy', 'eighty', 'ninety'];
    var hundreds = ['', 'hundred', 'two hundred', 'three hundred', 'four hundred',
        'five hundred', 'six hundred', 'seven hundred', 'eight hundred', 'nine hundred'];

    var result;

    num = num.toString();

    if(num.length == 3) {
        result = hundreds[num[0]];
        if(num[1] < 1) {
            result = result + ' and ' + ones[num[2]];
        } else if(num[1] == 1) {
            result = result + ' and ' + tenToTwenty[num[2]];
        } else {
            result = result + ' ' + tens[num[1]];
            if(num[2] != 0) {
                result = result + '-' + ones[num[2]];
            }
        }
    } else if(num.length == 2) {
        if(num[0] == 1) {
            result = tenToTwenty[num[1]];
        } else {
            result = tens[num[0]];
            if(num[1] != 0) {
                result = result + '-' + ones[num[1]];
            }
        }
    } else {
        result = ones[num[0]];
    }

    console.log('Representation of your number(' + num + ') is: ' +  result);
}


//Function calls
console.log('Task 1 results: ');
exchangeIfGreater(5.5, 4.5);
console.log('-------------');
console.log('Task 2 results: ');
multiplicationSign(-1, -0.5, -5.1);
console.log('-------------');
console.log('Task 3 results: ');
sortThreeNumbers(7, -10, 3);
console.log('-------------');
console.log('Task 4 results: ');
largestOfThreeNumbers(5, 16, 3);
console.log('-------------');
console.log('Task 5 results: ');
digitAsWord(6);
console.log('-------------');
console.log('Task 6 results: ');
quadraticEquation(2, 5, -3);
console.log('-------------');
console.log('Task 7 results: ');
largestOfFiveNumbers(3, 5, 7, -10, 0.5);
console.log('-------------');
console.log('Task 8 results: ');
numberAsWord(762);