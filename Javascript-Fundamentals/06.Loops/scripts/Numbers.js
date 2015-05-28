//Write a script that prints all the numbers from 1 to N.

function printNumbers(n) {
    var i;

    if(i>=1) {

    	for (i = 1; i <= n; i+=1) {
        	console.log(i);
    	}
	} else {

		for (i = 1; i >= n; i-=1) {
			console.log(i);
		}
	}
}

printNumbers(14);
