using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Binapsis.Plataforma.AgenteConfiguracion;
using Binapsis.Plataforma.Configuracion;

namespace Binapsis.Plataforma.Test.Configuracion
{
    [TestClass]
    public class EvaluarAgenteConfiguracion
    {
        [TestMethod]
        public void RecuperarEnsamblado()
        {
            ServicioConfiguracion servicio = new ServicioConfiguracion("http://localhost:86/configuracion");
            Ensamblado ensam = servicio.ObtenerEnsamblado("System");

            Assert.IsNotNull(ensam);
            Assert.AreEqual("System", ensam.Nombre);
        }
    }
}
