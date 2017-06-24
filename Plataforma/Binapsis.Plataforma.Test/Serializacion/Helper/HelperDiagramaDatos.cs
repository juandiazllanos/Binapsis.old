using Binapsis.Plataforma.Cambios;
using Binapsis.Plataforma.Cambios.Builder;
using Binapsis.Plataforma.Cambios.Impl;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.Helper.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binapsis.Plataforma.Test.Serializacion.Helper
{
    class HelperDiagramaDatos
    {

        public static void ConstruirDiagramaDatosSimple(IDiagramaDatos dd)
        {
            IObjetoDatos od = TestHelper.Crear(HelperTipo.ObtenerTipo());
            TestHelper.Construir(od);

            // hacer una copia
            IObjetoDatos od2 = new CopyHelper(FabricaDatos.Instancia).Copiar(od);

            // realizar cambios
            od.EstablecerString("atributoString", "abcdef");
            od.EstablecerDateTime("atributoDateTime", new DateTime(2000, 10, 5));

            // construir diagrama de datos            
            BuilderDiagramaDatos builder = new BuilderDiagramaDatos(dd);
            builder.Construir(od, od2);
        }

        public static void ConstruirDiagramaDatosComplejo(IDiagramaDatos dd)
        {
            IObjetoDatos od = TestHelper.Crear(dd.Tipo);
            TestHelper.Construir(od, 2, 5);

            // hacer una copia
            IObjetoDatos od2 = new CopyHelper(FabricaDatos.Instancia).Copiar(od);

            // realizar cambios
            od.EstablecerString("ReferenciaObjetoDatos/atributoString", "abcdef");
            od.EstablecerDateTime("ReferenciaObjetoDatos/atributoDateTime", new DateTime(2000, 10, 5));

            // agregar item
            od.CrearObjetoDatos("ReferenciaObjetoDatos/ReferenciaObjetoDatosItem");
            TestHelper.Construir(od.ObtenerObjetoDatos("ReferenciaObjetoDatos/ReferenciaObjetoDatosItem[5]"));

            od.CrearObjetoDatos("ReferenciaObjetoDatosItem[0]/ReferenciaObjetoDatosItem");
            TestHelper.Construir(od.ObtenerObjetoDatos("ReferenciaObjetoDatosItem[0]/ReferenciaObjetoDatosItem[5]"));

            // remover item
            od.RemoverObjetoDatos("ReferenciaObjetoDatosItem[1]/ReferenciaObjetoDatosItem",
                od.ObtenerObjetoDatos("ReferenciaObjetoDatosItem[1]/ReferenciaObjetoDatosItem[4]"));

            // asignar referencia agregada
            IObjetoDatos referencia = TestHelper.Crear(HelperTipo.ObtenerTipo());
            TestHelper.Construir(referencia, 0, 3);

            od.EstablecerObjetoDatos("ReferenciaObjetoDatos2", referencia);

            // construir diagrama de datos            
            BuilderDiagramaDatos builder = new BuilderDiagramaDatos(dd);
            builder.Construir(od, od2);
        }

        public static void EvaluarDiagramaDatos(IDiagramaDatos dd1, IDiagramaDatos dd2)
        {
            IObjetoDatos od = dd1.ObjetoDatos;
            IObjetoDatos od2 = dd2.ObjetoDatos;

            ResumenCambios resumen1 = dd1.ResumenCambios as ResumenCambios;
            ResumenCambios resumen2 = dd2.ResumenCambios as ResumenCambios;
            IObjetoCambios cambios1 = resumen1[od];
            IObjetoCambios cambios2 = resumen2[od2];

            Assert.IsNotNull(resumen1);
            Assert.IsNotNull(resumen2);
            Assert.IsNotNull(cambios1);
            Assert.IsNotNull(cambios2);

            // evaluar objeto de datos
            Assert.IsTrue(EqualityHelper.Instancia.Igual(od, od2));
            // evaluar objeto de cambios
            Assert.IsTrue(EqualityHelper.Instancia.Igual(cambios1, cambios2));

            // evaluar resumen de cambios
            List<IObjetoDatos> cambiados1 = new List<IObjetoDatos>(resumen1.ObtenerObjetoDatosCambiados());
            List<IObjetoDatos> cambiados2 = new List<IObjetoDatos>(resumen2.ObtenerObjetoDatosCambiados());

            Assert.AreEqual(cambiados1.Count, cambiados2.Count);

            for (int i = 0; i < cambiados1.Count; i++)
                EvaluarResumenCambios(resumen1, cambiados1[i], resumen2, cambiados2[i]);
        }

        public static void EvaluarResumenCambios(IResumenCambios resumen1, IObjetoDatos od1, IResumenCambios resumen2, IObjetoDatos od2)
        {
            Assert.AreEqual(resumen1.Creado(od1), resumen2.Creado(od2));
            Assert.AreEqual(resumen1.Eliminado(od1), resumen2.Eliminado(od2));
            Assert.AreEqual(resumen1.Modificado(od1), resumen2.Modificado(od2));

            List<IPropiedad> propiedadesCambiadas1 = new List<IPropiedad>(resumen1.ObtenerCambios(od1));
            List<IPropiedad> propiedadesCambiadas2 = new List<IPropiedad>(resumen2.ObtenerCambios(od2));

            Assert.AreEqual(propiedadesCambiadas1.Count, propiedadesCambiadas2.Count);

            for (int i = 0; i < propiedadesCambiadas1.Count; i++)
                if (propiedadesCambiadas1[i].Tipo.EsTipoDeDato)
                    Assert.AreEqual(resumen1.ObtenerValorAntiguo(od1, propiedadesCambiadas1[i]), resumen2.ObtenerValorAntiguo(od2, propiedadesCambiadas2[i]));
                else
                    Assert.IsTrue(EqualityHelper.Instancia.Igual((IObjetoDatos)resumen1.ObtenerValorAntiguo(od1, propiedadesCambiadas1[i]),
                            (IObjetoDatos)resumen2.ObtenerValorAntiguo(od2, propiedadesCambiadas2[i])));
        }
    }
}
