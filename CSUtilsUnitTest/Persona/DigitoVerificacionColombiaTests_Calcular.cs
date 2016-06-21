using Rectec.Utils.CSUtils.Persona;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rectec.Utils.CSUtilsUnitTest.Persona.Tests
{
    [TestClass()]
    public class DigitoVerificacionColombiaTests_Calcular
    {
        #region Calcular String
        [TestMethod]
        [TestCategory("Calcular String")]
        [TestCategory("Calcular string no esperado")]
        public void CSNE_1()
        {
            var dv_real = DigitoVerificacionColombia.Calcular("900540587");
            Assert.AreNotEqual(0, dv_real, "Valor no esperado");
        }

        [TestMethod]
        [TestCategory("Calcular String")]
        [TestCategory("Calcular string esperado")]
        //[Ignore]
        public void CSE_1()
        {
            var dv_real = DigitoVerificacionColombia.Calcular("900540587");
            Assert.AreEqual(2, dv_real, "Valor esperado");
        }

        [TestMethod]
        [TestCategory("Calcular String")]
        [TestCategory("Calcular string no esperado")]
        public void CSNE_2()
        {
            var dv_real = DigitoVerificacionColombia.Calcular("900.540.587");
            Assert.AreNotEqual(0, dv_real, "Valor no esperado");
        }

        [TestMethod]
        [TestCategory("Calcular String")]
        [TestCategory("Calcular string esperado")]
        public void CSE_2()
        {
            var dv_real = DigitoVerificacionColombia.Calcular("900.540.587");
            Assert.AreEqual(2, dv_real, "Valor esperado");
        }

        [TestMethod]
        [TestCategory("Calcular String")]
        [TestCategory("Calcular string no esperado")]
        public void CSNE_3()
        {
            var dv_real = DigitoVerificacionColombia.Calcular("900-540-587");
            Assert.AreNotEqual(0, dv_real, "Valor no esperado");
        }

        [TestMethod]
        [TestCategory("Calcular String")]
        [TestCategory("Calcular string esperado")]
        public void CSE_3()
        {
            var dv_real = DigitoVerificacionColombia.Calcular("900-540-587");
            Assert.AreEqual(2, dv_real, "Valor esperado");
        }

        [TestMethod]
        [TestCategory("Calcular String")]
        [TestCategory("Calcular string no esperado")]
        public void CSNE_4()
        {
            var dv_real = DigitoVerificacionColombia.Calcular("900,540ñ587");
            Assert.AreNotEqual(0, dv_real, "Valor no esperado");
        }

        [TestMethod]
        [TestCategory("Calcular String")]
        [TestCategory("Calcular string esperado")]
        public void CSE_4()
        {
            var dv_real = DigitoVerificacionColombia.Calcular("900,540ñ587");
            Assert.AreEqual(2, dv_real, "Valor esperado");
        }

        [TestMethod]
        [TestCategory("Calcular String")]
        [TestCategory("Calcular string no esperado")]
        public void CSNE_5()
        {
            var dv_real = DigitoVerificacionColombia.Calcular("0");
            Assert.AreNotEqual(0, dv_real, "Valor no esperado");
        }

        [TestMethod]
        [TestCategory("Calcular String")]
        [TestCategory("Calcular string esperado")]
        public void CSE_5()
        {
            var dv_real = DigitoVerificacionColombia.Calcular("0");
            Assert.AreEqual(null, dv_real, "Valor esperado");
        }

        [TestMethod]
        [TestCategory("Calcular String")]
        [TestCategory("Calcular string no esperado")]
        public void CSNE_6()
        {
            var dv_real = DigitoVerificacionColombia.Calcular("a");
            Assert.AreNotEqual(0, dv_real, "Valor no esperado");
        }

        [TestMethod]
        [TestCategory("Calcular String")]
        [TestCategory("Calcular string esperado")]
        public void CSE_6()
        {
            var dv_real = DigitoVerificacionColombia.Calcular("a");
            Assert.AreEqual(null, dv_real, "Valor esperado");
        }
        #endregion

        #region Calcular decimal
        [TestMethod]
        [TestCategory("Calcular decimal")]
        [TestCategory("Calcular decimal no esperado")]
        public void CDNE_1()
        {
            var dv_real = DigitoVerificacionColombia.Calcular(900540587);
            Assert.AreNotEqual(0, dv_real, "Valor no esperado");
        }

        [TestMethod]
        [TestCategory("Calcular decimal")]
        [TestCategory("Calcular decimal esperado")]
        public void CDE_1()
        {
            var dv_real = DigitoVerificacionColombia.Calcular(900540587);
            Assert.AreEqual(2, dv_real, "Valor esperado");
        }

        [TestMethod]
        [TestCategory("Calcular decimal")]
        [TestCategory("Calcular decimal no esperado")]
        public void CDNE_2()
        {
            var dv_real = DigitoVerificacionColombia.Calcular(0);
            Assert.AreNotEqual(2, dv_real, "Valor esperado");
        }

        [TestMethod]
        [TestCategory("Calcular decimal")]
        [TestCategory("Calcular decimal esperado")]
        public void CDE_2()
        {
            var dv_real = DigitoVerificacionColombia.Calcular(0);
            Assert.AreEqual(null, dv_real, "Valor esperado");
        }

        #endregion
    }
}

