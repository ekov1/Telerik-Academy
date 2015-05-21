//Write a script that finds the lexicographically smallest and largest property in document, window and navigator objects.

var doc = document,
    win = window,
    nav = navigator;

function lexicographicalOperations(doc, win, nav) {
    console.log('Document smallest property: ' + findSmallest(doc) + ' || biggest property: ' + findBiggest(doc));
    console.log('Window smallest property: ' + findSmallest(win) + ' || biggest property: ' + findBiggest(win));
    console.log('Navigator smallest property: ' + findSmallest(nav) + ' || biggest property: ' + findBiggest(nav));
}

function findSmallest(object) {
    var compareParam = 'aaa';
    for(var property in object) {
        if(compareParam > property)
            compareParam = property;
    }

    return compareParam !== 'aaa' ? compareParam : '';
}

function findBiggest(object) {
    var compareParam = 'zzz';
    for(var property in object) {
        if(compareParam < property)
            compareParam = property;
    }

    return compareParam !== 'zzz' ? compareParam : '';
}

lexicographicalOperations(doc, win, nav);