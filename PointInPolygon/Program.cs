Console.WriteLine("Point In Polygon\n");

var polygon = new Coordinate[]
{
    new(10, 10),
    new(10, 5),
    new(5, 10),
    new(5, 5),
    new(4, 4)
};

Console.WriteLine(IsInPolygon1(new Coordinate(4.5m, 4.5m), polygon));
Console.WriteLine(IsInPolygon11(new Coordinate(4.5m, 4.5m), polygon));
Console.WriteLine(IsInPolygon2(new Coordinate(4.5m, 4.5m), polygon));

bool IsInPolygon1(Coordinate point, Coordinate[] polygon)
{
    var inside = false;

    int j = polygon.Length - 1;
    for (int i = 0; i < polygon.Length; i++)
    {
        if (polygon[i].Y < point.Y && polygon[j].Y >= point.Y || polygon[j].Y < point.Y && polygon[i].Y >= point.Y)
        {
            if (polygon[i].X + (point.Y - polygon[i].Y) / (polygon[j].Y - polygon[i].Y) * (polygon[j].X - polygon[i].X) < point.X)
            {
                inside = !inside;
            }
        }
        j = i;
    }

    return inside;
}

bool IsInPolygon11(Coordinate point, Coordinate[] polygon)
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

bool IsInPolygon2(Coordinate point, Coordinate[] polygon)
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

        var intersect = ((yi > y) != (yj > y)) && (x < (xj - xi) * (y - yi) / (yj - yi) + xi);
        if (intersect)
        {
            inside = !inside;
        }

        j = i;
    }

    return inside;
}

public record Coordinate(decimal X, decimal Y);
