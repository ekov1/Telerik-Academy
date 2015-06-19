/* Task Description */
/* 
	Write a function that sums an array of numbers:
		numbers must be always of type Number
		returns `null` if the array is empty
		throws Error if the parameter is not passed (undefined)
		throws if any of the elements is not convertible to Number
*/

function sum(args) {

	if (Array.isArray(args) && args.length < 1) {
		return null;
	}

	if (args === 'undefined') {
		throw 'Error';
	}

	var i,
		len = args.length,
		s = 0;

	for (i = 0; i < len; i += 1) {
		if (isNaN(+args[i])) {
			throw 'Error';
		}
		s += +args[i];
	}

	return s;
}

module.exports = sum;