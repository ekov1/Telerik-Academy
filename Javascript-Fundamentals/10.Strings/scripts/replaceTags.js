//Write a JavaScript function that replaces in a HTML document given as string
// all the tags <a href="�">�</a> with corresponding tags [URL=�]�/URL].
//Example:
//
//input
//<p>Please visit <a href="http://academy.telerik.com">our site</a> to choose a training course.
//Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>
//
//output
//<p>Please visit [URL=http://academy.telerik.com]our site[/URL] to choose a training course.
//Also visit [URL=www.devbg.org]our forum[/URL] to discuss the courses.</p>

var input = '<p>Please visit <a href="http://academy.telerik.com">our site</a> to choose a training course. ' +
    'Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>';

console.log('---------------');
console.log('Paragraph with replaced \<a href\> tags: ' + replaceATags(input));

function replaceATags(str) {
    var regEx = /<\s*a\s+href\s*=\s*"(.*?)"\s*>(.*?)<\s*\/a\s*>/gi;

    return str.replace(regEx, function(tag, url, content) {
        return '[URL=' + url + ']' + content + '[\/URL]';
    });
}