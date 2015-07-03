/* Task Description */
/* 
* Create a module for a Telerik Academy course
  * The course has a title and presentations
    * Each presentation also has a title
    * There is a homework for each presentation
  * There is a set of students listed for the course
    * Each student has firstname, lastname and an ID
      * IDs must be unique integer numbers which are at least 1
  * Each student can submit a homework for each presentation in the course
  * Create method init
    * Accepts a string - course title
    * Accepts an array of strings - presentation titles
    * Throws if there is an invalid title
      * Titles do not start or end with spaces
      * Titles do not have consecutive spaces
      * Titles have at least one character
    * Throws if there are no presentations
  * Create method addStudent which lists a student for the course
    * Accepts a string in the format 'Firstname Lastname'
    * Throws if any of the names are not valid
      * Names start with an upper case letter
      * All other symbols in the name (if any) are lowercase letters
    * Generates a unique student ID and returns it
  * Create method getAllStudents that returns an array of students in the format:
    * {firstname: 'string', lastname: 'string', id: StudentID}
    *
    *
  * Create method submitHomework
    * Accepts studentID and homeworkID
      * homeworkID 1 is for the first presentation
      * homeworkID 2 is for the second one
      * ...
    * Throws if any of the IDs are invalid
    *
    *
    *
  * Create method pushExamResults
    * Accepts an array of items in the format {StudentID: ..., Score: ...}
      * StudentIDs which are not listed get 0 points
    * Throw if there is an invalid StudentID
    * Throw if same StudentID is given more than once ( he tried to cheat (: )
    * Throw if Score is not a number
    *
    *
  * Create method getTopStudents which returns an array of the top 10 performing students
    * Array must be sorted from best to worst
    * If there are less than 10, return them all
    * The final score that is used to calculate the top performing students is done as follows:
      * 75% of the exam result
      * 25% the submitted homework (count of submitted homeworks / count of all homeworks) for the course
*/

function solve() {
	var Course = {
		init: function(title, presentations) {
			this.title = title;
			this.presentations = presentations;
			this.students = [];
			this.evaluatedStudents = [];
			studentID = 0;
			return this;
		},
		addStudent: function(name) {
			name = name.split(' ');
			if (name.length !== 2) {
				throw new Error('A student can have only 2 names');
			}
			var fname = name[0],
				lname = name[1],
				regX = /([A-Z]){1}([a-z])*/;

			if (!regX.test(fname) || !regX.test(lname)) {
				throw new Error('Names not provided in the correct format!');
			}

			studentID += 1;
			this.students.push({
				firstname: fname,
				lastname: lname,
				id: studentID
			});
			return studentID;
		},
		getAllStudents: function() {
			return this.students || [];
		},
		submitHomework: function(studentID, homeworkID) {
			if(this.presentations[homeworkID - 1] === undefined) {
				throw new Error('')
			}
			if (this.students[studentID - 1] === undefined || this.presentations[homeworkID - 1] === undefined ) {

				throw new Error('No student or presentation with the following ID!');
			}
		},
		pushExamResults: function(results) {
			var id,
				score;
			if (results === undefined) {
				throw new Error('Please provide scores!');
			}
			if (!Array.isArray(results)) {
				throw new Error('Results not provided in the correct format!');
			}
			for (var i in results) {
				id = results[i].StudentID;
				score = results[i].Score;

				if (id === undefined) {
					continue;
				}
				if (isNaN(+score)) {
					throw new Error('Invalid ID');
				}
				if (this.students[id-1] === undefined) {
					throw new Error('Invalid student ID');
				}
				if (this.evaluatedStudents.indexOf(id) > -1) {
					throw new Error('Student\'s cheating!');
				}
				this.evaluatedStudents.push(id);
			}
		},
		getTopStudents: function() {
		},

		get title() {
			return this._title;
		},
		set title(input) {
			if (isValidTitle(input)) {
				this._title = input;
			} else {
				throw new Error('Invalid title!');
			}
		},

		get presentations() {
			return this._presentations;
		},
		set presentations(arr) {
			if (arr.length < 1) {
				throw new Error('The course needs to have at least 1 presentation!');
			}
			for (var i in arr) {
				if (!isValidTitle(arr[i])) {
					throw new Error('Invalid presentation title');
				}
			}
			this._presentations = arr.slice();
			return this;
		}
	};

	function isValidTitle(title) {
		if (title.length === 0 || title !== title.trim() || title.match(/\s{2,}/)) {
			return false;
		}
		return true;
	}

	return Course;
}


module.exports = solve;
