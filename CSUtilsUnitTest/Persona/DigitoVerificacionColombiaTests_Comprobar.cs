using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rectec.Utils.CSUtils.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rectec.Utils.CSUtilsUnitTest.Persona.Tests
{
    [TestClass()]
    public class DigitoVerificacionColombiaTests_Comprobar
    {
        #region Calcular String
        [TestMethod]
        [TestCategory("Comprobar String")]
        [TestCategory("Comprobar string con parametro")]
        [TestCategory("Comprobar string con parametro no esperado")]
        public void CDSNE_1()
        {
            var dv_real = DigitoVerificacionColombia.ComprobarDigito("900540587", 4);
            Assert.AreNotEqual(true, dv_real, "Valor no esperado");
        }

        [TestMethod]
        [TestCategory("Comprobar String")]
        [TestCategory("Comprobar string con parametro")]
        [TestCategory("Comprobar string con parametro esperado")]
        public void CDSE_1()
        {
            var dv_real = DigitoVerificacionColombia.ComprobarDigito("900540587", 2);
            Assert.AreEqual(true, dv_real, "Valor no esperado");
        }

        [TestMethod]
        [TestCategory("Comprobar String")]
        [TestCategory("Comprobar string con parametro")]
        [TestCategory("Comprobar string con parametro no esperado")]
        public void CSNE_2()
        {
            var dv_real = DigitoVerificacionColombia.ComprobarDigito("900.540.587", 4);
            Assert.AreNotEqual(true, dv_real, "Valor no esperado");
        }

        [TestMethod]
        [TestCategory("Comprobar String")]
        [TestCategory("Comprobar string con parametro")]
        [TestCategory("Comprobar string con parametro esperado")]
        public void CSE_2()
        {
            var dv_real = DigitoVerificacionColombia.ComprobarDigito("900.540.587", 2);
            Assert.AreEqual(true, dv_real, "Valor esperado");
        }

        [TestMethod]
        [TestCategory("Comprobar String")]
        [TestCategory("Comprobar string con parametro")]
        [TestCategory("Comprobar string con parametro no esperado")]
        public void CDSNE_3()
        {
            var dv_real = DigitoVerificacionColombia.ComprobarDigito("900-540-587", 4);
            Assert.AreNotEqual(true, dv_real, "Valor no esperado");
        }

        [TestMethod]
        [TestCategory("Comprobar String")]
        [TestCategory("Comprobar string con parametro")]
        [TestCategory("Comprobar string con parametro esperado")]
        public void CDSE_3()
        {
            var dv_real = DigitoVerificacionColombia.ComprobarDigito("900-540-587", 2);
            Assert.AreEqual(true, dv_real, "Valor esperado");
        }

        [TestMethod]
        [TestCategory("Comprobar String")]
        [TestCategory("Comprobar string con parametro")]
        [TestCategory("Comprobar string con parametro no esperado")]
        public void CDSNE_4()
        {
            var dv_real = DigitoVerificacionColombia.ComprobarDigito("900,540ñ587", 4);
            Assert.AreNotEqual(true, dv_real, "Valor no esperado");
        }

        [TestMethod]
        [TestCategory("Comprobar String")]
        [TestCategory("Comprobar string con parametro")]
        [TestCategory("Comprobar string con parametro esperado")]
        public void CDSE_4()
        {
            var dv_real = DigitoVerificacionColombia.ComprobarDigito("900,540ñ587", 2);
            Assert.AreEqual(true, dv_real, "Valor esperado");
        }

        [TestMethod]
        [TestCategory("Comprobar String")]
        [TestCategory("Comprobar string con parametro")]
        [TestCategory("Comprobar string con parametro no esperado")]
        public void CDSNE_5()
        {
            var dv_real = DigitoVerificacionColombia.ComprobarDigito("0", 4);
            Assert.AreNotEqual(true, dv_real, "Valor no esperado");
        }

        [TestMethod]
        [TestCategory("Comprobar String")]
        [TestCategory("Comprobar string con parametro")]
        [TestCategory("Comprobar string con parametro esperado")]
        public void CDSE_5()
        {
            var dv_real = DigitoVerificacionColombia.ComprobarDigito("0", 2);
            Assert.AreEqual(false, dv_real, "Valor esperado");
        }

        [TestMethod]
        [TestCategory("Comprobar String")]
        [TestCategory("Comprobar string con parametro")]
        [TestCategory("Comprobar string con parametro no esperado")]
        public void CDSNE_6()
        {
            var dv_real = DigitoVerificacionColombia.ComprobarDigito("a", 4);
            Assert.AreNotEqual(true, dv_real, "Valor no esperado");
        }

        [TestMethod]
        [TestCategory("Comprobar String")]
        [TestCategory("Comprobar string con parametro")]
        [TestCategory("Comprobar string con parametro esperado")]
        public void CDSE_6()
        {
            var dv_real = DigitoVerificacionColombia.ComprobarDigito("a", 2);
            Assert.AreEqual(false, dv_real, "Valor esperado");
        }

        [TestMethod]
        [TestCategory("Comprobar String")]
        [TestCategory("Comprobar string sin parametro")]
        [TestCategory("Comprobar string sin parametro no esperado")]
        public void CDSNE_7()
        {
            var dv_real = DigitoVerificacionColombia.ComprobarDigito("9005405878");
            Assert.AreNotEqual(true, dv_real, "Valor no esperado");
        }

        [TestMethod]
        [TestCategory("Comprobar String")]
        [TestCategory("Comprobar string sin parametro")]
        [TestCategory("Comprobar string sin parametro esperado")]
        public void CDSE_7()
        {
            var dv_real = DigitoVerificacionColombia.ComprobarDigito("9005405872");
            Assert.AreEqual(true, dv_real, "Valor esperado");
        }

        [TestMethod]
        [TestCategory("Comprobar String")]
        [TestCategory("Comprobar string sin parametro")]
        [TestCategory("Comprobar string sin parametro no esperado")]
        public void CDSNE_8()
        {
            var dv_real = DigitoVerificacionColombia.ComprobarDigito("900540587-3");
            Assert.AreNotEqual(true, dv_real, "Valor no esperado");
        }

        [TestMethod]
        [TestCategory("Comprobar String")]
        [TestCategory("Comprobar string sin parametro")]
        [TestCategory("Comprobar string sin parametro esperado")]
        public void CDSE_8()
        {
            var dv_real = DigitoVerificacionColombia.ComprobarDigito("900540587-2");
            Assert.AreEqual(true, dv_real, "Valor esperado");
        }

        [TestMethod]
        [TestCategory("Comprobar String")]
        [TestCategory("Comprobar string sin parametro")]
        [TestCategory("Comprobar string sin parametro no esperado")]
        public void CDSNE_9()
        {
            var dv_real = DigitoVerificacionColombia.ComprobarDigito("900.540.587-6");
            Assert.AreNotEqual(true, dv_real, "Valor no esperado");
        }

        [TestMethod]
        [TestCategory("Comprobar String")]
        [TestCategory("Comprobar string sin parametro")]
        [TestCategory("Comprobar string sin parametro esperado")]
        public void CDSE_9()
        {
            var dv_real = DigitoVerificacionColombia.ComprobarDigito("900.540.587-2");
            Assert.AreEqual(true, dv_real, "Valor esperado");
        }

        [TestMethod]
        [TestCategory("Comprobar String")]
        [TestCategory("Comprobar string sin parametro")]
        [TestCategory("Comprobar string sin parametro no esperado")]
        public void CDSNE_10()
        {
            var dv_real = DigitoVerificacionColombia.ComprobarDigito("36.000,000-8");
            Assert.AreNotEqual(true, dv_real, "Valor no esperado");
        }

        [TestMethod]
        [TestCategory("Comprobar String")]
        [TestCategory("Comprobar string sin parametro")]
        [TestCategory("Comprobar string sin parametro esperado")]
        public void CDSE_10()
        {
            var dv_real = DigitoVerificacionColombia.ComprobarDigito("36.000,000-1");
            Assert.AreEqual(true, dv_real, "Valor esperado");
        }
        #endregion
    }
}