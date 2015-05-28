//Write a script that compares two char arrays lexicographically (letter by letter).

compare('foools', 'toools');

function compare(a,b){
    var length = Math.min(a.length, b.length);

    for (var i = 0; i < length; i+=1) {
        if(a[i]<b[i]){
            console.log('Resulting char array: ' + a);
            return;
        }
        else if(a[i]>b[i]){
            console.log('Resulting char array: ' + b);
            return;
        }
    }
    console.log('Resulting char array: ' + (a.length < b.length) ? a : b);
}