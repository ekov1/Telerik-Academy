/* Task Description */
/* 
	Create a function constructor for Person. Each Person must have:
	*	properties `firstname`, `lastname` and `age`
		*	firstname and lastname must always be strings between 3 and 20 characters, containing only Latin letters
		*	age must always be a number in the range 0 150
			*	the setter of age can receive a convertible-to-number value
		*	if any of the above is not met, throw Error 		
	*	property `fullname`
		*	the getter returns a string in the format 'FIRST_NAME LAST_NAME'
		*	the setter receives a string is the format 'FIRST_NAME LAST_NAME'
			*	it must parse it and set `firstname` and `lastname`
	*	method `introduce()` that returns a string in the format 'Hello! My name is FULL_NAME and I am AGE-years-old'
	*	all methods and properties must be attached to the prototype of the Person
	*	all methods and property setters must return this, if they are not supposed to return other value
		*	enables method-chaining
*/
function solve() {
	var Person = (function () {
		function Person(firstname, lastname, age) {
			this.firstname = firstname;
			this.lastname = lastname;
			this.age = age;
		}

		var validate = /[A-Za-z]+/i;

		Object.defineProperty(Person.prototype, 'firstname', {
			get: function () { return this._firstname },
			set: function (firstname) {
				if (firstname && (firstname.length > 2 && firstname.length < 21)) {
					if (validate.test(firstname)) {
						this._firstname = firstname;
					} else {
						throw new Error('The man is lying about their name.');
					}
				} else {
					throw new Error('The man has no name.');
				}
			}
		});

		Object.defineProperty(Person.prototype, 'lastname', {
			get: function () { return this._lastname },
			set: function (lastname) {
				if (lastname && (lastname.length > 2 && lastname.length < 21)) {
					if (validate.test(lastname)) {
						this._lastname = lastname;
					} else {
						throw new Error('The man is lying about their name.');
					}
				} else {
					throw new Error('The man has no name.');
				}
			}
		});

		Object.defineProperty(Person.prototype, 'age', {
			get: function () { return this._age; },
			set: function (age) {
				if (+age > -1 && +age < 151) {
					this._age = age;
				} else {
					throw new Error('The man is lying about their age.');
				}
			}
		});

		Object.defineProperty(Person.prototype, 'fullname', {
			get: function() { return this.firstname + ' ' + this.lastname; },
			set: function(fname) {
				fname = fname.split(' ');
				this.firstname = fname[0];
				this.lastname  = fname[1];
			}
		});

		Person.prototype.introduce = function() {
			return 'Hello! My name is ' + this.fullname + ' and I am ' + this.age + '-years-old';
		};
		
		return Person;
	} ());
	return Person;
}
module.exports = solve;