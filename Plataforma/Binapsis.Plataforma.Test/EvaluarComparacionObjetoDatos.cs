using Microsoft.VisualStudio.TestTools.UnitTesting;
using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Test
{
    [TestClass]
    public static class EvaluarComparacionObjetoDatos
    {
        [TestMethod]
        public static void Comparar(IObjetoDatos od1, IObjetoDatos od2)
        {
            Assert.AreEqual(od1.ObtenerInteger("atributoId"), od2.ObtenerInteger("atributoId"));
            Assert.AreEqual(od1.ObtenerByte("atributoBoolean"), od2.ObtenerByte("atributoBoolean"));
            Assert.AreEqual(od1.ObtenerByte("atributoByte"), od2.ObtenerByte("atributoByte"));
            Assert.AreEqual(od1.ObtenerChar("atributoChar"), od2.ObtenerChar("atributoChar"));
            Assert.AreEqual(od1.ObtenerDateTime("atributoDateTime").Date, od2.ObtenerDateTime("atributoDateTime").Date);
            Assert.AreEqual(od1.ObtenerDateTime("atributoDateTime").Hour, od2.ObtenerDateTime("atributoDateTime").Hour);
            Assert.AreEqual(od1.ObtenerDateTime("atributoDateTime").Minute, od2.ObtenerDateTime("atributoDateTime").Minute);
            Assert.AreEqual(od1.ObtenerDateTime("atributoDateTime").Second, od2.ObtenerDateTime("atributoDateTime").Second);
            Assert.AreEqual(od1.ObtenerDecimal("atributoDecimal"), od2.ObtenerDecimal("atributoDecimal"));
            Assert.AreEqual(od1.ObtenerDouble("atributoDouble"), od2.ObtenerDouble("atributoDouble"));
            Assert.AreEqual(od1.ObtenerFloat("atributoFloat"), od2.ObtenerFloat("atributoFloat"));
            Assert.AreEqual(od1.ObtenerInteger("atributoInteger"), od2.ObtenerInteger("atributoInteger"));
            Assert.AreEqual(od1.ObtenerLong("atributoLong"), od2.ObtenerLong("atributoLong"));
            Assert.AreEqual(od1.ObtenerSByte("atributoSByte"), od2.ObtenerSByte("atributoSByte"));
            Assert.AreEqual(od1.ObtenerShort("atributoShort"), od2.ObtenerShort("atributoShort"));
            Assert.AreEqual(od1.ObtenerString("atributoString"), od2.ObtenerString("atributoString"));
            Assert.AreEqual(od1.ObtenerUShort("atributoUShort"), od2.ObtenerUShort("atributoUShort"));
            Assert.AreEqual(od1.ObtenerUInteger("atributoUInteger"), od2.ObtenerUInteger("atributoUInteger"));
            Assert.AreEqual(od1.ObtenerULong("atributoULong"), od2.ObtenerULong("atributoULong"));

            Assert.AreEqual(od1.ObtenerObjetoDatos("ReferenciaObjetoDatos") != null, od2.ObtenerObjetoDatos("ReferenciaObjetoDatos") != null);
            Assert.AreEqual(od1.ObtenerColeccion("ReferenciaObjetoDatosItem").Longitud, od2.ObtenerColeccion("ReferenciaObjetoDatosItem").Longitud);

            if (od1.ObtenerObjetoDatos("ReferenciaObjetoDatos") != null && od2.ObtenerObjetoDatos("ReferenciaObjetoDatos") != null)
                Comparar(od1.ObtenerObjetoDatos("ReferenciaObjetoDatos"), od2.ObtenerObjetoDatos("ReferenciaObjetoDatos"));

            for (int i = 0; i < od1.ObtenerColeccion("ReferenciaObjetoDatosItem").Longitud; i++)
            {
                Comparar(od1.ObtenerColeccion("ReferenciaObjetoDatosItem")[i], od2.ObtenerColeccion("ReferenciaObjetoDatosItem")[i]);
            }



            // compracion tipo2
            if (od1.Tipo.ObtenerPropiedad("ReferenciaObjetoDatos2") == null) return;

            Assert.AreEqual(od1.ObtenerObjetoDatos("ReferenciaObjetoDatos2") != null, od2.ObtenerObjetoDatos("ReferenciaObjetoDatos2") != null);

            if (od1.ObtenerObjetoDatos("ReferenciaObjetoDatos2") != null && od2.ObtenerObjetoDatos("ReferenciaObjetoDatos2") != null)
                Comparar(od1.ObtenerObjetoDatos("ReferenciaObjetoDatos2"), od2.ObtenerObjetoDatos("ReferenciaObjetoDatos2"));



            // comparacion tipo 3
            if (od1.Tipo.ObtenerPropiedad("ReferenciaObjetoDatosItem2") == null) return;

            Assert.AreEqual(od1.ObtenerObjetoDatos("ReferenciaObjetoDatosItem2") != null, od2.ObtenerObjetoDatos("ReferenciaObjetoDatosItem2") != null);

            if (od1.ObtenerObjetoDatos("ReferenciaObjetoDatosItem2") != null)
            {
                Assert.AreEqual(od1.ObtenerObjetoDatos("ReferenciaObjetoDatosItem2"), od1.ObtenerObjetoDatos("ReferenciaObjetoDatosItem[0]"));
                Assert.AreEqual(od2.ObtenerObjetoDatos("ReferenciaObjetoDatosItem2"), od2.ObtenerObjetoDatos("ReferenciaObjetoDatosItem[0]"));
            }
        }
    }
}
