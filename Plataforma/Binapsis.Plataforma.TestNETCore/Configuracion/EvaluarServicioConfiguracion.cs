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
            //Ensamblado od = Fabrica.Instancia.Crear<Ensamblado>();
            //od.Nombre = "System.Pruebas";

            //ContextoInfo contextoInfo = new ContextoInfo();
            //contextoInfo.CadenaConexion = "Filename=D:\\Data\\Binapsis\\BinapsisConfig.db";
            //contextoInfo.Controlador = "SQLite";


            //EnsambladoController controller = new EnsambladoController(contextoInfo);
            //controller.Post(od);

            //Ensamblado od2 = controller.Get("System.Pruebas");
            
            //Assert.IsTrue(EqualityHelper.Instancia.Igual(od, od2));

            //od.Nombre = "System.Pruebas2";

            //controller.Put("System.Pruebas", od);

            //controller.Delete("System.Pruebas2");

        }
    }
}
