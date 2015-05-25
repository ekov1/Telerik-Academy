//Write a script that allocates array of 20 integers and initializes each element by its index multiplied by 5.
//Print the obtained array on the console.

increasingMembers();

function increasingMembers() {
    var size = 20,
        arr = [size];

    for (var i = 0; i < size; i++) {
        arr[i] = i*5;
    }

    console.log('Resulting array: ' + arr.join(', '));
}