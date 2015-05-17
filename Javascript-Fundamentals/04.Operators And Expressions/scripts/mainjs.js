function isOdd() {
    var temp = document.getElementById("oddInput").value;
    var result = document.getElementById("oddCheckResult");

    if (isNaN(temp)){
        result.value = "NaN";
        return;
    }

    if(temp % 2 !== 0) {
        result.value = "ODD";
    }
    else if (temp % 2 === 0) {
        result.value = "EVEN";
    }
}

function divisibleBy5And7() {
    var temp = document.getElementById("divisibleInput").value;
    var result = document.getElementById("divisibleResult");

    if (isNaN(temp)) {
        result.value = "NaN";
        return;
    }

    if (temp % 5 === 0 && temp % 7 === 0) {
        result.value = "DIVISIBLE";
    }
    else {
        result.value = "NOT DIVISIBLE";
    }
}

function calcRectArea() {
    var side1 = document.getElementById("areaInput1").value;
    var side2 = document.getElementById("areaInput2").value;
    var result = document.getElementById("areaResult");
    var area;

    if (isNaN(side1) || isNaN(side2)) {
        result.value = "NaN";
        return;
    }

    if (side1 < 0 || side2 < 0) {
        result.value = "INVALID INPUT";
        return;
    }

    area = side1 * side2;
    result.value = area.toString();
}

function thirdDigitIs7() {
    var temp = document.getElementById("digitInput").value;
    var result = document.getElementById("digitResult");
    var digit;

    if (isNaN(temp)) {
        result.value = "NaN";
        return;
    }

    digit = Math.floor(temp / (Math.pow(10, 2)) % 10);
    result.value = digit === 7 ? "TRUE" : "FALSE";
}

function thirdBit() {
    var temp = document.getElementById("bitInput").value;
    var result = document.getElementById("bitResult");
    var binary;
    var digit;

    if (isNaN(temp)) {
        result.value = "NaN";
        return;
    }

    binary = Number(temp).toString(2);
    digit = binary[binary.length-4];

    result.value = digit === "1" ? 1 : 0;
}

function isInCircle() {
    var coord1 = document.getElementById("pointInput1").value;
    var coord2 = document.getElementById("pointInput2").value;
    var result = document.getElementById("pointResult");
    var circle1 = 0;
    var circle2 = 0;
    var radius = 5;

    if (isNaN(coord1) || isNaN(coord2)) {
        result.value = "NaN";
        return;
    }

    var isInsideCircle = isInCircleCheck(circle1, circle2, coord1, coord2, radius);

    if (isInsideCircle < 0) {
        result.value = "INSIDE CIRCLE";
    }
    else if (isInsideCircle === 0) {
        result.value = "ON CIRCLE";
    }
    else {
        result.value = "OUTSIDE CIRCLE";
    }

}

function isPrime() {
    var temp = document.getElementById("primeInput").value;
    var result = document.getElementById("primeResult");

    if (isNaN(temp)) {
        result.value = "NaN";
        return;
    }

    if (temp > 100) {
        result.value = "INVALID INPUT";
        return;
    }

    if (temp < 2) {
        result.value = "FALSE";
        return;
    }

    var primeCheck = true;

    for(var i = 2; i <= Math.sqrt(temp); i += 1) {
        if (temp % i === 0) {
            primeCheck = false;
        }
    }

    if (primeCheck)
        result.value = "TRUE";
    else
        result.value = "FALSE";

}

function trapezoidArea() {
    var a = Number(document.getElementById("trapArea1").value);
    var b = Number(document.getElementById("trapArea2").value);
    var h = Number(document.getElementById("trapArea3").value);
    var result = document.getElementById("trapResult");

    if((isNaN(a) || isNaN(b) || isNaN(h)) && (a < 0 || b < 0 || h < 0)) {
        result.value = "INVALID INPUT";
        return;
    }

    var area = (a+b)/2*h;
    result.value = area.toString();
}

function isInCircleOutRect() {
    var coord1 = document.getElementById("ptInput1").value;
    var coord2 = document.getElementById("ptInput2").value;
    var result = document.getElementById("ptResult");
    var circle1 = 1;
    var circle2 = 1;
    var rect1topX = 1;
    var rect1topY = -1;
    var rectW = 6;
    var rectH = 2;
    var radius = 3;

    if (isNaN(coord1) || isNaN(coord2)) {
        result.value = "NaN";
        return;
    }

    if((isInCircleCheck(circle1, circle2, coord1, coord2, radius) <= 0) && (!isInRectangleCheck(rect1topX, rect1topY, rectW, rectH, coord1, coord2)))
        result.value = "TRUE";
    else
        result.value = "FALSE";
}

function isInCircleCheck(Xc, Yc, Xp, Yp, radius) {
    var distance = (Xp - Xc)*(Xp - Xc) + (Yp - Yc)*(Yp - Yc);
    return (distance - radius*radius);
}

function isInRectangleCheck(Xr, Yr, W, H, Xp, Yp) {
    //top left corner
    var Ax = Xr;
    var Ay = Yr;
    //bottom right corner
    var Cx = Xr + W;
    var Cy = Yr - H; //since we are counting up from the top left corner the rectangle expands downwards

    if ((Xp-Ax)*(Xp-Cx) <= 0 && (Yp - Ay)*(Yp - Cy) <= 0)
        return true;

    return false;
}