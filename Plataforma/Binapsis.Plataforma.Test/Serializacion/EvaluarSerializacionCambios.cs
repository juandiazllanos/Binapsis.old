using Binapsis.Plataforma.Cambios;
using Binapsis.Plataforma.Cambios.Impl;
using Binapsis.Plataforma.Serializacion;
using Binapsis.Plataforma.Serializacion.Binario;
using Binapsis.Plataforma.Serializacion.Xml;
using Binapsis.Plataforma.Test.Serializacion.Helper;
using Binapsis.Plataforma.Test.Serializacion.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Binapsis.Plataforma.Test.Serializacion
{
    [TestClass]
    public class EvaluarSerializacionCambios
    {
        [TestMethod, TestCategory("Serializacion de cambios")]
        public void EvaluarSerializacionDiagramaDatosEnXml()
        {
            EvaluarSerializacionDiagramaDatos("xml");
        }

        [TestMethod, TestCategory("Serializacion de cambios")]
        public void EvaluarSerializacionDiagramaDatosEnBinario()
        {
            EvaluarSerializacionDiagramaDatos("bin");
        }

        [TestMethod, TestCategory("Serializacion de cambios")]
        public void EvaluarSerializacionDiagramaDatosXEnXml()
        {
            EvaluarSerializacionDiagramaDatosComplejo("xml");
        }

        [TestMethod, TestCategory("Serializacion de cambios")]
        public void EvaluarSerializacionDiagramaDatosXEnBinario()
        {
            EvaluarSerializacionDiagramaDatosComplejo("bin");
        }
                
        public void EvaluarSerializacionDiagramaDatos(string formato)
        {
            // construir diagrama de datos
            IDiagramaDatos dd = new DiagramaDatos(HelperTipo.ObtenerTipo());
            HelperDiagramaDatos.ConstruirDiagramaDatosSimple(dd);
            
            // serializar
            Serializar(dd, formato);
            
            // deserializar
            IDiagramaDatos dd2 = new DiagramaDatos(dd.Tipo);
            Deserializar(dd2, formato);

            // evaluar
            HelperDiagramaDatos.EvaluarDiagramaDatos(dd, dd2);            
        }

        [TestMethod, TestCategory("Evaluar serializacion cambios")]
        public void EvaluarSerializacionDiagramaDatosComplejo(string formato)
        {
            // construir diagrama de datos
            IDiagramaDatos dd = new DiagramaDatos(HelperTipo.ObtenerTipo2());
            HelperDiagramaDatos.ConstruirDiagramaDatosComplejo(dd);

            // serializar
            Serializar(dd, formato);

            // deserializar
            IDiagramaDatos dd2 = new DiagramaDatos(dd.Tipo);
            Deserializar(dd2, formato);

            // evaluar
            HelperDiagramaDatos.EvaluarDiagramaDatos(dd, dd2);
        }

        //void EvaluarDiagramaDatos(IDiagramaDatos dd1, IDiagramaDatos dd2)
        //{
        //    IObjetoDatos od = dd1.ObjetoDatos;
        //    IObjetoDatos od2 = dd2.ObjetoDatos;

        //    ResumenCambios resumen1 = dd1.ResumenCambios as ResumenCambios;
        //    ResumenCambios resumen2 = dd2.ResumenCambios as ResumenCambios;
        //    IObjetoCambios cambios1 = resumen1[od];
        //    IObjetoCambios cambios2 = resumen2[od2];

        //    Assert.IsNotNull(resumen1);
        //    Assert.IsNotNull(resumen2);
        //    Assert.IsNotNull(cambios1);
        //    Assert.IsNotNull(cambios2);

        //    // evaluar objeto de datos
        //    Assert.IsTrue(EqualityHelper.Instancia.Igual(od, od2));
        //    // evaluar objeto de cambios
        //    Assert.IsTrue(EqualityHelper.Instancia.Igual(cambios1, cambios2));

        //    // evaluar resumen de cambios
        //    List<IObjetoDatos> cambiados1 = new List<IObjetoDatos>(resumen1.ObtenerObjetoDatosCambiados());
        //    List<IObjetoDatos> cambiados2 = new List<IObjetoDatos>(resumen2.ObtenerObjetoDatosCambiados());

        //    Assert.AreEqual(cambiados1.Count, cambiados2.Count);

        //    for (int i = 0; i < cambiados1.Count; i++)
        //        EvaluarResumenCambios(resumen1, cambiados1[i], resumen2, cambiados2[i]);            
        //}

        //void EvaluarResumenCambios(IResumenCambios resumen1, IObjetoDatos od1, IResumenCambios resumen2, IObjetoDatos od2)
        //{
        //    Assert.AreEqual(resumen1.Creado(od1), resumen2.Creado(od2));
        //    Assert.AreEqual(resumen1.Eliminado(od1), resumen2.Eliminado(od2));
        //    Assert.AreEqual(resumen1.Modificado(od1), resumen2.Modificado(od2));

        //    List<IPropiedad> propiedadesCambiadas1 = new List<IPropiedad>(resumen1.ObtenerCambios(od1));
        //    List<IPropiedad> propiedadesCambiadas2 = new List<IPropiedad>(resumen2.ObtenerCambios(od2));

        //    Assert.AreEqual(propiedadesCambiadas1.Count, propiedadesCambiadas2.Count);

        //    for (int i = 0; i < propiedadesCambiadas1.Count; i++)
        //        if (propiedadesCambiadas1[i].Tipo.EsTipoDeDato)
        //            Assert.AreEqual(resumen1.ObtenerValorAntiguo(od1, propiedadesCambiadas1[i]), resumen2.ObtenerValorAntiguo(od2, propiedadesCambiadas2[i]));
        //        else
        //            Assert.IsTrue(EqualityHelper.Instancia.Igual((IObjetoDatos)resumen1.ObtenerValorAntiguo(od1, propiedadesCambiadas1[i]),
        //                    (IObjetoDatos)resumen2.ObtenerValorAntiguo(od2, propiedadesCambiadas2[i])));
        //}

        //void ConstruirDiagramaDatosSimple(IDiagramaDatos dd)
        //{
        //    IObjetoDatos od = TestHelper.Crear(HelperTipo.ObtenerTipo());
        //    TestHelper.Construir(od);
            
        //    // hacer una copia
        //    IObjetoDatos od2 = new CopyHelper(FabricaDatos.Instancia).Copiar(od);
            
        //    // realizar cambios
        //    od.EstablecerString("atributoString", "abcdef");
        //    od.EstablecerDateTime("atributoDateTime", new DateTime(2000, 10, 5));

        //    // construir diagrama de datos            
        //    BuilderDiagramaDatos builder = new BuilderDiagramaDatos(dd);
        //    builder.Construir(od, od2);
        //}

        //void ConstruirDiagramaDatosComplejo(IDiagramaDatos dd)
        //{
        //    IObjetoDatos od = TestHelper.Crear(dd.Tipo);
        //    TestHelper.Construir(od, 2, 5);

        //    // hacer una copia
        //    IObjetoDatos od2 = new CopyHelper(FabricaDatos.Instancia).Copiar(od);

        //    // realizar cambios
        //    od.EstablecerString("ReferenciaObjetoDatos/atributoString", "abcdef");
        //    od.EstablecerDateTime("ReferenciaObjetoDatos/atributoDateTime", new DateTime(2000, 10, 5));       
            
        //    // agregar item
        //    od.CrearObjetoDatos("ReferenciaObjetoDatos/ReferenciaObjetoDatosItem");
        //    TestHelper.Construir(od.ObtenerObjetoDatos("ReferenciaObjetoDatos/ReferenciaObjetoDatosItem[5]"));

        //    od.CrearObjetoDatos("ReferenciaObjetoDatosItem[0]/ReferenciaObjetoDatosItem");
        //    TestHelper.Construir(od.ObtenerObjetoDatos("ReferenciaObjetoDatosItem[0]/ReferenciaObjetoDatosItem[5]"));

        //    // remover item
        //    od.RemoverObjetoDatos("ReferenciaObjetoDatosItem[1]/ReferenciaObjetoDatosItem", 
        //        od.ObtenerObjetoDatos("ReferenciaObjetoDatosItem[1]/ReferenciaObjetoDatosItem[4]"));

        //    // asignar referencia agregada
        //    IObjetoDatos referencia = TestHelper.Crear(HelperTipo.ObtenerTipo());
        //    TestHelper.Construir(referencia, 0, 3);

        //    od.EstablecerObjetoDatos("ReferenciaObjetoDatos2", referencia);

        //    // construir diagrama de datos            
        //    BuilderDiagramaDatos builder = new BuilderDiagramaDatos(dd);
        //    builder.Construir(od, od2);
        //}

        void SerializarXml(IDiagramaDatos dd, string ruta)
        {
            Serializar(dd, new FicheroImpl(ruta), new EscritorXml());
        }

        void SerializarBinario(IDiagramaDatos dd, string ruta)
        {
            Serializar(dd, new FicheroImpl(ruta), new EscritorBinario());
        }

        void DeserializarXml(IDiagramaDatos dd, string ruta)
        {
            Deserializar(dd, new FicheroImpl(ruta), new LectorXml()); 
        }

        void DeserializarBinario(IDiagramaDatos dd, string ruta)
        {
            Deserializar(dd, new FicheroImpl(ruta), new LectorBinario());
        }

        void Serializar(IDiagramaDatos dd, string formato)
        {
            if (formato == "xml")
                SerializarXml(dd, $"dd.{formato}");
            else if (formato == "bin")
                SerializarBinario(dd, $"dd.{formato}");
        }

        void Deserializar(IDiagramaDatos dd, string formato)
        {
            if (formato == "xml")
                DeserializarXml(dd, $"dd.{formato}");
            else if (formato == "bin")
                DeserializarBinario(dd, $"dd.{formato}");
        }

        void Serializar(IDiagramaDatos dd, ISecuencia secuencia, IEscritor escritor)
        {
            Serializador serializador = new SerializadorDiagramaDatos(secuencia, escritor);
            serializador.Serializar(dd);
        }

        void Deserializar(IDiagramaDatos dd, ISecuencia secuencia, ILector lector)
        {            
            Deserializador deserializador = new DeserializadorDiagramaDatos(secuencia, lector);
            deserializador.Deserializar(dd);
        }

    }
}
