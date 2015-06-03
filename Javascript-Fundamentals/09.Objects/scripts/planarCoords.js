//Write functions for working with shapes in standard Planar coordinate system.
//Points are represented by coordinates P(X, Y)
//Lines are represented by two points, marking their beginning and ending L(P1(X1,Y1), P2(X2,Y2))
//Calculate the distance between two points.
//Check if three segment lines can form a triangle.

planarCoordsTest();

function planarCoordsTest() {
    var pointObj1 = createPoint(2, 9),
        pointObj2 = createPoint(5, -4),
        line = createLine(pointObj1, pointObj2),
        line2 = createLine(createPoint(6, 12), createPoint(3, 10)),
        line3 = createLine(createPoint(-6, 3), createPoint(4, 2));

    var triangleInequalityCheck = canFormTriangle(line, line2, line3);

    console.log('Distance between the two points of a line: ' + line.distance);

    console.log('The lines with lengths ' + line.distance + ', ' + line2.distance + ', ' + line3.distance +
        ' can form a triangle?: ' + triangleInequalityCheck);
}

function createPoint(X, Y) {
    return {x: X, y: Y}
}

function createLine(point1, point2) {
    return {p1: point1, p2: point2, distance: calcDistance(point1, point2)}
}

function calcDistance(point1, point2) {
    return (Math.sqrt(((point1.x - point2.x)*(point1.x - point2.x)) + ((point1.y - point2.y)*(point1.y - point2.y))))
}

function canFormTriangle(line1, line2, line3) {
    var d1 = line1.distance,
        d2 = line2.distance,
        d3 = line3.distance;

    if (d1 > d2 + d3 || d2 > d1 + d3 || d3 > d1 + d2) {
        return false;
    }
    return true;
}