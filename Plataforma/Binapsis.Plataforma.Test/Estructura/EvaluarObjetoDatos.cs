using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Test.Builders;

namespace Binapsis.Plataforma.Test.Estructura
{
    [TestClass]
    public class EvaluarObjetoDatos
    {
        ITipo _tipo;
        ITipo _tipox;

        public EvaluarObjetoDatos()
        {
            _tipo = new Tipo();
            BuilderTipo.Construir((Tipo)_tipo);
            _tipox = new Tipo();
            BuilderTipo.Construir2((Tipo)_tipox);
            
            // eliminar propiedad "id"
            if (_tipo.ContienePropiedad("atributoId"))
                ((Tipo)_tipo).RemoverPropiedad(_tipo["atributoId"]);
            if (_tipox.ContienePropiedad("atributoId"))
                ((Tipo)_tipox).RemoverPropiedad(_tipox["atributoId"]);
        }

        [TestMethod, TestCategory("Evaluar ObjetoDatos")]
        public void EvaluarEstablecerPorIndice()
        {
            IObjetoDatos od = Fabrica.Instancia.Crear(_tipo);
            Random rnd = new Random();

            bool valorBoolean = true;
            byte valorByte = byte.MaxValue;
            char valorChar = char.MaxValue;
            DateTime valorDateTime = DateTime.MaxValue;
            decimal valorDecimal = decimal.MaxValue;
            double valorDouble = double.MaxValue;
            float valorFloat = float.MaxValue;
            int valorInteger = int.MaxValue;
            long valorLong = long.MaxValue;
            sbyte valorSByte = sbyte.MaxValue;
            short valorShort = short.MaxValue;
            string valorString = "abcdefghijklmnoprstuvwxyz";
            uint valorUInteger = uint.MaxValue;
            ulong valorULong = ulong.MaxValue;
            ushort valorUShort = ushort.MaxValue;

            od.Establecer(0, valorBoolean);
            od.Establecer(1, valorByte);
            od.Establecer(2, valorChar);
            od.Establecer(3, valorDateTime);
            od.Establecer(4, valorDecimal);
            od.Establecer(5, valorDouble);
            od.Establecer(6, valorFloat);
            od.Establecer(7, valorInteger);
            od.Establecer(8, valorLong);
            od.Establecer(9, valorSByte);
            od.Establecer(10, valorShort);
            od.Establecer(11, valorString);
            od.Establecer(12, valorUInteger);
            od.Establecer(13, valorULong);
            od.Establecer(14, valorUShort);

            Assert.AreEqual(od.Obtener(0), valorBoolean);
            Assert.AreEqual(od.Obtener(1), valorByte);
            Assert.AreEqual(od.Obtener(2), valorChar);
            Assert.AreEqual(od.Obtener(3), valorDateTime);
            Assert.AreEqual(od.Obtener(4), valorDecimal);
            Assert.AreEqual(od.Obtener(5), valorDouble);
            Assert.AreEqual(od.Obtener(6), valorFloat);
            Assert.AreEqual(od.Obtener(7), valorInteger);
            Assert.AreEqual(od.Obtener(8), valorLong);
            Assert.AreEqual(od.Obtener(9), valorSByte);
            Assert.AreEqual(od.Obtener(10), valorShort);
            Assert.AreEqual(od.Obtener(11), valorString);
            Assert.AreEqual(od.Obtener(12), valorUInteger);
            Assert.AreEqual(od.Obtener(13), valorULong);
            Assert.AreEqual(od.Obtener(14), valorUShort);

        }

        [TestMethod, TestCategory("Evaluar ObjetoDatos")]
        public void EvaluarEstablecerPorNombre()
        {
            IObjetoDatos od = Fabrica.Instancia.Crear(_tipo);
            Random rnd = new Random();

            bool valorBoolean = true;
            byte valorByte = byte.MaxValue;
            char valorChar = char.MaxValue;
            DateTime valorDateTime = DateTime.MaxValue;
            decimal valorDecimal = decimal.MaxValue;
            double valorDouble = double.MaxValue;
            float valorFloat = float.MaxValue;
            int valorInteger = int.MaxValue;
            long valorLong = long.MaxValue;
            sbyte valorSByte = sbyte.MaxValue;
            short valorShort = short.MaxValue;
            string valorString = "abcdefghijklmnoprstuvwxyz";
            uint valorUInteger = uint.MaxValue;
            ulong valorULong = ulong.MaxValue;
            ushort valorUShort = ushort.MaxValue;

            od.Establecer("atributoBoolean", valorBoolean);
            od.Establecer("atributoByte", valorByte);
            od.Establecer("atributoChar", valorChar);
            od.Establecer("atributoDateTime", valorDateTime);
            od.Establecer("atributoDecimal", valorDecimal);
            od.Establecer("atributoDouble", valorDouble);
            od.Establecer("atributoFloat", valorFloat);
            od.Establecer("atributoInteger", valorInteger);
            od.Establecer("atributoLong", valorLong);
            od.Establecer("atributoSByte", valorSByte);
            od.Establecer("atributoShort", valorShort);
            od.Establecer("atributoString", valorString);
            od.Establecer("atributoUInteger", valorUInteger);
            od.Establecer("atributoULong", valorULong);
            od.Establecer("atributoUShort", valorUShort);

            Assert.AreEqual(od.Obtener("atributoBoolean"), valorBoolean);
            Assert.AreEqual(od.Obtener("atributoByte"), valorByte);
            Assert.AreEqual(od.Obtener("atributoChar"), valorChar);
            Assert.AreEqual(od.Obtener("atributoDateTime"), valorDateTime);
            Assert.AreEqual(od.Obtener("atributoDecimal"), valorDecimal);
            Assert.AreEqual(od.Obtener("atributoDouble"), valorDouble);
            Assert.AreEqual(od.Obtener("atributoFloat"), valorFloat);
            Assert.AreEqual(od.Obtener("atributoInteger"), valorInteger);
            Assert.AreEqual(od.Obtener("atributoLong"), valorLong);
            Assert.AreEqual(od.Obtener("atributoSByte"), valorSByte);
            Assert.AreEqual(od.Obtener("atributoShort"), valorShort);
            Assert.AreEqual(od.Obtener("atributoString"), valorString);
            Assert.AreEqual(od.Obtener("atributoUInteger"), valorUInteger);
            Assert.AreEqual(od.Obtener("atributoULong"), valorULong);
            Assert.AreEqual(od.Obtener("atributoUShort"), valorUShort);

        }

        [TestMethod, TestCategory("Evaluar ObjetoDatos")]
        public void EvaluarEstablecerPorTipoPorIndice()
        {
            IObjetoDatos od = Fabrica.Instancia.Crear(_tipo);
            Random rnd = new Random();

            bool valorBoolean = true;
            byte valorByte = byte.MaxValue;
            char valorChar = char.MaxValue;
            DateTime valorDateTime = DateTime.MaxValue;
            decimal valorDecimal = decimal.MaxValue;
            double valorDouble = double.MaxValue;
            float valorFloat = float.MaxValue;
            int valorInteger = int.MaxValue;
            long valorLong = long.MaxValue;
            sbyte valorSByte = sbyte.MaxValue;
            short valorShort = short.MaxValue;
            string valorString = "abcdefghijklmnoprstuvwxyz";
            uint valorUInteger = uint.MaxValue;
            ulong valorULong = ulong.MaxValue;
            ushort valorUShort = ushort.MaxValue;

            od.EstablecerBoolean(0, valorBoolean);
            od.EstablecerByte(1, valorByte);
            od.EstablecerChar(2, valorChar);
            od.EstablecerDateTime(3, valorDateTime);
            od.EstablecerDecimal(4, valorDecimal);
            od.EstablecerDouble(5, valorDouble);
            od.EstablecerFloat(6, valorFloat);
            od.EstablecerInteger(7, valorInteger);
            od.EstablecerLong(8, valorLong);
            od.EstablecerSByte(9, valorSByte);
            od.EstablecerShort(10, valorShort);
            od.EstablecerString(11, valorString);
            od.EstablecerUInteger(12, valorUInteger);
            od.EstablecerULong(13, valorULong);
            od.EstablecerUShort(14, valorUShort);

            Assert.AreEqual(od.ObtenerBoolean(0), valorBoolean);
            Assert.AreEqual(od.ObtenerByte(1), valorByte);
            Assert.AreEqual(od.ObtenerChar(2), valorChar);
            Assert.AreEqual(od.ObtenerDateTime(3), valorDateTime);
            Assert.AreEqual(od.ObtenerDecimal(4), valorDecimal);
            Assert.AreEqual(od.ObtenerDouble(5), valorDouble);
            Assert.AreEqual(od.ObtenerFloat(6), valorFloat);
            Assert.AreEqual(od.ObtenerInteger(7), valorInteger);
            Assert.AreEqual(od.ObtenerLong(8), valorLong);
            Assert.AreEqual(od.ObtenerSByte(9), valorSByte);
            Assert.AreEqual(od.ObtenerShort(10), valorShort);
            Assert.AreEqual(od.ObtenerString(11), valorString);
            Assert.AreEqual(od.ObtenerUInteger(12), valorUInteger);
            Assert.AreEqual(od.ObtenerULong(13), valorULong);
            Assert.AreEqual(od.ObtenerUShort(14), valorUShort);

        }

        [TestMethod, TestCategory("Evaluar ObjetoDatos")]
        public void EvaluarEstablecerPorTipoPorNombre()
        {
            IObjetoDatos od = Fabrica.Instancia.Crear(_tipo);
            Random rnd = new Random();

            bool valorBoolean = true;
            byte valorByte = byte.MaxValue;
            char valorChar = char.MaxValue;
            DateTime valorDateTime = DateTime.MaxValue;
            decimal valorDecimal = decimal.MaxValue;
            double valorDouble = double.MaxValue;
            float valorFloat = float.MaxValue;
            int valorInteger = int.MaxValue;
            long valorLong = long.MaxValue;
            sbyte valorSByte = sbyte.MaxValue;
            short valorShort = short.MaxValue;
            string valorString = "abcdefghijklmnoprstuvwxyz";
            uint valorUInteger = uint.MaxValue;
            ulong valorULong = ulong.MaxValue;
            ushort valorUShort = ushort.MaxValue;

            od.EstablecerBoolean("atributoBoolean", valorBoolean);
            od.EstablecerByte("atributoByte", valorByte);
            od.EstablecerChar("atributoChar", valorChar);
            od.EstablecerDateTime("atributoDateTime", valorDateTime);
            od.EstablecerDecimal("atributoDecimal", valorDecimal);
            od.EstablecerDouble("atributoDouble", valorDouble);
            od.EstablecerFloat("atributoFloat", valorFloat);
            od.EstablecerInteger("atributoInteger", valorInteger);
            od.EstablecerLong("atributoLong", valorLong);
            od.EstablecerSByte("atributoSByte", valorSByte);
            od.EstablecerShort("atributoShort", valorShort);
            od.EstablecerString("atributoString", valorString);
            od.EstablecerUInteger("atributoUInteger", valorUInteger);
            od.EstablecerULong("atributoULong", valorULong);
            od.EstablecerUShort("atributoUShort", valorUShort);

            Assert.AreEqual(od.ObtenerBoolean("atributoBoolean"), valorBoolean);
            Assert.AreEqual(od.ObtenerByte("atributoByte"), valorByte);
            Assert.AreEqual(od.ObtenerChar("atributoChar"), valorChar);
            Assert.AreEqual(od.ObtenerDateTime("atributoDateTime"), valorDateTime);
            Assert.AreEqual(od.ObtenerDecimal("atributoDecimal"), valorDecimal);
            Assert.AreEqual(od.ObtenerDouble("atributoDouble"), valorDouble);
            Assert.AreEqual(od.ObtenerFloat("atributoFloat"), valorFloat);
            Assert.AreEqual(od.ObtenerInteger("atributoInteger"), valorInteger);
            Assert.AreEqual(od.ObtenerLong("atributoLong"), valorLong);
            Assert.AreEqual(od.ObtenerSByte("atributoSByte"), valorSByte);
            Assert.AreEqual(od.ObtenerShort("atributoShort"), valorShort);
            Assert.AreEqual(od.ObtenerString("atributoString"), valorString);
            Assert.AreEqual(od.ObtenerUInteger("atributoUInteger"), valorUInteger);
            Assert.AreEqual(od.ObtenerULong("atributoULong"), valorULong);
            Assert.AreEqual(od.ObtenerUShort("atributoUShort"), valorUShort);

        }


        [TestMethod, TestCategory("Evaluar ObjetoDatos")]
        public void EvaluarObjetoDatosComplejoItemsIgualATres()
        {
            IObjetoDatos od = Helper.Crear(_tipox); //ConstruirObjetoDatosComplejo();
            Helper.Construir(od, 1, 3);
            Assert.AreEqual(od.ObtenerColeccion("ReferenciaObjetoDatosItem").Longitud, 3);
        }

        [TestMethod, TestCategory("Evaluar ObjetoDatos")]
        public void EvaluarObjetoDatosComplejoReferenciaItemsIgualACero()
        {
            IObjetoDatos od = Helper.Crear(_tipox); 
            Helper.Construir(od, 1, 0);
            Assert.AreEqual(od.ObtenerObjetoDatos("ReferenciaObjetoDatos").ObtenerColeccion("ReferenciaObjetoDatosItem").Longitud, 0);
        }

        [TestMethod, TestCategory("Evaluar ObjetoDatos")]
        public void EvaluarObjetoDatosComplejoRemoverUnItem()
        {
            IObjetoDatos od = Helper.Crear(_tipox);
            Helper.Construir(od, 1, 3);
            od.RemoverObjetoDatos("ReferenciaObjetoDatosItem", od.ObtenerColeccion("ReferenciaObjetoDatosItem")[0]);
            Assert.AreEqual(od.ObtenerColeccion("ReferenciaObjetoDatosItem").Longitud, 2);
        }

        [TestMethod, TestCategory("Evaluar ObjetoDatos")]
        public void EvaluarObjetoDatosComplejoRemoverDosItems()
        {
            IObjetoDatos od = Helper.Crear(_tipox);
            Helper.Construir(od, 1, 3);
            IObjetoDatos primerItem = od.ObtenerColeccion("ReferenciaObjetoDatosItem")[0];
            IObjetoDatos segundoItem = od.ObtenerColeccion("ReferenciaObjetoDatosItem")[1];

            od.RemoverObjetoDatos("ReferenciaObjetoDatosItem", primerItem);
            od.RemoverObjetoDatos("ReferenciaObjetoDatosItem", segundoItem);

            Assert.AreEqual(od.ObtenerColeccion("ReferenciaObjetoDatosItem").Longitud, 1);
        }

        [TestMethod, TestCategory("Evaluar ObjetoDatos")]
        public void EvaluarObjetoDatosComplejoRemoverTresItems()
        {
            IObjetoDatos od = Helper.Crear(_tipox);
            Helper.Construir(od, 1, 3);
            IObjetoDatos primerItem = od.ObtenerColeccion("ReferenciaObjetoDatosItem")[0];
            IObjetoDatos segundoItem = od.ObtenerColeccion("ReferenciaObjetoDatosItem")[1];
            IObjetoDatos tercerItem = od.ObtenerColeccion("ReferenciaObjetoDatosItem")[2];

            od.RemoverObjetoDatos("ReferenciaObjetoDatosItem", primerItem);
            od.RemoverObjetoDatos("ReferenciaObjetoDatosItem", segundoItem);
            od.RemoverObjetoDatos("ReferenciaObjetoDatosItem", tercerItem);

            Assert.AreEqual(od.ObtenerColeccion("ReferenciaObjetoDatosItem").Longitud, 0);
        }

        [TestMethod, TestCategory("Evaluar ObjetoDatos")]
        public void EvaluarObjetoDatosPathReferenciaDiferenteNulo()
        {
            string ruta1 = "ReferenciaObjetoDatos";
            string ruta2 = "ReferenciaObjetoDatos/ReferenciaObjetoDatos";
            string ruta3 = "ReferenciaObjetoDatos/ReferenciaObjetoDatos/ReferenciaObjetoDatos";
            string ruta4 = "ReferenciaObjetoDatos";
            string ruta5 = "ReferenciaObjetoDatos/ReferenciaObjetoDatosItem[1]";
            string ruta6 = "ReferenciaObjetoDatos/ReferenciaObjetoDatosItem[1]/ReferenciaObjetoDatos[1]";
            string ruta7 = "ReferenciaObjetoDatosItem[0]";
            string ruta8 = "ReferenciaObjetoDatosItem[1]/ReferenciaObjetoDatosItem[2]";
            string ruta9 = "ReferenciaObjetoDatosItem[2]/ReferenciaObjetoDatosItem[2]/ReferenciaObjetoDatos[2]";

            IObjetoDatos od = Helper.Crear(_tipox);
            Helper.Construir(od, 3, 3);

            IObjetoDatos item1 = od.ObtenerObjetoDatos(ruta1);
            IObjetoDatos item2 = od.ObtenerObjetoDatos(ruta2);
            IObjetoDatos item3 = od.ObtenerObjetoDatos(ruta3);
            IObjetoDatos item4 = od.ObtenerObjetoDatos(ruta4);
            IObjetoDatos item5 = od.ObtenerObjetoDatos(ruta5);
            IObjetoDatos item6 = od.ObtenerObjetoDatos(ruta6);
            IObjetoDatos item7 = od.ObtenerObjetoDatos(ruta7);
            IObjetoDatos item8 = od.ObtenerObjetoDatos(ruta8);
            IObjetoDatos item9 = od.ObtenerObjetoDatos(ruta9);

            Assert.IsNotNull(item1, $"Se esperaba un valor. ruta={ruta1}");
            Assert.IsNotNull(item2, $"Se esperaba un valor. ruta={ruta2}");
            Assert.IsNotNull(item3, $"Se esperaba un valor. ruta={ruta3}");
            Assert.IsNotNull(item4, $"Se esperaba un valor. ruta={ruta4}");
            Assert.IsNotNull(item5, $"Se esperaba un valor. ruta={ruta5}");
            Assert.IsNotNull(item6, $"Se esperaba un valor. ruta={ruta6}");
            Assert.IsNotNull(item7, $"Se esperaba un valor. ruta={ruta7}");
            Assert.IsNotNull(item8, $"Se esperaba un valor. ruta={ruta8}");
            Assert.IsNotNull(item9, $"Se esperaba un valor. ruta={ruta9}");

        }

        [TestMethod, TestCategory("Evaluar ObjetoDatos")]
        public void EvaluarObjetoDatosPathObtener()
        {
            IObjetoDatos od = Helper.Crear(_tipox);
            Helper.Construir(od, 2, 0);

            string ruta = "ReferenciaObjetoDatos";

            bool valorBoolean = true; 
            byte valorByte = 125; 
            char valorChar = 'D';
            DateTime valorDateTime = DateTime.Now; 
            decimal valorDecimal = new decimal(15896658.100245); 
            double valorDouble = 448995.55698; 
            float valorFloat = (float)56625.55; 
            int valorInteger = -102458; 
            long valorLong = -89665522321; 
            sbyte valorSByte = 89;  
            short valorShort = 5444; 
            string valorString = "cadena de texto"; 
            uint valorUInteger = 89955212; 
            ulong valorULong = 788554421056; 
            ushort valorUShort = 9035; 

            od.Establecer($"{ruta}/atributoBoolean", valorBoolean);
            od.Establecer($"{ruta}/atributoByte", valorByte);            
            od.Establecer($"{ruta}/atributoChar", valorChar);
            od.Establecer($"{ruta}/atributoDateTime", valorDateTime);
            od.Establecer($"{ruta}/atributoDecimal", valorDecimal);
            od.Establecer($"{ruta}/atributoDouble", valorDouble);
            od.Establecer($"{ruta}/atributoFloat", valorFloat);
            od.Establecer($"{ruta}/atributoInteger", valorInteger);
            od.Establecer($"{ruta}/atributoLong", valorLong);
            od.Establecer($"{ruta}/atributoSByte", valorSByte);
            od.Establecer($"{ruta}/atributoShort", valorShort);
            od.Establecer($"{ruta}/atributoString", valorString);
            od.Establecer($"{ruta}/atributoUInteger", valorUInteger);
            od.Establecer($"{ruta}/atributoULong", valorULong);
            od.Establecer($"{ruta}/atributoUShort", valorUShort);

            Assert.AreEqual(valorBoolean, Convert.ToBoolean(od.Obtener($"{ruta}/atributoBoolean")), "Se esperaba el valor true.");
            Assert.AreEqual(valorByte, od.Obtener($"{ruta}/atributoByte"));
            Assert.AreEqual(valorChar, od.Obtener($"{ruta}/atributoChar"));
            Assert.AreEqual(valorDateTime, od.Obtener($"{ruta}/atributoDateTime"));
            Assert.AreEqual(valorDecimal, od.Obtener($"{ruta}/atributoDecimal"));
            Assert.AreEqual(valorDouble, od.Obtener($"{ruta}/atributoDouble"));
            Assert.AreEqual(valorFloat, od.Obtener($"{ruta}/atributoFloat"));
            Assert.AreEqual(valorInteger, od.Obtener($"{ruta}/atributoInteger"));
            Assert.AreEqual(valorLong, od.Obtener($"{ruta}/atributoLong"));
            Assert.AreEqual(valorSByte, od.Obtener($"{ruta}/atributoSByte"));
            Assert.AreEqual(valorShort, od.Obtener($"{ruta}/atributoShort"));
            Assert.AreEqual(valorString, od.Obtener($"{ruta}/atributoString"));
            Assert.AreEqual(valorUInteger, od.Obtener($"{ruta}/atributoUInteger"));
            Assert.AreEqual(valorULong, od.Obtener($"{ruta}/atributoULong"));
            Assert.AreEqual(valorUShort, od.Obtener($"{ruta}/atributoUShort"));

        }

        [TestMethod, TestCategory("Evaluar ObjetoDatos")]
        public void EvaluarObjetoDatosPathObtenerPorTipo()
        {
            IObjetoDatos od = Helper.Crear(_tipox);
            Helper.Construir(od, 2, 0);

            string ruta = "ReferenciaObjetoDatos";

            bool valorBoolean = true;
            byte valorByte = 125;
            char valorChar = 'D';
            DateTime valorDateTime = DateTime.Now;
            decimal valorDecimal = new decimal(15896658.100245);
            double valorDouble = 448995.55698;
            float valorFloat = (float)56625.55;
            int valorInteger = -102458;
            long valorLong = -89665522321;
            sbyte valorSByte = 89;
            short valorShort = 5444;
            string valorString = "cadena de texto";
            uint valorUInteger = 89955212;
            ulong valorULong = 788554421056;
            ushort valorUShort = 9035;

            od.EstablecerBoolean($"{ruta}/atributoBoolean", valorBoolean);
            od.EstablecerByte($"{ruta}/atributoByte", valorByte);
            od.EstablecerChar($"{ruta}/atributoChar", valorChar);
            od.EstablecerDateTime($"{ruta}/atributoDateTime", valorDateTime);
            od.EstablecerDecimal($"{ruta}/atributoDecimal", valorDecimal);
            od.EstablecerDouble($"{ruta}/atributoDouble", valorDouble);
            od.EstablecerFloat($"{ruta}/atributoFloat", valorFloat);
            od.EstablecerInteger($"{ruta}/atributoInteger", valorInteger);
            od.EstablecerLong($"{ruta}/atributoLong", valorLong);
            od.EstablecerSByte($"{ruta}/atributoSByte", valorSByte);
            od.EstablecerShort($"{ruta}/atributoShort", valorShort);
            od.EstablecerString($"{ruta}/atributoString", valorString);
            od.EstablecerUInteger($"{ruta}/atributoUInteger", valorUInteger);
            od.EstablecerULong($"{ruta}/atributoULong", valorULong);
            od.EstablecerUShort($"{ruta}/atributoUShort", valorUShort);

            Assert.AreEqual(valorBoolean, od.ObtenerBoolean($"{ruta}/atributoBoolean"));
            Assert.AreEqual(valorByte, od.ObtenerByte($"{ruta}/atributoByte"));
            Assert.AreEqual(valorChar, od.ObtenerChar($"{ruta}/atributoChar"));
            Assert.AreEqual(valorDateTime, od.ObtenerDateTime($"{ruta}/atributoDateTime"));
            Assert.AreEqual(valorDecimal, od.ObtenerDecimal($"{ruta}/atributoDecimal"));
            Assert.AreEqual(valorDouble, od.ObtenerDouble($"{ruta}/atributoDouble"));
            Assert.AreEqual(valorFloat, od.ObtenerFloat($"{ruta}/atributoFloat"));
            Assert.AreEqual(valorInteger, od.ObtenerInteger($"{ruta}/atributoInteger"));
            Assert.AreEqual(valorLong, od.ObtenerLong($"{ruta}/atributoLong"));
            Assert.AreEqual(valorSByte, od.ObtenerSByte($"{ruta}/atributoSByte"));
            Assert.AreEqual(valorShort, od.ObtenerShort($"{ruta}/atributoShort"));
            Assert.AreEqual(valorString, od.ObtenerString($"{ruta}/atributoString"));
            Assert.AreEqual(valorUInteger, od.ObtenerUInteger($"{ruta}/atributoUInteger"));
            Assert.AreEqual(valorULong, od.ObtenerULong($"{ruta}/atributoULong"));
            Assert.AreEqual(valorUShort, od.ObtenerUShort($"{ruta}/atributoUShort"));

        }
    }
}
