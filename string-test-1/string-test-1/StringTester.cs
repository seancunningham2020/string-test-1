using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using NUnit.Framework;

namespace string_test_1
{
    public class StringTester
    {
        public IList<string> DivideString(string rawString, int stringLength)
        {
            var returnList = new List<string>();

            if ((rawString == string.Empty) || (!rawString.Contains(" ")))
            {
                returnList.Add(rawString);
                return returnList;
            }

            char[] stringArray = rawString.ToCharArray();
            var stringBuilder = new StringBuilder();

            for (var i = 0; i < stringArray.Length; i++)
            {
                if (stringBuilder.Length <= (stringLength - 1))
                {
                    stringBuilder.Append(rawString[i]);
                }
                else
                {
                    returnList.Add(stringBuilder.ToString());
                    stringBuilder = new StringBuilder();
                }
            }

            return returnList;
        }
    }

    [TestFixture]
    public class StringTesterTests
    {
        [Test]
        public void DivideString_EmptyString_ReturnsEmptyList()
        {
            var stringTester = new StringTester();

            var result = stringTester.DivideString(string.Empty, 1);

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(string.Empty, result[0]);
        }

        [Test]
        public void DivideString_OneWordNoSpaces_ReturnsList()
        {
            var stringTester = new StringTester();

            var result = stringTester.DivideString("String", 3);

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("String", result[0]);
        }

        [Test]
        public void DivideString_TwoWordsWithSpace_ReturnsList()
        {
            var stringTester = new StringTester();

            var result = stringTester.DivideString("String Again", 3);

            Assert.AreEqual("String", result[0]);
            Assert.AreEqual("Again", result[1]);
            Assert.AreEqual(2, result.Count);
        }
    }
}