using Microsoft.VisualStudio.TestTools.UnitTesting;
using static VowelsTestConsole.Program;

namespace VowelsTestConsole.UnitTest
{
    [TestClass]
    public class VowelsUnitTest
    {
        [TestMethod]
        public void GetnumberOfVowelsUnitTest()
        {
            //arrange 
            var results = new Vowel();
            //act 
            var data = results.GetNumberOfVowels("siyabonga");
            //assert
            Assert.AreNotEqual(data > 0, data);

        }

        [TestMethod]
        public void GetnumberOfNonVowelslsUnitTest()
        {
            //arrange 
            var nonVowel = new NonVowel();
            //act 
            var result = nonVowel.GetNumberOfNoneVowels("siyabonga");
            //assert
            Assert.AreNotEqual(result > 0, result);

        }


        [TestMethod]
        public void GetnumberOfDuplicateUnitTest()
        {
            //arrange 
            var duplicate = new Duplicate();
            //act 
            var result = duplicate.CheckDuplicates("siyabonga");
            //assert
            Assert.IsNotNull(result, "found duplicates  in the  sentence");

        }

        [TestMethod]
        public void ProcessingOperationUnitTest() {

            //arrange 
            var results = new ProcessingOperation();
            //act 
             results.DisplayMessage(10,11);
            //assert
      
        }


    }
}
