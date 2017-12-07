using Microsoft.VisualStudio.TestTools.UnitTesting;
using FunctionalProgrammingAndLINQ;
using FunctionalProgrammingAndLINQ.Solutions;
using System.Collections.Generic;
using System.Linq;
using System;

namespace UnitTests
{
    [TestClass]
    public class CheckNumberOfTimesGreenSucceedsGreen
    {
        [TestMethod]
        public void CheckRandResultsAreEqual()
        {
            var applePicker = new ApplePicker(true);
            List<Apple> apples = applePicker.PickApples().Take(10000).ToList();

            var numberOfTimesGreenSucceedsGreenLinq = new NumberOfTimesGreenSucceedsGreen(apples, NumberOfTimesGreenSucceedsGreen.Methods.LINQ);
            var numberOfTimesGreenSucceedsGreenForEach = new NumberOfTimesGreenSucceedsGreen(apples, NumberOfTimesGreenSucceedsGreen.Methods.ForEach);
            Assert.AreEqual(numberOfTimesGreenSucceedsGreenLinq.Result, numberOfTimesGreenSucceedsGreenForEach.Result);
        }
        [TestMethod]
        public void CheckNumberOfTimesGreenSucceedsGreenForEach()
        {
            var applePicker = new ApplePicker();
            List<Apple> apples = applePicker.PickApples().Take(10000).ToList();

            var numberOfTimesGreenSucceedsGreen = new NumberOfTimesGreenSucceedsGreen(apples, NumberOfTimesGreenSucceedsGreen.Methods.LINQ);
            Assert.AreEqual(numberOfTimesGreenSucceedsGreen.Result, 53);
        }
        [TestMethod]
        public void CheckNumberOfTimesGreenSucceedsGreenLinq()
        {
            var applePicker = new ApplePicker();
            List<Apple> apples = applePicker.PickApples().Take(10000).ToList();

            var numberOfTimesGreenSucceedsGreen = new NumberOfTimesGreenSucceedsGreen(apples, NumberOfTimesGreenSucceedsGreen.Methods.ForEach);
            Assert.AreEqual(numberOfTimesGreenSucceedsGreen.Result, 53);
        }
    }
}
