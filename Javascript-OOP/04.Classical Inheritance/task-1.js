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
			var validate = /[A-Za-z]+/i;
			if (firstname && (firstname.length > 2 && firstname.length < 21)) {
				if (validate.test(firstname)) {
					this.firstname = firstname;
				} else {
					throw new Error('The man is lying about their name.');
				}
			} else {
				throw new Error('The man has no name.');
			}

			if (lastname && (lastname.length > 2 && lastname.length < 21)) {
				if (validate.test(lastname)) {
					this.lastname = lastname;
				} else {
					throw new Error('The man is lying about their name.');
				}
			} else {
				throw new Error('The man has no last name.');
			}

			if (+age > -1 && +age < 151) {
				this.age = age;
			} else {
				throw new Error('The man is lying about their age.');
			}

			Object.defineProperty(this, 'fullname', {
				get: function() { return this.firstname + ' ' + this.lastname; },
				set: function(fname) {
					fname = fname.split(' ');
					this.firstname = fname[0];
					this.lastname  = fname[1];
					return this;
					}
			});
			/* The following code only acts as a function, unlike .defineProperty which can be both a function and
			a property due to its duality
			Person.prototype.fullname = function(fname) {
				if (fname) {
					var name = fname.split(' ');
					this.firstname = name[0];
					this.lastname = name[1];
					return this;
				} else {
					return this.firstname + ' ' + this.lastname;
				}
			};
			*/
			Person.prototype.introduce = function() {
				return 'Hello! My name is ' + this.fullname + ' and I am ' + this.age + '-years-old';
			};
		}
		
		return Person;
	} ());
	return Person;
}
module.exports = solve;