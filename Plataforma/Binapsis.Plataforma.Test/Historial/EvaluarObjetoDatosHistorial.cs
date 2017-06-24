using Microsoft.VisualStudio.TestTools.UnitTesting;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Historial;
using Binapsis.Plataforma.Test.Historial.Helpers;
using Binapsis.Plataforma.Estructura.Impl;

namespace Binapsis.Plataforma.Test.Historial
{
    [TestClass]
    public class PruebaDecoradorHistorial
    {
        [TestMethod, TestCategory("Recuperacion de estado")]
        public void DeshacerCambiosEnObjetoDatos()
        {
            // arrange
            Log controlador = new Log();            
            IFabrica fabrica = new FabricaDatos(new FabricaHistorial(controlador));
            IObjetoDatos od = fabrica.Crear(HelperTipo.ObtenerTipo());

            // crear un estado
            Estado estado = new Estado(od);

            // establecer valores            
            TestHelper.Construir(od);

            // deshacer cambios 
            controlador.Deshacer();

            // evaluar
            Evaluar(od, estado);            
        }

        [TestMethod, TestCategory("Recuperacion de estado")]
        public void DeshacerCambiosEnObjetoDatosX()
        {
            Log controlador = new Log();            
            IFabrica fabrica = new FabricaDatos(new FabricaHistorial(controlador));
            IObjetoDatos od = fabrica.Crear(HelperTipo.ObtenerTipo2());

            // establecer valores
            TestHelper.Construir(od, 1, 2);

            // deshacer 
            controlador.Deshacer();

            Assert.IsNull(od.ObtenerObjetoDatos("ReferenciaObjetoDatos"));
            Assert.AreEqual(od.ObtenerColeccion("ReferenciaObjetoDatosItem").Longitud, 0);
        }

        [TestMethod, TestCategory("Recuperacion de estado")]
        public void RecuperarInstantaneaEnObjetoDatos()
        {
            Log log = new Log();
            IFabrica fabrica = new FabricaDatos(new FabricaHistorial(log));
            IObjetoDatos od = fabrica.Crear(HelperTipo.ObtenerTipo());
            var estado0 = new Estado(od);

            // establecer valores
            TestHelper.Construir(od); 

            // establecer punto de referencia
            var estado1 = new Estado(od);
            var instantanea1 = log.CrearInstantanea();
            // establecer valores
            TestHelper.Construir(od);

            var estado2 = new Estado(od);
            var instantanea2 = log.CrearInstantanea();
            TestHelper.Construir(od);

            var estado3 = new Estado(od);
            var instantanea3 = log.CrearInstantanea();
            TestHelper.Construir(od);

            var estado4 = new Estado(od);
            var instantanea4 = log.CrearInstantanea();
            TestHelper.Construir(od);

            // recuperar
            log.Recuperar(instantanea3);

            // evaluar 
            Evaluar(od, estado3);

            // recuperar
            log.Recuperar(instantanea1);

            // evaluar 
            Evaluar(od, estado1);

            // deshacer todo
            log.Deshacer();

            // evaluar 
            Evaluar(od, estado0);

        }

        [TestMethod, TestCategory("Recuperacion de estado")]
        public void RecuperarInstantaneaEnObjetoDatosX()
        {
            // arrange
            Log log = new Log();            
            IFabrica fabrica = new FabricaDatos(new FabricaHistorial(log));
            IObjetoDatos od = fabrica.Crear(HelperTipo.ObtenerTipo2());

            // act
            var instantanea1 = log.CrearInstantanea();
            od.CrearObjetoDatos("ReferenciaObjetoDatos");

            var instantanea2 = log.CrearInstantanea();
            od.CrearObjetoDatos("ReferenciaObjetoDatosItem");

            var instantanea3 = log.CrearInstantanea();
            od.CrearObjetoDatos("ReferenciaObjetoDatosItem");

            var instantanea4 = log.CrearInstantanea();
            od.CrearObjetoDatos("ReferenciaObjetoDatosItem[0]/ReferenciaObjetoDatos");

            var instantanea5 = log.CrearInstantanea();
            od.CrearObjetoDatos("ReferenciaObjetoDatosItem[1]/ReferenciaObjetoDatos");

            var valorBoolean = od.Obtener("atributoBoolean");
            var valorByte = od.Obtener("atributoByte");

            var instantanea6 = log.CrearInstantanea();
            od.EstablecerBoolean("ReferenciaObjetoDatosItem[1]/ReferenciaObjetoDatos/atributoBoolean", true);
            od.EstablecerByte("ReferenciaObjetoDatosItem[1]/ReferenciaObjetoDatos/atributoByte", byte.MaxValue);

            Assert.AreEqual(od.ObtenerBoolean("ReferenciaObjetoDatosItem[1]/ReferenciaObjetoDatos/atributoBoolean"), true);
            Assert.AreEqual(od.ObtenerByte("ReferenciaObjetoDatosItem[1]/ReferenciaObjetoDatos/atributoByte"), byte.MaxValue);

            // recuperar
            log.Recuperar(instantanea6);

            Assert.AreEqual(od.ObtenerBoolean("ReferenciaObjetoDatosItem[1]/ReferenciaObjetoDatos/atributoBoolean"), valorBoolean);
            Assert.AreEqual(od.ObtenerByte("ReferenciaObjetoDatosItem[1]/ReferenciaObjetoDatos/atributoByte"), valorByte);


            // recuperar
            log.Recuperar(instantanea5);
            
            Assert.IsNull(od.Obtener("ReferenciaObjetoDatosItem[1]/ReferenciaObjetoDatos"));

            // recuperar
            log.Recuperar(instantanea4);

            Assert.IsNull(od.Obtener("ReferenciaObjetoDatosItem[0]/ReferenciaObjetoDatos"));

            // recuperar
            log.Recuperar(instantanea3);

            Assert.AreEqual(od.ObtenerColeccion("ReferenciaObjetoDatosItem").Longitud, 1);

            // recuperar
            log.Recuperar(instantanea2);

            Assert.AreEqual(od.ObtenerColeccion("ReferenciaObjetoDatosItem").Longitud, 0);

            // recuperar
            log.Recuperar(instantanea1);

            Assert.IsNull(od.Obtener("ReferenciaObjetoDatos"));

        }

        private void Evaluar(IObjetoDatos od, Estado estado)
        {
            Assert.AreEqual(od.ObtenerBoolean("atributoBoolean"), estado.AtributoBoolean);
            Assert.AreEqual(od.ObtenerByte("atributoByte"), estado.AtributoByte);
            Assert.AreEqual(od.ObtenerChar("atributoChar"), estado.AtributoChar);
            Assert.AreEqual(od.ObtenerDateTime("atributoDateTime"), estado.AtributoDateTime);
            Assert.AreEqual(od.ObtenerDecimal("atributoDecimal"), estado.AtributoDecimal);
            Assert.AreEqual(od.ObtenerDouble("atributoDouble"), estado.AtributoDouble);
            Assert.AreEqual(od.ObtenerFloat("atributoFloat"), estado.AtributoFloat);
            Assert.AreEqual(od.ObtenerInteger("atributoInteger"), estado.AtributoInteger);
            Assert.AreEqual(od.ObtenerLong("atributoLong"), estado.AtributoLong);
            Assert.AreEqual(od.ObtenerSByte("atributoSByte"), estado.AtributoSByte);
            Assert.AreEqual(od.ObtenerShort("atributoShort"), estado.AtributoShort);
            Assert.AreEqual(od.ObtenerString("atributoString"), estado.AtributoString);
            Assert.AreEqual(od.ObtenerUInteger("atributoUInteger"), estado.AtributoUInteger);
            Assert.AreEqual(od.ObtenerULong("atributoULong"), estado.AtributoULong);
            Assert.AreEqual(od.ObtenerUShort("atributoUShort"), estado.AtributoUShort);
        }
    }

}
