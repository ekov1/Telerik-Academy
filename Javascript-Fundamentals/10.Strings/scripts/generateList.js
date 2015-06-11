//Write a function that creates a HTML <ul> using a template for every HTML <li>.
//The source of the list should be an array of elements
//Replace all placeholders marked with –{…}– with the value of the corresponding property of the object.

var input = [
    "<div data-type=\"template\" id=\"list-item\">",
    " <strong>-{name}-</strong> <span>-{age}-</span>",
    " <strong>-{name}-</strong> <span>-{age}-</span>",
    "</div>"
],
    temp = [];

console.log('-------------');
console.log(generate(input));

function generate(sampleHtml) {

    temp[0]    = sampleHtml[0];
    temp[1]    = sampleHtml[sampleHtml.length - 1];
    var people = [{name: 'pesho', age: 14}, {name: 'stamat', age: 29}, {name: 'penka', age: 6}];
    var rows   = sampleHtml.slice(1, sampleHtml.length - 1);
    sampleHtml = sampleHtml.join('\n');

    var matchPlaceholders = /-\{.+?\}-/g, placeholders = sampleHtml.match(matchPlaceholders);

    var len = placeholders.length;

    var list = '<ul>\n' + new Array(people.length + 1).join('    <li>' + rows.join('</li>\n    <li>') + '</li>\n') + '</ul>';
    var key;
    for (var i = 0; i < len; i += 1) {
        for (var j = 0; j < people.length; j += 1) {
            key  = placeholders[i].substring(2, placeholders[i].length - 2);
            list = list.replace(placeholders[i], people[j][key]);


        }

    }

    return temp.join('\n    ' + list.replace(/\n/g, '\n    ') + '\n');
}
