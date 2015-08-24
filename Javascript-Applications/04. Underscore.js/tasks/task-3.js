/* 
Create a function that:
*   Takes an array of students
    *   Each student has:
        *   `firstName`, `lastName` and `age` properties
        *   Array of decimal numbers representing the marks         
*   **finds** the student with highest average mark (there will be only one)
*   **prints** to the console  'FOUND_STUDENT_FULLNAME has an average score of MARK_OF_THE_STUDENT'
    *   fullname is the concatenation of `firstName`, ' ' (empty space) and `lastName`
*   **Use underscore.js for all operations**
*/

function solve(){
  return function (students) {
  	var _ = require('underscore');
  	var studentWithHighestScore = _.chain(students)
  		.each(function(student) {
  			student.avgScore = _.foldl(student.marks, function(memo, mark) {
  				return memo + mark;
  			}) / student.marks.length;
  		})
  		.sortBy('avgScore')
  		.last()
  		.value();

  		console.log(studentWithHighestScore.firstName + ' ' + studentWithHighestScore.lastName + ' has an average score of ' + studentWithHighestScore.avgScore);
  };
}

module.exports = solve;