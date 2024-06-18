//
// https://alienryderflex.com/polygon/
// https://stackoverflow.com/questions/4243042/c-sharp-point-in-polygon
//

Console.WriteLine("Point In Polygon\n");

var polygon = new Coordinate[]
{
    new(10, 10),
    new(10, 5),
    new(5, 10),
    new(5, 5),
    new(4, 4)
};

Console.WriteLine(IsInPolygon(new Coordinate(7, 7), polygon));

bool IsInPolygon(Coordinate point, Coordinate[] polygon)
{
    var inside = false;

    var x = point.X;
    var y = point.Y;

    int j = polygon.Length - 1;
    for (int i = 0; i < polygon.Length; i++)
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

public record Coordinate(decimal X, decimal Y);