//You are given a text. Write a function that changes the text in all regions:

//<upcase>text</upcase> to uppercase.
//<lowcase>text</lowcase> to lowercase
//<mixcase>text</mixcase> to mix casing(random)
//Example: We are <mixcase>living</mixcase> in a <upcase>yellow submarine</upcase>.
//We <mixcase>don't</mixcase> have <lowcase>anything</lowcase> else.

//The expected result:
//We are LiVinG in a YELLOW SUBMARINE. We dOn'T have anything else.

String.prototype.toMixedCase = function() {
    var j,
        length = this.length,
        res = '';

    for (j = 0; j < length; j += 1) {
        if (Math.floor((Math.random() * 2) + 1) % 2 == 0) {
            res += this[j].toLowerCase();
        } else {
            res += this[j].toUpperCase();
        }
    }

    return res;
};

var input = 'We are <mixcase>living</mixcase> in a <upcase>yellow submarine</upcase>. ' +
    'We <mixcase>don\'t</mixcase> have <lowcase>anything</lowcase> else.';

console.log('---------------');
console.log('Original string: ' + input);
console.log('Input after parsed tags: ' + parseTags(input));

function parseTags(str) {
    var i,
        len = str.length,
        openTags = false,
        inTags = false,
        closingTags = false,
        command = '',
        result = '';

    for (i = 0; i < len; i += 1) {
        if (str[i] === '<' && str[i+1] === '/') {
            closingTags = true;
            command = '';
        } else if (str[i] === '<') {
            openTags = true;
            inTags = false;
            continue;
        } else if (str[i] === '>') {
            openTags = false;
            closingTags = false;
            inTags = true;
            continue;
        }

        if (openTags) {
            command += str[i];
            continue;
        } else if (closingTags) {
            continue;
        }

        if (inTags && command) {
            switch (command) {
                case 'lowcase': result += str[i].toLowerCase();
                    break;
                case 'upcase': result += str[i].toUpperCase();
                    break;
                case 'mixcase': result += str[i].toMixedCase();
                    break;
                default: inTags = false;
                    break;
            }
            continue;
        }

        result += str[i];

    }
    return result;
}

