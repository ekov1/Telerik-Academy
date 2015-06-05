//Write a function that groups an array of people by age, first or last name.
//The function must return an associative array, with keys - the groups, and values - arrays with people in this groups
//Use function overloading (i.e. just one function)

//var people = {…};
//var groupedByFname = group(people, 'firstname');
//var groupedByAge= group(people, 'age');

function personConstructor(fname, lname, age) {
    return {firstname: fname, lastname: lname, age: age}
}

var gosho = personConstructor('Gosho', 'Petrov', 32),
    ivan = personConstructor('Bay', 'Ivan', 21),
    pesho = personConstructor('Pesho', 'Picha', 21),
    doncho = personConstructor('Doncho', 'Minkov', 22),
    pesho2 = personConstructor('Pesho', 'Blastera', 22),
    pesho3 = personConstructor('Pesho', 'Petrov', 32);

var people = [gosho, ivan, pesho, doncho, pesho2, pesho3];

groupPeopleTest();

function groupPeopleTest() {
    var groupedByFname = group(people, 'firstname'),
        groupedByLname = group(people, 'lastname'),
        groupedByAge = group(people, 'age');

    printGroup(groupedByFname, 'firstname');
    printGroup(groupedByLname, 'lastname');
    printGroup(groupedByAge, 'age');
}

function group(people, prop) {
    var result = [],
        currentProp;

    for (var index in people) {
        currentProp = people[index][prop];

        result[currentProp] = result[currentProp] || [];
        result[currentProp].push(people[index]);
    }

    return result;
}

function printGroup(group, prop) {
    console.log(prop);

    for (var key in group) {
        console.log(group[key]);
        console.log('------');
    }
    console.log();
}