using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.Helper.Impl;
using Binapsis.Plataforma.ServicioConfiguracion;
using Binapsis.Plataforma.ServicioConfiguracion.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Binapsis.Plataforma.TestNETCore.Configuracion
{
    [TestClass]
    public class EvaluarServicioConfiguracion
    {        
        [TestMethod, TestCategory("Evaluar servicio de configuracion")]
        public void EvaluarEnsamblado()
        {
            IObjetoDatos od = FabricaDatos.Instancia.Crear(Types.Instancia.Obtener(typeof(Ensamblado)));
            od.Establecer("Nombre", "System");

            ContextoInfo contextoInfo = new ContextoInfo();
            contextoInfo.CadenaConexion = "Filename=D:\\Data\\Binapsis\\BinapsisConfig.db";
            contextoInfo.Controlador = "SQLite";

            EnsambladoController controller = new EnsambladoController(contextoInfo);
            controller.Post(od);

            IObjetoDatos od2 = controller.Get("System");
            
            Assert.IsTrue(EqualityHelper.Instancia.Igual(od, od2));

            od.Establecer("Nombre", "System2");

            controller.Put("System", od);

            controller.Delete("System2");

        }
    }
}
