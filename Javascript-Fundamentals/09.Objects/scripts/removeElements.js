//Write a function that removes all elements with a given value.
//Attach it to the array type.

//var arr = [1,2,1,4,1,3,4,1,111,3,2,1,'1'];
//arr.remove(1); //arr = [2,4,3,4,111,3,2,'1'];

var input = [1,2,1,4,1,3,4,1,111,3,2,1,'1'];

removeElementsTest();

function removeElementsTest() {

    console.log('Initial array: ' + input);

    input.remove(1);
    console.log('Removing 1 : ' + input);

    input.remove(2);
    console.log('\nRemoving 2 : ' + input);

}

Array.prototype.remove = function (element) {
    var arr = this,
        index;

    for (index in arr) {
        if (arr[index] === element) {
            arr.splice(index, 1);
        }
    }
};