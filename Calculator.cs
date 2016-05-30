using System;


namespace Test3
{
    public static class Calculator
    {
        /// <summary>
        /// Sort the values (v1 <= v2 <= v3)
        /// </summary>
        public static void SortValues(ref double v1, ref double v2, ref double v3)
        {
            if (v1 > v2)
                Swap(ref v1, ref v2);
            if (v2 > v3)
                Swap(ref v2, ref v3);
            if (v1 > v2)
                Swap(ref v1, ref v2);
        }


        /// <summary>
        /// Exchange the values
        /// </summary>
        public static void Swap<T>(ref T lhs, ref T rhs)
        {
            T tmp = lhs;
            lhs = rhs;
            rhs = tmp;
        }


        /// <summary>
        /// Calculate the area of a triangle whose sides have lengths a, b, and c.
        /// </summary>
        public static double TriangleArea(double a, double b, double c)
        {
            // Длина не может быть отрицательной
            if (a < 0)
                throw new ArgumentOutOfRangeException("a", a, "a is negative");
            if (b < 0)
                throw new ArgumentOutOfRangeException("a", b, "b is negative");
            if (c < 0)
                throw new ArgumentOutOfRangeException("a", c, "c is negative");

            // Сумма 2-х сторон не может быть больше 3ей
            if (a > b + c || b > a + c || c > a + b)
                throw new ArgumentException("This triangle does not exist");

            // Heron's formula (Numerical stability)
            // https://en.wikipedia.org/wiki/Heron%27s_formula

            // sort a >= b >= c
            SortValues(ref c, ref b, ref a);

            // Calculate area
            double area = Math.Sqrt((a + (b + c)) * (c - (a - b)) * (c + (a - b)) * (a + (b - c))) / 4.0d;
            return area;
        }
    }
}
