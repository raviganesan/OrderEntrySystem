using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderEntrySystem;
using OrderEntrySystem.Classes;
using OrderEntrySystem.BusinessLogic.BusinessRules;

namespace OrderEntryTest
{
    [TestClass]
    public class UnitTestUserInputValidationManager
    {
        IUserInputValidationManager iUserInputValidationManager = new UserInputValidationManager();
        [TestMethod]
        public void ValidateTimeOfDay()
        {
            bool actual = iUserInputValidationManager.ValidateTimeOfDay("morning");
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ValidateTimeOfDayError()
        {
            bool actual = iUserInputValidationManager.ValidateTimeOfDay("morningser");
            //Msg: Enter valid time of day :(morning or night)! is thrown
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ValidateDishSelection()
        {
            bool actual = iUserInputValidationManager.ValidateDishSelection("morning, 1");
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ValidateDishSelectionError()
        {
            bool actual = iUserInputValidationManager.ValidateDishSelection("morning");
            //Msg: You must enter a comma between dish types with at least one selection! is thrown
            Assert.IsTrue(actual);
        }
    }

    [TestClass]
    public class DishRulesTest
    {
        public DishRulesTest()
        {
            iOrderEntryRules = new OrderEntryRules();
            dishRules = new DishRules(iOrderEntryRules);
        }

        IOrderEntryRules iOrderEntryRules;
        IDishRules dishRules;

        [TestMethod]
        public void SetDesertServingRule()
        {
           bool actual = dishRules.SetDesertServingRule();
           Assert.IsTrue(actual);
        }

        [TestMethod]
        public void SetMultipleServingRule()
        {
            bool actual = dishRules.SetMultipleServingRule();
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ApplySortRule()
        {
            int[] target = new int[] { 1, 2, 3, 4, 5 };
            int[] actual = dishRules.ApplySortRule(new int[] {4,5,3,1,2});
            CollectionAssert.AreEqual(target, actual);

        }

        [TestMethod]
        public void VerifyMultipleServing()
        {
            bool actual = dishRules.VerifyMultipleServing(3, 1, 5); //int dishTypeId, int timeOfDayId, int itemId
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void VerifyDesertServing()
        {
            bool actual = dishRules.VerifyDesertServing(1, 2);//int dishTypeId, int timeOfDayId
            Assert.IsTrue(actual);
        }
    }
}
