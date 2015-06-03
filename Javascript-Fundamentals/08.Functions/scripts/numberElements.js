//Write a function to count the number of div elements on the web page

var doc = document;

numberElements(doc);

function numberElements(doc) {
    var dirCount = doc.getElementsByTagName('div');
    console.log(dirCount.length);
}