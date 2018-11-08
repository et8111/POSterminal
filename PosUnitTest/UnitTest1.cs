using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using POSterminal;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PosUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        //Commenting out because after using them i refactered the MATH() function and no longer need them

        //[TestMethod]
        //public void MATHFunctionIncrementTest()
        //{
        //    List<BounceHouse> testHouse = new List<BounceHouse>();
        //    testHouse.Add(new BounceHouse("test1", "", "", "", 1000.01, 5));
        //    BounceHouse.MATH(testHouse);
        //    Assert.AreEqual(6, GUI.Quantity);
        //}

        //[TestMethod]
        //public void MATHFunctionDecrementTest()
        //{
        //    GUI.Quantity = 1;
        //    List<BounceHouse> testHouse = new List<BounceHouse>();
        //    testHouse.Add(new BounceHouse("test1", "", "", "", 1000.01, 5));
        //    BounceHouse.MATH(testHouse);
        //    Assert.AreEqual(4, GUI.Quantity);
        //}

        //[TestMethod]
        //public void MATHFunctionMultiValueincrementTest()
        //{
        //    GUI.Quantity = 1;
        //    List<BounceHouse> testHouse = new List<BounceHouse>();
        //    testHouse.Add(new BounceHouse("test1", "", "", "", 1000.01, 5));
        //    testHouse.Add(new BounceHouse("test1", "", "", "", 1000.01, 6));
        //    BounceHouse.MATH(testHouse);
        //    Assert.AreEqual(12, GUI.Quantity);
        //}

        //[TestMethod]
        //public void MATHFunctionMultiValueDecrementTest()
        //{
        //    GUI.Quantity = 1;
        //    List<BounceHouse> testHouse = new List<BounceHouse>();
        //    testHouse.Add(new BounceHouse("test1", "", "", "", 1000.01, 5));
        //    testHouse.Add(new BounceHouse("test1", "", "", "", 1000.01, 6));
        //    BounceHouse.MATH(testHouse);
        //    Assert.AreEqual(10, GUI.Quantity);
        //}

        [TestMethod]
        public void MATHFunctionTaxIncrementTest()
        {
            GUI.Total = 0;
            List<BounceHouse> testHouse = new List<BounceHouse>();
            testHouse.Add(new BounceHouse("test1", "", "", "", 1000.01, 1));
            testHouse.Add(new BounceHouse("test1", "", "", "", 1000.01, 1));
            BounceHouse.MATH(testHouse);
            Assert.AreEqual(2120.02, Math.Round(GUI.Total,2));
        }

        [TestMethod]
        public void MATHFunctionTaxDecrementTest()
        {
            GUI.Total = 0;
            GUI.Quantity = 2;
            List<BounceHouse> testHouse = new List<BounceHouse>();
            testHouse.Add(new BounceHouse("test1", "", "", "", 1000.01, 0));
            testHouse.Add(new BounceHouse("test1", "", "", "", 1000.01, 1));
            BounceHouse.MATH(testHouse);
            Assert.AreEqual(1060.01, Math.Round(GUI.Total, 2));
        }
    }
}
