using System;
using NUnit.Framework;
using GeometricFigures;


namespace UnitTestProject3
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestSquareArea(
            [Range(0, 20, 1)] int i)
        {
            if (i == 0)
                Assert.Throws<ArgumentException>(() => new Square(0), "Квадрат не существует");
            Square a = new Square(i);
            double expected = i * i;
            double actual = a.getAreaSquare();            
            Assert.IsTrue(expected == actual, "Ошибка на входном значении " + i + ". Должно быть " + expected + ", метод вернул " + actual);
        }
        [Test]
        public void TestSquareLength(
            [Range(0, 20, 1)] int i)
        {
            if (i == 0)
                Assert.Throws<ArgumentException>(() => new Square(0), "Квадрат не существует");
            Square a = new Square(i);
            double expected = i * 4;
            double actual = a.getLengthSquare();
            Assert.IsTrue(expected == actual, "Ошибка на входном значении " + i + ". Должно быть " + expected + ", метод вернул " + actual);
        }
        [Test, Combinatorial]
        public void TestTriangleArea(   // Никита, вопрос. Почему на некоторых значениях(например, 10,1,10) значение expected в выводимом сообщении об ошибке показывает неправильно(0). не смог разобраться в чем дело. Глюк VS?
            [Range(0, 20, 1)] int i,
            [Range(0, 20, 1)] int j,
            [Range(0, 20, 1)] int k)
        {
            if (((i + j) > k) & ((i + k) > j) & ((k + j) > i))
            {
                Triangle a = new Triangle(i, j, k);
                double p = (i + j + k) / 2;
                double expected = Math.Sqrt(p * (p - i) * (p - j) * (p - k));
                double actual = a.getAreaTriangle();
                Assert.IsTrue(expected == actual, "Ошибка на входном значении " + "i=" + i + " j=" + j + " k=" + k + ". Должно быть " + expected + ", метод вернул " + actual);
            }
            else
            {
                Assert.Throws<ArgumentException>(() => new Triangle(i, j, k), "Треугольник не существует");
            }
        }
        [Test, Combinatorial]
        public void TestTriangleLength(
            [Range(0, 20, 1)] int i,
            [Range(0, 20, 1)] int j,
            [Range(0, 20, 1)] int k)
        {
            if (((i + j) > k) & ((i + k) > j) & ((k + j) > i))
            {
                Triangle a = new Triangle(i, j, k);
                double expected = i + j + k;
                double actual = a.getLengthTriangle();
                Assert.IsTrue(expected == actual, "Ошибка на входном значении " + "i=" + i + " j=" + j + " k=" + k + ". Должно быть " + expected + ", метод вернул " + actual);
            }
            else
            {
                Assert.Throws<ArgumentException>(() => new Triangle(i, j, k), "Треугольник не существует");
            }
        }
        [Test]
        public void TestCircleLength(
            [Range(0, 20, 1)] int r)
        {
            if (r == 0)
                Assert.Throws<ArgumentException>(() => new Circle(0), "Окружность не существует");
            Circle a = new Circle(r);
            double expected = r * 2 * Math.PI;
            double actual = a.getLengthCircle();
            Assert.IsTrue(expected == actual, "Ошибка на входном значении " + r + ". Должно быть " + expected + ", метод вернул " + actual);
        }
        [Test]
        public void TestCircleArea(
            [Range(0, 20, 1)] int r)
        {
            if (r == 0)
                Assert.Throws<ArgumentException>(() => new Circle(0), "Круг не существует");
            Circle a = new Circle(r);
            double expected = r * r * Math.PI;
            double actual = a.getAreaCircle();
            Assert.IsTrue(expected == actual, "Ошибка на входном значении " + r + ". Должно быть " + expected + ", метод вернул " + actual);
        }
    }
}
