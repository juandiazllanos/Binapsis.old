using Microsoft.VisualStudio.TestTools.UnitTesting;
using Binapsis.Plataforma.AgenteConfiguracion;
using Binapsis.Plataforma.Configuracion;

namespace Binapsis.Plataforma.Test.Configuracion
{
    [TestClass]
    public class EvaluarAgenteConfiguracion
    {
        [TestMethod, TestCategory("Evaluar agente de configuracion")]
        public void RecuperarEnsamblado()
        {
            ServicioConfiguracion servicio = new ServicioConfiguracion("http://localhost:86/configuracion");
            Ensamblado ensam = servicio.ObtenerEnsamblado("System");

            Assert.IsNotNull(ensam);
            Assert.AreEqual("System", ensam.Nombre);
        }
    }
}
