using Calculate;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace TestProject
{
    public class UnitTest1
    {
        [Test]
        public void Test_Add_TwoPositiveNumbers_ReturnsCorrectResult()
        {
            double result = Calculator.Add(5, 7);
            Assert.AreEqual(12, result);
        }
       

       
    }
}