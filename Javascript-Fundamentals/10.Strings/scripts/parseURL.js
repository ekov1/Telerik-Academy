//Write a script that parses an URL address given in the format:
// [protocol]://[server]/[resource] and extracts from it the [protocol], [server] and [resource] elements.
//Return the elements in a JSON object.
//    Example:

//URL	result
//http://telerikacademy.com/Courses/Courses/Details/239
// { protocol: http, server: telerikacademy.com, resource: /Courses/Courses/Details/239

var input = 'https://github.com/TelerikAcademy/JavaScript-Fundamentals/tree/master/11%20Strings';
//var input = 'http://telerikacademy.com/Courses/Courses/Details/239';

console.log('------------');
console.log('URL: ' + input);
console.log('Parsed URL: ');
console.log(parseURL(input));

function parseURL(url) {
    var result = {},
        regProtocol = /(([A-z])+)/,
        regServer = /([0-z\-]+)\.([A-z])*/,
        regRes = /((\/+[0-z\-%]+)+\/+)([0-z\-%]*)/;

    result.protocol = url.match(regProtocol)[0];
    result.server = url.match(regServer)[0];
    result.resource = url.match(regRes)[0];

    return result;
}