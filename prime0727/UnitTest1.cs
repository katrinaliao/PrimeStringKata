using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace prime0727
{
    [TestClass]
    public class UnitTest1
    {
        public bool IsStringPrime(string inputString)
        {
            if (inputString.Length<=2)
            {
                return true;
            }

            var factors = FactorsList(inputString.Length);

            foreach (var facStr in factors)
            {
                var strElement = SeparateStringByFactorLength(inputString, facStr);
                var strAreEqual = strElement.All(s => s.Contains(strElement[0]));
                if (strAreEqual)
                {
                    return false;
                }
            }
            return true;
        }

        private static List<string> SeparateStringByFactorLength(string inputString, int lengthOfFactor)
        {
            List<string> strList = new List<string>();
            string x;
            int i = 0;
            while (i < inputString.Length - 1)
            {
                x = inputString.Substring(i, lengthOfFactor);
                strList.Add(x);
                i = i + lengthOfFactor;
            }

            return strList;
        }

        private static List<int> FactorsList(int number)
        {
            List<int> factors = new List<int>();
            int max = (int)Math.Sqrt(number);
            for (int factor = 1; factor <= max; ++factor)
            {
                if (number % factor == 0)
                {
                    factors.Add(factor);
                    if (factor != number / factor)
                    {
                        factors.Add(number / factor);
                    }
                }
            }
            factors.Sort();
            factors.Remove(factors[0]);
            factors.Remove(factors.Last());
            return factors;
        }    

        [TestMethod]
        public void x_shoulReturnTrue()
        {
            var str = "x";
            var result = IsStringPrime(str);
            var expected = true;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void xy_shoulReturnTrue()
        {
            var str = "xy";
            var result = IsStringPrime(str);
            var expected = true;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void abc_shoulReturnTrue()
        {
            var str = "abc";
            var result = IsStringPrime(str);
            var expected = true;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void abcabc_shoulReturnFalse()
        {
            var str = "abcabc";
            var result = IsStringPrime(str);
            var expected = false;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void abcdabcdabcd_shoulReturnFalse()
        {
            var str = "abcdabcdabcd";
            var result = IsStringPrime(str);
            var expected = false;

            Assert.AreEqual(expected, result);
        }
    }
}
