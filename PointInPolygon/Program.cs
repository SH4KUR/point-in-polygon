//
// https://alienryderflex.com/polygon/
// https://stackoverflow.com/questions/4243042/c-sharp-point-in-polygon
//

Console.WriteLine("Point In Polygon\n");

#region GeoJSON example

//{
//  "type": "FeatureCollection",
//  "features": [
//    {
//      "type": "Feature",
//      "properties": {},
//      "geometry": {
//        "coordinates": [
//          [
//            [
//              -74.00659682587926,
//              40.737334256194856
//            ],
//            [
//              -74.00288133502359,
//              40.72553834390834
//            ],
//            [
//              -73.99562392020486,
//              40.71824328211642
//            ],
//            [
//              -73.9772434912679,
//              40.722353222202145
//            ],
//            [
//              -73.98008340387665,
//              40.74067896665571
//            ],
//            [
//              -74.00659682587926,
//              40.737334256194856
//            ]
//          ],
//          [
//            [
//              -73.99485478500729,
//              40.73144395163217
//            ],
//            [
//              -73.98539428169381,
//              40.733513166474125
//            ],
//            [
//              -73.98441991421186,
//              40.72471673113796
//            ],
//            [
//              -73.99370334067399,
//              40.72528758670313
//            ],
//            [
//              -73.99485478500729,
//              40.73144395163217
//            ]
//          ],
//          [
//            [
//              -74.003954031972,
//              40.735885581234925
//            ],
//            [
//              -73.99776128128958,
//              40.735885581234925
//            ],
//            [
//              -73.99776128128958,
//              40.73421727480496
//            ],
//            [
//              -74.003954031972,
//              40.73421727480496
//            ],
//            [
//              -74.003954031972,
//              40.735885581234925
//            ]
//          ],
//          [
//            [
//              -73.99879790259692,
//              40.723698596630584
//            ],
//            [
//              -74.00239440362373,
//              40.731367648753405
//            ],
//            [
//              -73.99892946049677,
//              40.7327942810974
//            ],
//            [
//              -73.9979651208199,
//              40.72912063160595
//            ],
//            [
//              -73.99705928557736,
//              40.72547717066436
//            ],
//            [
//              -73.99896454007687,
//              40.72652000088743
//            ],
//            [
//              -73.99879790259692,
//              40.723698596630584
//            ]
//          ]
//        ],
//        "type": "Polygon"
//      }
//    },
//    {
//      "type": "Feature",
//      "properties": {},
//      "geometry": {
//        "coordinates": [
//          -73.9890201007582,
//          40.73013326038043
//        ],
//        "type": "Point"
//      }
//    },
//    {
//      "type": "Feature",
//      "properties": {},
//      "geometry": {
//        "coordinates": [
//          -73.98917989840878,
//          40.73467450893244
//        ],
//        "type": "Point"
//      }
//    },
//    {
//      "type": "Feature",
//      "properties": {},
//      "geometry": {
//        "coordinates": [
//          -73.99824569052173,
//          40.73528496479037
//        ],
//        "type": "Point"
//      }
//    },
//    {
//      "type": "Feature",
//      "properties": {},
//      "geometry": {
//        "coordinates": [
//          -73.99592472494311,
//          40.727982468373796
//        ],
//        "type": "Point"
//      }
//    },
//    {
//      "type": "Feature",
//      "properties": {},
//      "geometry": {
//        "coordinates": [
//          -73.99858841132297,
//          40.72569966768063
//        ],
//        "type": "Point"
//      }
//    },
//    {
//      "type": "Feature",
//      "properties": {},
//      "geometry": {
//        "coordinates": [
//          -73.99768842359245,
//          40.726323420600494
//        ],
//        "type": "Point"
//      }
//    }
//  ]
//}

#endregion

var coordinates = new Coordinate[]
{
    new(-74.00659682587926, 40.737334256194856),
    new(-74.00288133502359, 40.72553834390834),
    new(-73.99562392020486, 40.71824328211642),
    new(-73.9772434912679, 40.722353222202145),
    new(-73.98008340387665, 40.74067896665571),
    new(-74.00659682587926, 40.737334256194856),
    new(-73.99485478500729, 40.73144395163217),
    new(-73.99370334067399, 40.72528758670313),
    new(-73.98441991421186, 40.72471673113796),
    new(-73.98539428169381, 40.733513166474125),
    new(-73.99485478500729, 40.73144395163217),

    new(-74.003954031972, 40.735885581234925),
    new(-74.003954031972, 40.73421727480496),
    new(-73.99776128128958, 40.73421727480496),
    new(-73.99776128128958, 40.735885581234925),
    new(-74.003954031972, 40.735885581234925),

    new(-73.99879790259692, 40.723698596630584),
    new(-73.99896454007687, 40.72652000088743),
    new(-73.99705928557736, 40.72547717066436),
    new(-73.9979651208199, 40.72912063160595),
    new(-73.99892946049677, 40.7327942810974),
    new(-74.00239440362373, 40.731367648753405),
    new(-73.99879790259692, 40.723698596630584),
};

var pointIn1 = new Coordinate(-73.98917989840878, 40.73467450893244);
var pointIn2 = new Coordinate(-73.99592472494311, 40.727982468373796);
var pointIn3 = new Coordinate(-73.99858841132297, 40.72569966768063);

Console.WriteLine($"{nameof(pointIn1)} - {IsInPolygon(pointIn1, coordinates)}");
Console.WriteLine($"{nameof(pointIn2)} - {IsInPolygon(pointIn2, coordinates)}");
Console.WriteLine($"{nameof(pointIn3)} - {IsInPolygon(pointIn3, coordinates)}");

var pointOut1 = new Coordinate(-73.9890201007582, 40.73013326038043);
var pointOut2 = new Coordinate(-73.99824569052173, 40.73528496479037);
var pointOut3 = new Coordinate(-73.99768842359245, 40.726323420600494);

Console.WriteLine($"{nameof(pointOut1)} - {IsInPolygon(pointOut1, coordinates)}");
Console.WriteLine($"{nameof(pointOut2)} - {IsInPolygon(pointOut2, coordinates)}");
Console.WriteLine($"{nameof(pointOut3)} - {IsInPolygon(pointOut3, coordinates)}");

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
    public Coordinate(double x, double y)
    {
        X = x;
        Y = y;
    }

    public double X { get; }
    public double Y { get; }
}