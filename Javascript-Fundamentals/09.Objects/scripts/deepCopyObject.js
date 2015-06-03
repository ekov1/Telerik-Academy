//Write a function that makes a deep copy of an object.
//The function should work for both primitive and reference types.

var input = {
    fname: 'Pesho',
    lname: 'Peshev',
    number: Math.random(),
    eyes: {
        leye: 'blue',
        reye: 'green'
    },
    limbs: {
        upperbody: {
            runningOutOfProperties: 2
        },
        lowerbody: {
            count: 2
        }
    }
};

deepCopyTest();

function deepCopyTest() {
    var copiedObject,
        result;

    copiedObject = extend(input);

    result = input === copiedObject;

    console.log(input);
    console.log('\n\n');
    console.log(copiedObject);
    console.log('\n\n');
    console.log('Input is the same instance as the resulting copy?: ' + result);
}

//The following method was found on StackOVerflow @ http://stackoverflow.com/a/1042676
function extend(from, to)
{
    if (from == null || typeof from != "object") return from;
    if (from.constructor != Object && from.constructor != Array) return from;
    if (from.constructor == Date || from.constructor == RegExp || from.constructor == Function ||
        from.constructor == String || from.constructor == Number || from.constructor == Boolean)
        return new from.constructor(from);

    to = to || new from.constructor();

    for (var name in from)
    {
        to[name] = typeof to[name] == "undefined" ? extend(from[name], null) : to[name];
    }

    return to;
}