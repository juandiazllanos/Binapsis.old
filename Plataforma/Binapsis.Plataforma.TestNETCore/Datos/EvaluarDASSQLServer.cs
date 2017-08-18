using System;
using Binapsis.Plataforma.Datos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Binapsis.Plataforma.Datos.SQLServer;

namespace Binapsis.Plataforma.Test.Datos
{
    [TestClass]
    public class EvaluarDASSQLServer : EvaluarDAS
    {
        public string CadenaConexion { get; } = "data source=localhost\\sql2014; initial catalog=binapsisDatos; integrated security=true; MultipleActiveResultSets=true";

        public override IContexto ObtenerContexto()
        {
            return new ContextoSQLServer(CadenaConexion);
        }

        [TestMethod, TestCategory("Evaluar servicio de acceso de datos SQLServer")]
        public override void EvaluarDASDistrito()
        {
            base.EvaluarDASDistrito();
        }

        [TestMethod, TestCategory("Evaluar servicio de acceso de datos SQLServer")]
        public override void EvaluarDASProvincia()
        {
            base.EvaluarDASProvincia();
        }

        [TestMethod, TestCategory("Evaluar servicio de acceso de datos SQLServer")]
        public override void EvaluarDASDepartamento()
        {
            base.EvaluarDASDepartamento();
        }

        [TestMethod, TestCategory("Evaluar servicio de acceso de datos SQLServer")]
        public override void EvaluarDASUbigeo()
        {
            base.EvaluarDASUbigeo();
        }

        [TestMethod, TestCategory("Evaluar servicio de acceso de datos SQLServer")]
        public override void EvaluarDASCliente()
        {
            base.EvaluarDASCliente();
        }

        [TestMethod, TestCategory("Evaluar servicio de acceso de datos SQLServer")]
        public override void EvaluarDASConsultaColeccion()
        {
            base.EvaluarDASConsultaColeccion();
        }

        [TestMethod, TestCategory("Evaluar servicio de acceso de datos SQLServer")]
        public override void EvaluarDASConsultaComando()
        {
            base.EvaluarDASConsultaComando();
        }

        [TestMethod, TestCategory("Evaluar servicio de acceso de datos SQLServer")]
        public override void EvaluarDASComando()
        {
            base.EvaluarDASComando();
        }

    }
}
