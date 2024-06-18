//
// https://alienryderflex.com/polygon/
// https://stackoverflow.com/questions/4243042/c-sharp-point-in-polygon
//

Console.WriteLine("Point In Polygon\n");

var coordinates = new Coordinate[]
{
    new(10, 10),
    new(10, 5),
    new(5, 10),
    new(5, 5),
    new(4, 4)
};

Console.WriteLine(IsInPolygon(new Coordinate(7, 7), coordinates));

bool IsInPolygon(Coordinate point, IReadOnlyList<Coordinate> polygon)
{
    var inside = false;

    var x = point.X;
    var y = point.Y;

    var j = polygon.Count - 1;
    for (var i = 0; i < polygon.Count; i++)
    {
        var xi = polygon[i].X;
        var yi = polygon[i].Y;
        var xj = polygon[j].X;
        var yj = polygon[j].Y;

        if (yi < y && yj >= y || yj < y && yi >= y)
        {
            if (xi + (y - yi) / (yj - yi) * (xj - xi) < x)
            {
                inside = !inside;
            }
        }

        j = i;
    }

    return inside;
}

public struct Coordinate
{
    public Coordinate(decimal x, decimal y)
    {
        X = x;
        Y = y;
    }

    public decimal X { get; }
    public decimal Y { get; }
}