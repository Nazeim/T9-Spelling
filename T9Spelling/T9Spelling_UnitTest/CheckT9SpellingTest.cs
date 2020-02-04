using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using T9Spelling;

namespace T9Spelling_UnitTest
{
    [TestClass]
    public class CheckT9SpellingTest
    {
        [TestMethod]
        public void repeatChars_a_and2_returned_aa()
        {
            // arrange
            string expected = "aa";

            // act
            CheckT9Spelling ch = new CheckT9Spelling();
            PrivateObject obj = new PrivateObject(ch);

            string p1 = "a"; 
            int p2 = 2; 
            object[] args = new object[2] { p1, p2 };

            var retVal = obj.Invoke("repeatChars", args);
            
            // assert
            Assert.AreEqual(expected, retVal);

        }

        [TestMethod]
        public void getPattern_foo_bar_return_443_377()
        {
            // arrange
            string input = "foo bar";
            string expected = "333666 666022 2777";

            // act
            CheckT9Spelling ch = new CheckT9Spelling();
            ch.buildDictionary();

            string actual = ch.getPattern(input);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
