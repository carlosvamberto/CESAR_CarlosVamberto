using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace cesar.utils.test
{
    [TestClass]
    public class UtilsTest
    {
        [TestMethod]
        public void ReplacingCharacterTest()
        {
            string _text = "User is not allowed ";
            string _result = utils.Tools.ReplacingCharacters(_text, 19);
            Assert.IsTrue(_result.Equals("User&32is&32not&32allowed"));
        }

        [TestMethod]
        public void IsJumbledTest()
        {
            Assert.IsTrue(utils.Tools.IsJumbled("you", "yuo"));
            Assert.IsTrue(utils.Tools.IsJumbled("probably", "porbalby"));
            Assert.IsTrue(utils.Tools.IsJumbled("despite", "desptie"));
            Assert.IsFalse(utils.Tools.IsJumbled("moon", "nmoo"));
            Assert.IsFalse(utils.Tools.IsJumbled("misspellings", "mpeissngslli"));
        }

        [TestMethod]
        public void IsTypoTest()
        {
            Assert.IsTrue(Tools.IsTypo("pale", "ple"));
            Assert.IsTrue(Tools.IsTypo("pales", "pale"));
            Assert.IsTrue(Tools.IsTypo("pale", "bale"));
            Assert.IsFalse(Tools.IsTypo("pale", "bake"));
        }
    }
}
