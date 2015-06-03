//Write a function that finds the youngest person in a given array of people and prints his/hers full name
//Each person has properties firstname, lastname and age.

//var people = [
//   { firstname : 'Gosho', lastname: 'Petrov', age: 32 },
//   { firstname : 'Bay', lastname: 'Ivan', age: 81},… ];

function personConstructor(fname, lname, age) {
    return {firstname: fname, lastname: lname, age: age}
}

var gosho = personConstructor('Gosho', 'Petrov', 32),
    ivan = personConstructor('Bay', 'Ivan', 81),
    pesho = personConstructor('Pesho', 'Picha', 21),
    doncho = personConstructor('Doncho', 'Minkov', 26);

var people = [gosho, ivan, pesho, doncho];

youngestPersonTest();

function youngestPersonTest() {
    people.sort(function(a, b) {return a.age - b.age});
    console.log('Youngest person: ' + people[0].firstname + ' ' + people[0].lastname);
}


