using Microsoft.VisualStudio.TestTools.UnitTesting;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Notificaciones.Impl;
using Binapsis.Plataforma.Notificaciones.Impl.Extension;
using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.Test.Notificacion.Impl;
using Evaluar = Binapsis.Plataforma.Test.EvaluarComparacionObjetoDatos;

namespace Binapsis.Plataforma.Test.Notificacion
{
    [TestClass]
    public class EvaluarObservadorObjetoDatos
    {
        [TestMethod, TestCategory("Evaluar Notificaciones")]
        public void ObservarObjetoDatos()
        {
            IFabrica fabrica = new FabricaNotificacion();
            IObjetoDatos od1 = Helper.Crear(HelperTipo.ObtenerTipo2(), fabrica);
            IObjetoDatos od2 = Helper.Crear(HelperTipo.ObtenerTipo2());

            Observable observable = ((ObjetoBase)od1).Observable();
            Observador observador = new Observador(od2);

            observable.Agregar(observador);

            Helper.Construir(od1, 2, 5);

            Evaluar.Comparar(od1, od2);

            od1.RemoverObjetoDatos("ReferenciaObjetoDatosItem", od1.ObtenerColeccion("ReferenciaObjetoDatosItem")[4]);
            od1.RemoverObjetoDatos("ReferenciaObjetoDatosItem", od1.ObtenerColeccion("ReferenciaObjetoDatosItem")[3]);
            od1.RemoverObjetoDatos("ReferenciaObjetoDatosItem", od1.ObtenerColeccion("ReferenciaObjetoDatosItem")[2]);
            od1.RemoverObjetoDatos("ReferenciaObjetoDatosItem", od1.ObtenerColeccion("ReferenciaObjetoDatosItem")[1]);
            od1.RemoverObjetoDatos("ReferenciaObjetoDatosItem", od1.ObtenerColeccion("ReferenciaObjetoDatosItem")[0]);

            od1.RemoverObjetoDatos("ReferenciaObjetoDatos/ReferenciaObjetoDatosItem", od1.ObtenerColeccion("ReferenciaObjetoDatos/ReferenciaObjetoDatosItem")[4]);
            od1.RemoverObjetoDatos("ReferenciaObjetoDatos/ReferenciaObjetoDatosItem", od1.ObtenerColeccion("ReferenciaObjetoDatos/ReferenciaObjetoDatosItem")[3]);
            od1.RemoverObjetoDatos("ReferenciaObjetoDatos/ReferenciaObjetoDatosItem", od1.ObtenerColeccion("ReferenciaObjetoDatos/ReferenciaObjetoDatosItem")[2]);
            od1.RemoverObjetoDatos("ReferenciaObjetoDatos/ReferenciaObjetoDatosItem", od1.ObtenerColeccion("ReferenciaObjetoDatos/ReferenciaObjetoDatosItem")[1]);
            od1.RemoverObjetoDatos("ReferenciaObjetoDatos/ReferenciaObjetoDatosItem", od1.ObtenerColeccion("ReferenciaObjetoDatos/ReferenciaObjetoDatosItem")[0]);

            Evaluar.Comparar(od1, od2);

            od1.EstablecerObjetoDatos("ReferenciaObjetoDatos", null);
            od1.EstablecerObjetoDatos("ReferenciaObjetoDatos2", null);

            Evaluar.Comparar(od1, od2);
        }

        //[TestMethod]
        //void CompararObjetoDatos(IObjetoDatos od1, IObjetoDatos od2)
        //{
        //    Assert.AreEqual(od1.ObtenerInteger("atributoId"), od2.ObtenerInteger("atributoId"));
        //    Assert.AreEqual(od1.ObtenerByte("atributoBoolean"), od2.ObtenerByte("atributoBoolean"));
        //    Assert.AreEqual(od1.ObtenerByte("atributoByte"), od2.ObtenerByte("atributoByte"));
        //    Assert.AreEqual(od1.ObtenerChar("atributoChar"), od2.ObtenerChar("atributoChar"));
        //    Assert.AreEqual(od1.ObtenerDateTime("atributoDateTime").Date, od2.ObtenerDateTime("atributoDateTime").Date);
        //    Assert.AreEqual(od1.ObtenerDateTime("atributoDateTime").Hour, od2.ObtenerDateTime("atributoDateTime").Hour);
        //    Assert.AreEqual(od1.ObtenerDateTime("atributoDateTime").Minute, od2.ObtenerDateTime("atributoDateTime").Minute);
        //    Assert.AreEqual(od1.ObtenerDateTime("atributoDateTime").Second, od2.ObtenerDateTime("atributoDateTime").Second);
        //    Assert.AreEqual(od1.ObtenerDecimal("atributoDecimal"), od2.ObtenerDecimal("atributoDecimal"));
        //    Assert.AreEqual(od1.ObtenerDouble("atributoDouble"), od2.ObtenerDouble("atributoDouble"));
        //    Assert.AreEqual(od1.ObtenerFloat("atributoFloat"), od2.ObtenerFloat("atributoFloat"));
        //    Assert.AreEqual(od1.ObtenerInteger("atributoInteger"), od2.ObtenerInteger("atributoInteger"));
        //    Assert.AreEqual(od1.ObtenerLong("atributoLong"), od2.ObtenerLong("atributoLong"));
        //    Assert.AreEqual(od1.ObtenerSByte("atributoSByte"), od2.ObtenerSByte("atributoSByte"));
        //    Assert.AreEqual(od1.ObtenerShort("atributoShort"), od2.ObtenerShort("atributoShort"));
        //    Assert.AreEqual(od1.ObtenerString("atributoString"), od2.ObtenerString("atributoString"));
        //    Assert.AreEqual(od1.ObtenerUShort("atributoUShort"), od2.ObtenerUShort("atributoUShort"));
        //    Assert.AreEqual(od1.ObtenerUInteger("atributoUInteger"), od2.ObtenerUInteger("atributoUInteger"));
        //    Assert.AreEqual(od1.ObtenerULong("atributoULong"), od2.ObtenerULong("atributoULong"));

        //    Assert.AreEqual(od1.ObtenerObjetoDatos("ReferenciaObjetoDatos") != null, od2.ObtenerObjetoDatos("ReferenciaObjetoDatos") != null);
        //    Assert.AreEqual(od1.ObtenerColeccion("ReferenciaObjetoDatosItem").Longitud, od2.ObtenerColeccion("ReferenciaObjetoDatosItem").Longitud);

        //    if (od1.ObtenerObjetoDatos("ReferenciaObjetoDatos") != null && od2.ObtenerObjetoDatos("ReferenciaObjetoDatos") != null)
        //        CompararObjetoDatos(od1.ObtenerObjetoDatos("ReferenciaObjetoDatos"), od2.ObtenerObjetoDatos("ReferenciaObjetoDatos"));

        //    for (int i = 0; i < od1.ObtenerColeccion("ReferenciaObjetoDatosItem").Longitud; i++)
        //    {
        //        CompararObjetoDatos(od1.ObtenerColeccion("ReferenciaObjetoDatosItem")[i], od2.ObtenerColeccion("ReferenciaObjetoDatosItem")[i]);
        //    }



        //    // compracion tipo2
        //    if (od1.Tipo.ObtenerPropiedad("ReferenciaObjetoDatos2") == null) return;

        //    Assert.AreEqual(od1.ObtenerObjetoDatos("ReferenciaObjetoDatos2") != null, od2.ObtenerObjetoDatos("ReferenciaObjetoDatos2") != null);

        //    if (od1.ObtenerObjetoDatos("ReferenciaObjetoDatos2") != null && od2.ObtenerObjetoDatos("ReferenciaObjetoDatos2") != null)
        //        CompararObjetoDatos(od1.ObtenerObjetoDatos("ReferenciaObjetoDatos2"), od2.ObtenerObjetoDatos("ReferenciaObjetoDatos2"));



        //    // comparacion tipo 3
        //    if (od1.Tipo.ObtenerPropiedad("ReferenciaObjetoDatosItem2") == null) return;

        //    Assert.AreEqual(od1.ObtenerObjetoDatos("ReferenciaObjetoDatosItem2") != null, od2.ObtenerObjetoDatos("ReferenciaObjetoDatosItem2") != null);

        //    if (od1.ObtenerObjetoDatos("ReferenciaObjetoDatosItem2") != null)
        //    {
        //        Assert.AreEqual(od1.ObtenerObjetoDatos("ReferenciaObjetoDatosItem2"), od1.ObtenerObjetoDatos("ReferenciaObjetoDatosItem[0]"));
        //        Assert.AreEqual(od2.ObtenerObjetoDatos("ReferenciaObjetoDatosItem2"), od2.ObtenerObjetoDatos("ReferenciaObjetoDatosItem[0]"));
        //    }
        //}
    }
}
