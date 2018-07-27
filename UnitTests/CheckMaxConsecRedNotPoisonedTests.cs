using Microsoft.VisualStudio.TestTools.UnitTesting;
using FunctionalProgrammingAndLINQ;
using FunctionalProgrammingAndLINQ.Solutions;
using System.Collections.Generic;
using System.Linq;
using System;

namespace UnitTests
{
    [TestClass]
    public class CheckMaxConsecRedNotPoisonedTests
    {
        [TestMethod]
        public void MaxConsecRedNotPoisonedSolutionsAreEqualRand()
        {
            var applePicker = new ApplePicker(true);
            Random rnd = new Random();
            List<Apple> apples = applePicker.PickApples().Take(rnd.Next(10000,30000)).ToList();

            var maxConsecRedNotPoisonedForEach = new MaxConsecRedNotPoisoned(apples, MaxConsecRedNotPoisoned.Methods.ForEach);
            var maxConsecRedNotPoisonedLinq = new MaxConsecRedNotPoisoned(apples, MaxConsecRedNotPoisoned.Methods.LINQ);
            var maxConsecRedNotPoisonedLinq2 = new MaxConsecRedNotPoisoned(apples, MaxConsecRedNotPoisoned.Methods.LINQ2);
            var maxConsecRedNotPoisonedLinq3 = new MaxConsecRedNotPoisoned(apples, MaxConsecRedNotPoisoned.Methods.LINQ3);

            Assert.AreEqual(maxConsecRedNotPoisonedForEach.Result, maxConsecRedNotPoisonedLinq.Result);
            Assert.AreEqual(maxConsecRedNotPoisonedLinq2.Result, maxConsecRedNotPoisonedLinq3.Result);
            Assert.AreEqual(maxConsecRedNotPoisonedForEach.Result, maxConsecRedNotPoisonedLinq2.Result);
        }

        [TestMethod]
        public void CheckMaxConsecNotPoisonedForEach()
        {
            var applePicker = new ApplePicker();
            List<Apple> apples = applePicker.PickApples().Take(10000).ToList();

            var maxConsecRedNotPoisoned = new MaxConsecRedNotPoisoned(apples, MaxConsecRedNotPoisoned.Methods.ForEach);
            Assert.AreEqual(maxConsecRedNotPoisoned.Result, 10);
        }

        [TestMethod]
        public void CheckMaxConsecNotPoisonedLinq1()
        {
            var applePicker = new ApplePicker();
            List<Apple> apples = applePicker.PickApples().Take(10000).ToList();

            var maxConsecRedNotPoisoned = new MaxConsecRedNotPoisoned(apples, MaxConsecRedNotPoisoned.Methods.LINQ);
            Assert.AreEqual(maxConsecRedNotPoisoned.Result, 10);
        }

        [TestMethod]
        public void CheckMaxConsecNotPoisonedLinq2()
        {
            var applePicker = new ApplePicker();
            List<Apple> apples = applePicker.PickApples().Take(10000).ToList();

            var maxConsecRedNotPoisoned = new MaxConsecRedNotPoisoned(apples, MaxConsecRedNotPoisoned.Methods.LINQ2);
            Assert.AreEqual(maxConsecRedNotPoisoned.Result, 10);
        }

        [TestMethod]
        public void CheckMaxConsecNotPoisonedLinq3()
        {
            var applePicker = new ApplePicker();
            List<Apple> apples = applePicker.PickApples().Take(10000).ToList();

            var maxConsecRedNotPoisoned = new MaxConsecRedNotPoisoned(apples, MaxConsecRedNotPoisoned.Methods.LINQ3);
            Assert.AreEqual(maxConsecRedNotPoisoned.Result, 10);
        }
    }
}
