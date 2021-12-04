using SplineInterpolation;

// 4 точки соединяются 3 сплайнами:
// S1 = a1 + b1*(x-x1) + c1*(x-x1)**2 + d1*(x-x1)**3
// S2 = a2 + b2*(x-x2) + c2*(x-x2)**2 + d2*(x-x2)**3
// S3 = a3 + b3*(x-x3) + c1*(x-x3)**2 + d3*(x-x3)**3

var x = Interp1d.ThreeSplines(1, 2, 4, 7, 2, 3, 1, 4);

Console.WriteLine(x.b1);
Console.WriteLine(x.d1);
Console.WriteLine(x.b2);
Console.WriteLine(x.c2);
Console.WriteLine(x.d2);
Console.WriteLine(x.b3);
Console.WriteLine(x.c3);
Console.WriteLine(x.d3);

// a1 = y1
// a2 = y2
// a3 = y3
// c1 = 0


