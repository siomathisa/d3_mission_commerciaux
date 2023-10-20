using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using libCommerciaux;

namespace UnitTestCommerciaux
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        //Arranger:
            Commercial c;
            NoteFrais f0, f1;
            c = new Commercial("Jean", "Dupond", "A", 25);

        //Agir:
            f0 = new NoteFrais(1, new DateTime(2022, 11, 12), c);
            f1 = new NoteFrais(2, new DateTime(2022, 11, 15), c);

        //Auditer:
            Assert.AreEqual(2, c.GetMesNoteFrais().Count);

        }
    }
}
