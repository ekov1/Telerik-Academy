//Write a function for extracting all email addresses from given text.
//All sub-strings that match the format @… should be recognized as emails.
//Return the emails as array of strings.

var input = 'riojasm66@yahoo.com, these are all, hdclive@live.com scam email addresses terauau@gmail.com ' +
    'jabu_moleketi@yahoo.com use them "at" "your discretion sadasd@d" soeungkheng34@yahoo.com desk433@yahoo.com ' +
    'caf432@ig.com.br, this is a scam address too, samanthakipkalya24@yahoo.in do not open emails from these bots ' +
    'cpt.jane@yahoo.com.ph';

console.log('-------------------');
console.log('Original text: ' + input);
console.log('\n\rMatched emails from the text: ' + extractEmails(input));


function extractEmails(str){
    var regEx = /([a-zA-Z0-9._-]+@[a-zA-Z0-9._-]+\.[a-zA-Z0-9._-]+)/gi,
        result;

    result = str.match(regEx).join('\n\r');

    return result;
}