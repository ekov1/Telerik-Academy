/* 
Create a function that:
*   **Takes** a collection of books
    *   Each book has propeties `title` and `author`
        **  `author` is an object that has properties `firstName` and `lastName`
*   **finds** the most popular author (the author with biggest number of books)
*   **prints** the author to the console
	*	if there is more than one author print them all sorted in ascending order by fullname
		*   fullname is the concatenation of `firstName`, ' ' (empty space) and `lastName`
*   **Use underscore.js for all operations**
*/

function solve(){
	return function (books) {
		var _ = require('underscore');

		var mostPopularAuthor = _.groupBy(books, function(book) {
			return book.author.firstName + ' ' + book.author.lastName;
		});
		var maxAuthor = _.max(mostPopularAuthor, function (group) {
			return group.length;
		}).length;

		_.chain(mostPopularAuthor)
		.where({length: maxAuthor})
		.sortBy(function(group) {
			var fullname = group[0].author.firstName + ' ' + group[0].author.lastName;
			return fullname;
		})
		.each(function(group){
			console.log(group[0].author.firstName + ' ' + group[0].author.lastName);
		});
	};
}

module.exports = solve;