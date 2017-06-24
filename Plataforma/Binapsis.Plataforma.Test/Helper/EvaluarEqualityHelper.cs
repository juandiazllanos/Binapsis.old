using Microsoft.VisualStudio.TestTools.UnitTesting;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Helper;
using Binapsis.Plataforma.Helper.Impl;

namespace Binapsis.Plataforma.Test.Helper
{
    [TestClass]
    public class EvaluarEqualityHelper
    {
        [TestMethod, TestCategory("Evaluar EqualityHelper")]
        public void EvaluarObjetoDatosIgual()
        {
            ITipo tipo = HelperTipo.ObtenerTipo();
            IObjetoDatos od1 = TestHelper.Crear(tipo);
            TestHelper.Construir(od1, 1, 3);

            // copiar od
            ICopyHelper copy = new CopyHelper(TestHelper.Fabrica);
            IObjetoDatos od2 = copy.Copiar(od1);

            // comparar od
            IEqualityHelper helper = EqualityHelper.Instancia;

            bool igual = helper.Igual(od1, od2);

            Assert.IsTrue(igual);
        }

        [TestMethod, TestCategory("Evaluar EqualityHelper")]
        public void EvaluarObjetoDatosNoIgual()
        {
            ITipo tipo = HelperTipo.ObtenerTipo();
            IObjetoDatos od1 = TestHelper.Crear(tipo);
            TestHelper.Construir(od1, 1, 3);

            // copiar od
            ICopyHelper copy = new CopyHelper(TestHelper.Fabrica);
            IObjetoDatos od2 = copy.Copiar(od1);

            // modificar el od
            od1.EstablecerString("ReferenciaObjetoDatosItem[0]/atributoString", "nuevo valor");

            // comparar od
            IEqualityHelper helper = EqualityHelper.Instancia;

            bool igual = helper.Igual(od1, od2);

            Assert.IsFalse(igual);
        }
    }
}
