//Write a script that finds the lexicographically smallest and largest property in document, window and navigator objects.

var doc = document,
    win = window,
    nav = navigator;

function LexicographicalOperations(doc, win, nav) {
    console.log('Document smallest property: ' + FindSmallest(doc) + ' || biggest property: ' + FindBiggest(doc));
    console.log('Window smallest property: ' + FindSmallest(win) + ' || biggest property: ' + FindBiggest(win));
    console.log('Navigator smallest property: ' + FindSmallest(nav) + ' || biggest property: ' + FindBiggest(nav));
}

function FindSmallest(object) {
    var compareParam = 'aaa';
    for(var property in object) {
        if(compareParam > property)
            compareParam = property;
    }

    return compareParam !== 'aaa' ? compareParam : '';
}

function FindBiggest(object) {
    var compareParam = 'zzz';
    for(var property in object) {
        if(compareParam < property)
            compareParam = property;
    }

    return compareParam !== 'zzz' ? compareParam : '';
}

LexicographicalOperations(doc, win, nav);