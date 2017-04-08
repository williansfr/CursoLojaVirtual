using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Willians.LojaVirtual.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Take()
        {
            int[] lista = { 9, 8, 7, 6, 5, 4, 3 };

            var numeros = from i in lista.Take(3) select i;

            int[] itens = { 9, 8, 5 };

            CollectionAssert.AreEqual(numeros.ToArray(), itens);
        }
    }
}
