using Microsoft.VisualStudio.TestTools.UnitTesting;
using Binapsis.Plataforma.AgenteConfiguracion;
using Binapsis.Plataforma.Configuracion;
using System.Collections;

namespace Binapsis.Plataforma.Test.Configuracion
{
    [TestClass]
    public class EvaluarAgenteConfiguracion
    {
        string _url = "http://localhost:86/configuracion";

        [TestMethod, TestCategory("Evaluar servicio de configuracion")]
        public void RecuperarEnsamblado()
        {
            ServicioConfiguracion servicio = new ServicioConfiguracion(_url);
            Ensamblado ensam = servicio.ObtenerEnsamblado("System");

            Assert.IsNotNull(ensam);
            Assert.AreEqual("System", ensam.Nombre);
        }

        [TestMethod, TestCategory("Evaluar servicio de configuracion")]
        public void RecuperarTablaPorTipo()
        {
            ServicioConfiguracion servicio = new ServicioConfiguracion(_url);
            IList tablas = servicio.ObtenerTablas("Binapsis.Plataforma.Configuracion", "Ensamblado");

            Assert.AreEqual(1, tablas.Count);
            Assert.AreEqual("Ensamblado", (tablas[0] as Tabla).Nombre);
        }

        [TestMethod, TestCategory("Evaluar servicio de configuracion")]
        public void RecuperarRelaciones()
        {
            ServicioConfiguracion servicio = new ServicioConfiguracion(_url);
            IList items = servicio.ObtenerRelacionesPorTipo("Binapsis.Plataforma.Configuracion", "Tipo");

            foreach(Relacion item in items)
                Assert.AreEqual("Binapsis.Plataforma.Configuracion.Tipo", item.TipoAsociado);
                        
            items = servicio.ObtenerRelacionesPorTabla("Tipo", null);

            foreach (Relacion item in items)
                Assert.AreEqual("Tipo", item.TablaPrincipal);
        }
    }
}
