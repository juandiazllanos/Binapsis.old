using Binapsis.Plataforma.Datos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Binapsis.Plataforma.Datos.SQLite;

namespace Binapsis.Plataforma.Test.Datos
{
    [TestClass]
    public class EvaluarDASSQLite : EvaluarDAS
    {
        public string CadenaConexion { get; } = "Filename=D:\\Data\\Binapsis\\test.db";

        public override IContexto ObtenerContexto()
        {
            return new ContextoSQLite(CadenaConexion);
        }

        [TestMethod, TestCategory("Evaluar servicio de acceso de datos SQLite")]
        public override void EvaluarDASDistrito()
        {
            base.EvaluarDASDistrito();
        }

        [TestMethod, TestCategory("Evaluar servicio de acceso de datos SQLite")]
        public override void EvaluarDASProvincia()
        {
            base.EvaluarDASProvincia();
        }

        [TestMethod, TestCategory("Evaluar servicio de acceso de datos SQLite")]
        public override void EvaluarDASDepartamento()
        {
            base.EvaluarDASDepartamento();
        }

        [TestMethod, TestCategory("Evaluar servicio de acceso de datos SQLite")]
        public override void EvaluarDASUbigeo()
        {
            base.EvaluarDASUbigeo();
        }

        [TestMethod, TestCategory("Evaluar servicio de acceso de datos SQLite")]
        public override void EvaluarDASCliente()
        {
            base.EvaluarDASCliente();
        }

        [TestMethod, TestCategory("Evaluar servicio de acceso de datos SQLite")]
        public override void EvaluarDASConsultaColeccion()
        {
            base.EvaluarDASConsultaColeccion();
        }

        [TestMethod, TestCategory("Evaluar servicio de acceso de datos SQLite")]
        public override void EvaluarDASConsultaComando()
        {
            base.EvaluarDASConsultaComando();
        }
    }
}
