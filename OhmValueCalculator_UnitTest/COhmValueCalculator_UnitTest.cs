using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OhmValueCalculator;

namespace OhmValueCalculator_UnitTest
{
    [TestClass]
    public class COhmValueCalculator_UnitTest
    {
        public COhmValueCalculator m_OhmValueCalculator;
        public COhmValueCalculator_UnitTest()
        {
            m_OhmValueCalculator = new COhmValueCalculator();
        }
        [TestMethod]
        public void TestEmptyValue()
        {
            float fToleranceRange1;
            float fOhmValue1= m_OhmValueCalculator.CalculateOhmValue(string.Empty, "Black", "Green", "", out fToleranceRange1);
            Assert.IsTrue(fToleranceRange1<float.Epsilon && float.IsNaN(fOhmValue1));

            float fToleranceRange2;
            float fOhmValue2 = m_OhmValueCalculator.CalculateOhmValue("Black", string.Empty, "Green", "Red", out fToleranceRange2);
            Assert.IsTrue(fToleranceRange2 < float.Epsilon && float.IsNaN(fOhmValue2));

            float fToleranceRange3;
            float fOhmValue3 = m_OhmValueCalculator.CalculateOhmValue("Black", "Green", string.Empty, "Red", out fToleranceRange3);
            Assert.IsTrue(fToleranceRange3 < float.Epsilon && float.IsNaN(fOhmValue3));
        }
        [TestMethod]
        public void TestInvalidValue()
        {
            float fToleranceRange1;
            float fOhmValue1 = m_OhmValueCalculator.CalculateOhmValue("123", "Black", "Green", "", out fToleranceRange1);
            Assert.IsTrue(fToleranceRange1 < float.Epsilon && float.IsNaN(fOhmValue1));

            float fToleranceRange2;
            float fOhmValue2 = m_OhmValueCalculator.CalculateOhmValue("Black", "Test", "Green", "Red", out fToleranceRange2);
            Assert.IsTrue(fToleranceRange2 < float.Epsilon && float.IsNaN(fOhmValue2));

            float fToleranceRange3;
            float fOhmValue3 = m_OhmValueCalculator.CalculateOhmValue("Black", "Green", "!@%", "Red", out fToleranceRange3);
            Assert.IsTrue(fToleranceRange3 < float.Epsilon && float.IsNaN(fOhmValue3));
        }
        [TestMethod]
        public void Test_BlackBlackBlackGold()
        {
            float fToleranceRange;
            float fOhmValue = m_OhmValueCalculator.CalculateOhmValue("Black", "BLACK", "Black", "gold", out fToleranceRange);
            Assert.IsTrue(Math.Abs(fToleranceRange-0.05f) < float.Epsilon && fOhmValue < float.Epsilon);
        }

        [TestMethod]
        public void Test_WhiteWhiteWhiteBrown()
        {
            float fToleranceRange;
            float fOhmValue = m_OhmValueCalculator.CalculateOhmValue("white", "WHITE", "whITE", "brown", out fToleranceRange);
            Assert.IsTrue(Math.Abs(fToleranceRange - 0.01f) < float.Epsilon && Math.Abs(fOhmValue - 99000000000.0f) < float.Epsilon);
        }

        [TestMethod]
        public void Test_VioletGrayPinkEmpty()
        {
            float fToleranceRange;
            float fOhmValue = m_OhmValueCalculator.CalculateOhmValue("VIOLET", "gray", "pink", "", out fToleranceRange);
            Assert.IsTrue(Math.Abs(fToleranceRange - 0.2f) < float.Epsilon && Math.Abs(fOhmValue - 0.078f) < float.Epsilon);
        }

        [TestMethod]
        public void Test_GreenOrangeBlueSilver()
        {
            float fToleranceRange;
            float fOhmValue = m_OhmValueCalculator.CalculateOhmValue("green", "ORANGE", "bluE", "sILVer", out fToleranceRange);
            Assert.IsTrue(Math.Abs(fToleranceRange - 0.1f) < float.Epsilon && Math.Abs(fOhmValue - 53000000.0f) < float.Epsilon);
        }

        [TestMethod]
        public void Test_BrownGreenYellowViolet()
        {
            float fToleranceRange;
            float fOhmValue = m_OhmValueCalculator.CalculateOhmValue("brown", "GreEn", "YelloW", "VIOLET", out fToleranceRange);
            Assert.IsTrue(Math.Abs(fToleranceRange - 0.001f) < float.Epsilon && Math.Abs(fOhmValue - 150000.0f) < float.Epsilon);
        }
    }
}
