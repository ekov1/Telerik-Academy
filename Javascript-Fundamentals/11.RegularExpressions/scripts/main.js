/* Problem 1 */
console.log('--------- Problem 1 --------');

var input1 = {name: 'John'};
var input2 = {name: 'John', age: 13};

var str1 = 'Hello, there! Are you #{name}?';
var str2 = 'My name is #{name} and I am #{age}-years-old';



String.prototype.format = function (options) {
	var matchPlaceholders = /#\{.+?}/g;
	var matchKey = /[a-z]*(?=\})/i;
	var matches = this.match(matchPlaceholders);
	
	var formatted = this, len = matches.length;
	
	for (var i = 0; i < len; i+=1) {
		formatted = formatted.replace(matches[i], options[matches[i].match(matchKey)[0]]);
		
	}
	
	return formatted;
}

console.log(str1.format(input1));
console.log(str2.format(input2));

/* Problem 2 */
console.log('\n--------- Problem 2 --------');

var stri = '<div data-bind-content="name"></div>';
var bindingString = '<a data-bind-content="name" data-bind-href="link" data-bind-class="name"></а>';

String.prototype.bind = function (obj) {
	var formatted = this;
	
	var contentKey = formatted.match(/data-bind-content=".+?"/)[0].match(/".+?"/)[0].replace(/"/g, '');
	formatted = formatted.replace(/>\s*?</, '>' + obj[contentKey] + '<');
	
	var matches = formatted.match(/(data-bind-(href|class)=".+?")/g);
	
	var len = matches === null ? 0 : matches.length;
	var n, m;
	
	for (var i = 0; i < len; i+=1) {
		n = obj[matches[i].match(/".+?"/)[0].replace(/"/g, '')];
		m = matches[i].replace(/".+?"/, '"' + n + '"');
		formatted = formatted.replace(matches[i], m);
		
	}
	
	return formatted;
};

console.log(stri.bind({name: 'Pesho'}));
console.log(bindingString.bind({name: 'Elena', link: 'http://telerikacademy.com'}));