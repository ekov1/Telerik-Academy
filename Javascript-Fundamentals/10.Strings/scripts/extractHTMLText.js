//Write a function that extracts the content of a html page given as text.
//The function should return anything that is in a tag, without the tags.
//    Example:

//<html>
//<head>
//<title>Sample site</title>
//</head>
//<body>
//<div>text
//<div>more text</div>
//and more...
//</div>
//in body
//</body>
//</html>

//Result: Sample sitetextmore textand more...in body

var input = '<html><head><title>Sample site</title></head><body><div>text<div>more text' +
    '</div>and more...</div>in body</body></html>';

console.log('-------------');
console.log('Original html: ' + input);
console.log('Parsed text from the html: ' + extractHTML(input));

function extractHTML(str) {
    var i,
        len = str.length,
        openTags = false,
        closingTags = false,
        result = '';

    for (i = 0; i < len; i += 1) {
        if (str[i] === '<' && str[i+1] === '/') {
            closingTags = true;
        } else if (str[i] === '<') {
            openTags = true;
            continue;
        } else if (str[i] === '>') {
            openTags = false;
            closingTags = false;
            continue;
        }

        if (openTags || closingTags) {
            continue;
        }

        result += str[i];

    }
    return result;
}