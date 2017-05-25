using Binapsis.Plataforma.Configuracion;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Binapsis.Plataforma.Test.Estructura
{
    [TestClass]
    public class EvaluarConfiguracion
    {
        [TestMethod, TestCategory("Evaluar Configuracion")]
        public void EvaluarBaseType()
        {
            Tipo tipo = Types.Instancia.Obtener(typeof(string));
            Assert.AreEqual("String", tipo.Nombre);
            
        }
    }
}
