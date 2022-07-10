using Microsoft.VisualStudio.TestTools.UnitTesting;
using Servicios.Colecciones.Enlazadas;
using System;

namespace Servicios.Colecciones
{
    [TestClass]
    public class uTestPilaEnlazada
    {
        #region Atributos de Prueba
        private clsPilaEnlazada<int> testTAD;
        private int[] testItems;
        private int testItem;
        #endregion

        #region Casos de prueba
        #region Constructores
        #region Constructor NO Parametrizado Por Defecto
        [TestMethod]
        public void uTestConstructorNoParametrizado()
        {
            #region Configurar
            #endregion
            #region Probar y Comprobar
            testTAD = new clsPilaEnlazada<int>();
            Assert.AreEqual(null, testTAD.darItems());
            Assert.AreEqual(0, testTAD.darLongitud());
            Assert.AreEqual(null, testTAD.darPrimero());
            Assert.AreEqual(null, testTAD.darUltimo());
            #endregion
        }
        #endregion
        #endregion
        #region Mutadores

        [TestMethod]
        public void uTestPonerItemsConLongitudCero()
        {
            #region Configurar
            testTAD = new clsPilaEnlazada<int>();
            testItems = new int[0];
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(false, testTAD.ponerItems(testItems));
            Assert.AreEqual(0, testTAD.darLongitud());
            Assert.AreEqual(null, testTAD.darPrimero());
            Assert.AreEqual(null, testTAD.darUltimo());
            #endregion
        }

        [TestMethod]
        public void uTestPonerItemsConLongitudNormal()
        {
            #region Configurar
            testTAD = new clsPilaEnlazada<int>();
            testItems = new int[3] { 1, 2, 3 };
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, testTAD.ponerItems(testItems));
            Assert.AreEqual(3, testTAD.darLongitud());
            Assert.AreEqual(3, testTAD.darItems().Length);
            CollectionAssert.AreEqual(testItems, testTAD.darItems());
            #endregion
        }

        #endregion
        #endregion



    }
}
