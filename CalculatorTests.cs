using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace Test3.Tests
{
    [TestClass()]
    public class CalculatorTests
    {
        [TestMethod()]
        public void SortValuesTest()
        {
            double accuracy = 0d;
            var testDatas = new[]
            {
                new { v1 = 1d, v2 = 2d, v3 = 3d, v1_expected = 1d, v2_expected = 2d, v3_expected = 3d },
                new { v1 = 1d, v2 = 3d, v3 = 2d, v1_expected = 1d, v2_expected = 2d, v3_expected = 3d },
                new { v1 = 2d, v2 = 1d, v3 = 3d, v1_expected = 1d, v2_expected = 2d, v3_expected = 3d },
                new { v1 = 2d, v2 = 3d, v3 = 1d, v1_expected = 1d, v2_expected = 2d, v3_expected = 3d },
                new { v1 = 3d, v2 = 1d, v3 = 2d, v1_expected = 1d, v2_expected = 2d, v3_expected = 3d },
                new { v1 = 3d, v2 = 2d, v3 = 1d, v1_expected = 1d, v2_expected = 2d, v3_expected = 3d },
                new { v1 = 1d, v2 = 1d, v3 = 1d, v1_expected = 1d, v2_expected = 1d, v3_expected = 1d },
                new { v1 = 1.000001d, v2 = 1.0000001d, v3 = 1.00000001d, v1_expected = 1.00000001d, v2_expected = 1.0000001d, v3_expected = 1.000001d },
            };

            foreach (var data in testDatas)
            {
                var v1 = data.v1;
                var v2 = data.v2;
                var v3 = data.v3;
                Calculator.SortValues(ref v1, ref v2, ref v3);

                Assert.AreEqual(data.v1_expected, v1, accuracy, "Calculator.SortValues - incorrect");
                Assert.AreEqual(data.v2_expected, v2, accuracy, "Calculator.SortValues - incorrect");
                Assert.AreEqual(data.v3_expected, v3, accuracy, "Calculator.SortValues - incorrect");
            }
        }


        [TestMethod()]
        public void SwapTest()
        {
            double accuracy = 0d;
            var testDatas = new[]
            {
                new { v1 = 1.0d, v2 = 2.0d },
                new { v1 = 22.0d, v2 = 11.0d },
                new { v1 = 0.0d, v2 = 0.0d },
                new { v1 = -1.0d, v2 = -2.0d },
                new { v1 = -9999.0d, v2 = 9999.0d },
            };
            foreach (var data in testDatas)
            {
                double v1 = data.v1,
                       v2 = data.v2,
                       v1_expected = data.v2,
                       v2_expected = data.v1;
                Calculator.Swap(ref v1, ref v2);

                Assert.AreEqual(v1_expected, v1, accuracy, "Calculator.Swap - incorrect");
                Assert.AreEqual(v2_expected, v2, accuracy, "Calculator.Swap - incorrect");
            }
        }


        [TestMethod()]
        public void TriangleAreaTest()
        {
            double accuracy = 0.0000000000000001d;
            var testDatas = new[]
            {
                new { a = 1d, b = 1d, c = 1d, area_expected = 0.43301270189221932338186158537647d },
                new { a = 1d, b = 1d, c = Math.Sqrt(2), area_expected = 0.5d },
                new { a = 1d, b = 1d, c = 2d, area_expected = 0d },
                new { a = 1.1180339887498948482045868343656d, b = 1.1180339887498948482045868343656d, c = 1d, area_expected = 0.5d },
            };

            foreach (var data in testDatas)
            {
                var area = Calculator.TriangleArea(data.a, data.b, data.c);

                Assert.AreEqual(data.area_expected, area, accuracy, "Calculator.TriangleArea - incorrect");
            }
        }


        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TriangleAreaTest2()
        {
            Calculator.TriangleArea(-1d, 1d, 1d);
        }


        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void TriangleAreaTest3()
        {
            Calculator.TriangleArea(1d, 1d, 3d);
        }
    }
}