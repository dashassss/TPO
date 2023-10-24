using  Calculate;
namespace TestProject1
{
    public class Tests
    {

        [Test]
        public void TestAddition()
        {
            double result = Calculator.Add(5, 7);
            Assert.AreEqual(12, result);
        }

        [Test]
        public void TestSubtraction()
        {
            double result = Calculator.Subtract(10, 3);
            Assert.AreEqual(7, result);
        }
        [Test]
        public void TestMultiply()
        {
            double result = Calculator.Multiply(5, 3);
            Assert.AreEqual(15, result);
        }
        [Test]
        public void TestDivide()
        {
            double result = Calculator.Divide(15, 3);
            Assert.AreEqual(5, result);
        }

        [Test]
        public void TestDivideByZero()
        {
            double result = Calculator.Divide(15, 0);
            Assert.AreEqual(5, result);
        }

        [Test]
        public void TestMultiplyByZero()
        {
            double result = Calculator.Multiply(15, 0);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void TestMixedOperations()
        {
            double result = Calculator.Add(5, 10);
            result = Calculator.Subtract(result, 3);
            result = Calculator.Divide(result, 2);
            Assert.AreEqual(6, result);
        }

        [Test]
        public void TestAddNegativeNumbers()
        {
            double result = Calculator.Add(-15, -3);
            Assert.AreEqual(-18, result);
        }


        [Test]
        public void TestMultiplyNegativeNumbers()
        {
            double result = Calculator.Multiply(-1, -5);
            Assert.AreEqual(5, result);
        }
        [Test]
        public void TestDivideNegativeNumbers()
        {
            double result = Calculator.Divide(-80, -5);
            Assert.AreEqual(16, result);
        }



    }
}