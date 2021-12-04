using MathNet.Numerics.LinearAlgebra;

namespace SplineInterpolation
{
    internal class Interp1d
    {
        public struct SplineCoefficients
        {
            public double b1;
            public double d1;
            public double b2;
            public double c2;
            public double d2;
            public double b3;
            public double c3;
            public double d3;

            public SplineCoefficients(double b1, double d1, double b2, double c2, double d2, double b3, double c3, double d3)
            {
                this.b1 = b1;
                this.d1 = d1;
                this.b2 = b2;
                this.c2 = c2;
                this.d2 = d2;
                this.b3 = b3;
                this.c3 = c3;
                this.d3 = d3;
            }
        }

        public static SplineCoefficients ThreeSplines(double x1, double x2, double x3, double x4, double y1, double y2, double y3, double y4)
        {
            var A = Matrix<double>.Build.DenseOfArray(new double[,] {
                { (x2-x1), Math.Pow(x2-x1, 3.0), 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                { 0.0, 0.0, (x3-x2), Math.Pow(x3-x2, 2.0), Math.Pow(x3-x2, 3.0), 0.0, 0.0, 0.0 },
                { 0.0, 0.0, 0.0, 0.0, 0.0, (x4-x3), Math.Pow(x4-x3, 2.0), Math.Pow(x4-x3, 3.0) },
                { 1.0, 3*Math.Pow(x2-x1, 2.0), -1.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                { 0.0, 0.0, 1.0, 2.0*(x3-x2), 3.0*Math.Pow(x3-x2, 2.0), -1.0, 0.0, 0.0 },
                { 0.0, 6.0*(x2-x1), 0.0, -2.0, 0.0, 0.0, 0.0, 0.0 },
                { 0.0, 0.0, 0.0, 2.0, 6.0*(x3-x2), 0.0, -2.0, 0.0 },
                { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 2.0, 6.0*(x4-x3)}
            });

            var b = Vector<double>.Build.Dense(new double[] { (y2 - y1), (y3 - y2), (y4 - y3), 0.0, 0.0, 0.0, 0.0, 0.0 });
            var result = A.Solve(b);

            SplineCoefficients splineCoefficients = new SplineCoefficients(result[0], result[1], result[2], result[3], result[4], result[5], result[6], result[7]);

            return splineCoefficients;
        }
    }
}
