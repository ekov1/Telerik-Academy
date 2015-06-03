//Write a function that checks if a given object contains a given property.
// var obj  = …;
// var hasProp = hasProperty(obj, 'length');

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

hasPropertyTest();

function hasPropertyTest() {
    var prop1 = 'eyes',
        prop2 = 'upperbody';
        result = hasProperty(input, prop1);

    console.log('Input object has the property ' + prop1 + ': ' + result);
    result = hasProperty(input.limbs, prop2);
    console.log('Input object has the property ' + prop2 + ': ' + result);

}

function hasProperty(obj, prop) {
    if (obj.hasOwnProperty(prop))
        return true;
    return false;
}