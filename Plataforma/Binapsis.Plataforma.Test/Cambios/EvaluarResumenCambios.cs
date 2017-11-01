using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Helper;
using Binapsis.Plataforma.Helper.Impl;
using Binapsis.Plataforma.Cambios;
using Binapsis.Plataforma.Cambios.Impl;
using Binapsis.Plataforma.Cambios.Builder;
using System.Collections.Generic;

namespace Binapsis.Plataforma.Test.Cambios
{
    [TestClass]
    public class EvaluarResumenCambios
    {
        [TestMethod, TestCategory("Evaluar Resumen de cambios")]
        public void EvaluarDiagramaDatosSimpleCreado()
        {
            ITipo tipo = HelperTipo.ObtenerTipo();
            IObjetoDatos nuevo = TestHelper.Crear(tipo);
            TestHelper.Construir(nuevo);
            
            nuevo.EstablecerString("atributoString", "valor cambiado");
            nuevo.EstablecerInteger("atributoInteger", 1000);

            IDiagramaDatos diagrama = new DiagramaDatos(tipo);
            BuilderDiagramaDatos builder = new BuilderDiagramaDatos(diagrama);
            builder.Construir(nuevo, null as IObjetoDatos);

            IResumenCambios resumen = diagrama.ResumenCambios;

            Assert.AreEqual(1, resumen.ObtenerObjetoDatosCambiados().Longitud);
            Assert.IsTrue(resumen.Creado(nuevo));
            Assert.AreEqual(nuevo, resumen.ObtenerObjetoDatosCambiados()[0]);
        }

        [TestMethod, TestCategory("Evaluar Resumen de cambios")]
        public void EvaluarDiagramaDatosCambiosSimple()
        {
            ITipo tipo = HelperTipo.ObtenerTipo();
            IObjetoDatos nuevo = TestHelper.Crear(tipo);
            TestHelper.Construir(nuevo);

            ICopyHelper helper = new CopyHelper();
            IObjetoDatos antiguo = helper.Copiar(nuevo);

            nuevo.EstablecerString("atributoString", "valor cambiado");
            nuevo.EstablecerInteger("atributoInteger", 1000);

            IDiagramaDatos diagrama = new DiagramaDatos(tipo);
            BuilderDiagramaDatos builder = new BuilderDiagramaDatos(diagrama);
            builder.Construir(nuevo, antiguo);

            IResumenCambios resumen = diagrama.ResumenCambios;

            List<IObjetoDatos> objetosCambiados = new List<IObjetoDatos>(resumen.ObtenerObjetoDatosCambiados());
            List<IPropiedad> propiedadesCambiadas = new List<IPropiedad>(resumen.ObtenerCambios(nuevo));

            Assert.AreEqual(1, objetosCambiados.Count);
            Assert.AreEqual(2, propiedadesCambiadas.Count);

            Assert.AreEqual(antiguo.Obtener(propiedadesCambiadas[0]), resumen.ObtenerValorAntiguo(nuevo, propiedadesCambiadas[0]));
            Assert.AreEqual(antiguo.Obtener(propiedadesCambiadas[1]), resumen.ObtenerValorAntiguo(nuevo, propiedadesCambiadas[1]));
        }

        [TestMethod, TestCategory("Evaluar Resumen de cambios")]
        public void EvaluarDiagramaDatosCambiosColeccion()
        {
            ITipo tipo = HelperTipo.ObtenerTipo2();
            IObjetoDatos nuevo = TestHelper.Crear(tipo);
            TestHelper.Construir(nuevo, 2, 3);

            ICopyHelper helper = new CopyHelper();
            IObjetoDatos antiguo = helper.Copiar(nuevo);

            nuevo.EstablecerString("atributoString", "valor cambiado");
            nuevo.EstablecerInteger("atributoInteger", 1000);
            nuevo.EstablecerString("ReferenciaObjetoDatosItem[0]/ReferenciaObjetoDatosItem[0]/atributoString", "valor cambiado");
            nuevo.EstablecerString("ReferenciaObjetoDatosItem[0]/ReferenciaObjetoDatosItem[1]/atributoString", "valor cambiado");
            nuevo.CrearObjetoDatos("ReferenciaObjetoDatosItem");
            nuevo.CrearObjetoDatos("ReferenciaObjetoDatosItem");
            nuevo.EstablecerString("ReferenciaObjetoDatosItem[4]/atributoString", "valor cambiado");

            nuevo.RemoverObjetoDatos("ReferenciaObjetoDatosItem[0]/ReferenciaObjetoDatosItem", nuevo.ObtenerObjetoDatos("ReferenciaObjetoDatosItem[0]/ReferenciaObjetoDatosItem[2]"));

            IDiagramaDatos diagrama = new DiagramaDatos(tipo);
            BuilderDiagramaDatos builder = new BuilderDiagramaDatos(diagrama);                    
            builder.Construir(nuevo, antiguo);

            IResumenCambios resumen = diagrama.ResumenCambios;

            List<IObjetoDatos> objetosCambiados = new List<IObjetoDatos>(resumen.ObtenerObjetoDatosCambiados());
            Assert.AreEqual(7, objetosCambiados.Count);

            Assert.IsTrue(objetosCambiados.Contains(nuevo));
            Assert.IsTrue(objetosCambiados.Contains(nuevo.ObtenerObjetoDatos("ReferenciaObjetoDatosItem[0]")));
            Assert.IsFalse(objetosCambiados.Contains(nuevo.ObtenerObjetoDatos("ReferenciaObjetoDatosItem[1]")));
            Assert.IsFalse(objetosCambiados.Contains(nuevo.ObtenerObjetoDatos("ReferenciaObjetoDatosItem[2]")));
            Assert.IsTrue(objetosCambiados.Contains(nuevo.ObtenerObjetoDatos("ReferenciaObjetoDatosItem[3]")));
            Assert.IsTrue(objetosCambiados.Contains(nuevo.ObtenerObjetoDatos("ReferenciaObjetoDatosItem[4]")));
            Assert.IsTrue(objetosCambiados.Contains(nuevo.ObtenerObjetoDatos("ReferenciaObjetoDatosItem[0]/ReferenciaObjetoDatosItem[0]")));
            Assert.IsTrue(objetosCambiados.Contains(nuevo.ObtenerObjetoDatos("ReferenciaObjetoDatosItem[0]/ReferenciaObjetoDatosItem[1]")));

            Assert.IsTrue(resumen.Modificado(nuevo));
            Assert.IsTrue(resumen.Modificado(nuevo.ObtenerObjetoDatos("ReferenciaObjetoDatosItem[0]")));
            Assert.IsFalse(resumen.Modificado(nuevo.ObtenerObjetoDatos("ReferenciaObjetoDatosItem[1]")));
            Assert.IsFalse(resumen.Modificado(nuevo.ObtenerObjetoDatos("ReferenciaObjetoDatosItem[2]")));
            Assert.IsFalse(resumen.Modificado(nuevo.ObtenerObjetoDatos("ReferenciaObjetoDatosItem[3]")));
            Assert.IsFalse(resumen.Modificado(nuevo.ObtenerObjetoDatos("ReferenciaObjetoDatosItem[4]")));

            Assert.IsFalse(resumen.Creado(nuevo.ObtenerObjetoDatos("ReferenciaObjetoDatosItem[0]")));
            Assert.IsFalse(resumen.Creado(nuevo.ObtenerObjetoDatos("ReferenciaObjetoDatosItem[1]")));
            Assert.IsFalse(resumen.Creado(nuevo.ObtenerObjetoDatos("ReferenciaObjetoDatosItem[2]")));
            Assert.IsTrue(resumen.Creado(nuevo.ObtenerObjetoDatos("ReferenciaObjetoDatosItem[3]")));
            Assert.IsTrue(resumen.Creado(nuevo.ObtenerObjetoDatos("ReferenciaObjetoDatosItem[4]")));


            List<IPropiedad> propiedadesCambiadas = new List<IPropiedad>(resumen.ObtenerCambios(nuevo));

            Assert.AreEqual(3, propiedadesCambiadas.Count);
            Assert.AreEqual(antiguo.Obtener(propiedadesCambiadas[0]), resumen.ObtenerValorAntiguo(nuevo, propiedadesCambiadas[0]));
            Assert.AreEqual(antiguo.Obtener(propiedadesCambiadas[1]), resumen.ObtenerValorAntiguo(nuevo, propiedadesCambiadas[1]));

            propiedadesCambiadas = new List<IPropiedad>(resumen.ObtenerCambios(nuevo.ObtenerObjetoDatos("ReferenciaObjetoDatosItem[0]")));

            Assert.AreEqual(1, propiedadesCambiadas.Count);
            Assert.AreEqual("ReferenciaObjetoDatosItem", propiedadesCambiadas[0].Nombre);

            propiedadesCambiadas = new List<IPropiedad>(resumen.ObtenerCambios(nuevo.ObtenerObjetoDatos("ReferenciaObjetoDatosItem[0]/ReferenciaObjetoDatosItem[0]")));

            Assert.AreEqual(1, propiedadesCambiadas.Count);
            Assert.AreEqual("atributoString", propiedadesCambiadas[0].Nombre);
            Assert.AreEqual(antiguo.ObtenerString("ReferenciaObjetoDatosItem[0]/ReferenciaObjetoDatosItem[0]/atributoString"),
                resumen.ObtenerValorAntiguo(nuevo.ObtenerObjetoDatos("ReferenciaObjetoDatosItem[0]/ReferenciaObjetoDatosItem[0]"), propiedadesCambiadas[0]));

        }

        [TestMethod, TestCategory("Evaluar Resumen de cambios")]
        public void EvaluarDiagramaDatosCambiosColeccionPorClave()
        {
            ITipo tipo = HelperTipo.ObtenerTipo2();
            IObjetoDatos nuevo = TestHelper.Crear(tipo);
            TestHelper.Construir(nuevo, 1, 3);

            ICopyHelper helper = new CopyHelper();
            IObjetoDatos antiguo = helper.Copiar(nuevo);
            
            IObjetoDatos itemNuevo  = nuevo.CrearObjetoDatos("ReferenciaObjetoDatosItem");
            IObjetoDatos itemEditado = nuevo.ObtenerObjetoDatos("ReferenciaObjetoDatosItem[0]");
            IObjetoDatos itemEliminado = nuevo.ObtenerObjetoDatos("ReferenciaObjetoDatosItem[1]");

            itemEditado.EstablecerString("atributoString", "item valor modificado");
            nuevo.RemoverObjetoDatos("ReferenciaObjetoDatosItem", itemEliminado);

            IDiagramaDatos diagrama = new DiagramaDatos(tipo);
            BuilderDiagramaDatos builder = new BuilderDiagramaDatos(diagrama);
            // utilizar claves
            builder.KeyHelper = HelperTipo.KeyHelper;
            builder.Construir(nuevo, antiguo);

            IResumenCambios resumen = diagrama.ResumenCambios;

            List<IObjetoDatos> cambios = new List<IObjetoDatos>(resumen.ObtenerObjetoDatosCambiados());

            Assert.AreEqual(4, cambios.Count);

            Assert.IsTrue(resumen.Creado(itemNuevo));
            Assert.IsTrue(resumen.Modificado(itemEditado));

            IObjetoDatos itemEliminado2 = null;

            foreach (IObjetoDatos item in cambios)
                if (resumen.Eliminado(item))
                {
                    itemEliminado2 = item;
                    break;
                }

            Assert.IsNotNull(itemEliminado2);

            IKey key1 = HelperTipo.KeyHelper.GetKey(itemEliminado);
            IKey key2 = HelperTipo.KeyHelper.GetKey(itemEliminado2);

            Assert.IsNotNull(key1);
            Assert.IsNotNull(key2);

            Assert.IsTrue(key1.Equals(key2));
        }

        [TestMethod, TestCategory("Evaluar Resumen de cambios")]
        public void EvaluarDiagramaDatosCambiosReferencia()
        {
            ITipo tipo = HelperTipo.ObtenerTipo2();
            IObjetoDatos nuevo = TestHelper.Crear(tipo);
            TestHelper.Construir(nuevo, 1);

            ICopyHelper helper = new CopyHelper();
            IObjetoDatos antiguo = helper.Copiar(nuevo);

            // crear nueva referencia agregada
            IObjetoDatos referencia = TestHelper.Crear(HelperTipo.ObtenerTipo());
            TestHelper.Construir(referencia);

            // establecer referencia agregada
            nuevo.EstablecerObjetoDatos("ReferenciaObjetoDatos2", referencia);

            // crear resumen
            IDiagramaDatos diagrama = new DiagramaDatos(tipo);
            BuilderDiagramaDatos builder = new BuilderDiagramaDatos(diagrama);
            builder.Construir(nuevo, antiguo);

            IResumenCambios resumen = diagrama.ResumenCambios;

            List<IObjetoDatos> objetosCambiados = new List<IObjetoDatos>(resumen.ObtenerObjetoDatosCambiados());

            Assert.AreEqual(1, objetosCambiados.Count);

            Assert.IsFalse(resumen.Creado(objetosCambiados[0]));
            Assert.IsFalse(resumen.Eliminado(objetosCambiados[0]));
            Assert.IsTrue(resumen.Modificado(objetosCambiados[0]));
            
            List<IPropiedad> propiedadesCambiadas = new List<IPropiedad>(resumen.ObtenerCambios(nuevo));
            Assert.AreEqual(1, propiedadesCambiadas.Count);
            Assert.AreEqual("ReferenciaObjetoDatos2", propiedadesCambiadas[0].Nombre);
            Assert.IsTrue(EqualityHelper.Instancia.Igual(antiguo.ObtenerObjetoDatos("ReferenciaObjetoDatos2"), 
                resumen.ObtenerValorAntiguo(nuevo, propiedadesCambiadas[0]) as IObjetoDatos));

            // establecer referencia agregada en null
            nuevo.EstablecerObjetoDatos("ReferenciaObjetoDatos2", null);

            // crear resumen
            diagrama = new DiagramaDatos(tipo);
            builder = new BuilderDiagramaDatos(diagrama);
            builder.Construir(nuevo, antiguo);

            resumen = diagrama.ResumenCambios;

            objetosCambiados = new List<IObjetoDatos>(resumen.ObtenerObjetoDatosCambiados());

            Assert.AreEqual(1, objetosCambiados.Count);
            Assert.IsFalse(resumen.Creado(objetosCambiados[0]));
            Assert.IsFalse(resumen.Eliminado(objetosCambiados[0]));
            Assert.IsTrue(resumen.Modificado(objetosCambiados[0]));
            
            propiedadesCambiadas = new List<IPropiedad>(resumen.ObtenerCambios(nuevo));
            Assert.AreEqual(1, propiedadesCambiadas.Count);
            Assert.AreEqual("ReferenciaObjetoDatos2", propiedadesCambiadas[0].Nombre);
            Assert.IsTrue(EqualityHelper.Instancia.Igual(antiguo.ObtenerObjetoDatos("ReferenciaObjetoDatos2"),
                resumen.ObtenerValorAntiguo(nuevo, propiedadesCambiadas[0]) as IObjetoDatos));

            // copiar con la referencia = null
            helper = new CopyHelper();
            antiguo = helper.Copiar(nuevo);

            // establecer referencia agregada
            nuevo.EstablecerObjetoDatos("ReferenciaObjetoDatos2", referencia);

            // crear resumen
            diagrama = new DiagramaDatos(tipo);
            builder = new BuilderDiagramaDatos(diagrama);
            builder.Construir(nuevo, antiguo);

            resumen = diagrama.ResumenCambios;

            objetosCambiados = new List<IObjetoDatos>(resumen.ObtenerObjetoDatosCambiados());

            Assert.AreEqual(1, objetosCambiados.Count);
            Assert.IsFalse(resumen.Creado(objetosCambiados[0]));
            Assert.IsFalse(resumen.Eliminado(objetosCambiados[0]));
            Assert.IsTrue(resumen.Modificado(objetosCambiados[0]));
            

            propiedadesCambiadas = new List<IPropiedad>(resumen.ObtenerCambios(nuevo));
            Assert.AreEqual(1, propiedadesCambiadas.Count);
            Assert.AreEqual("ReferenciaObjetoDatos2", propiedadesCambiadas[0].Nombre);
            Assert.IsTrue(EqualityHelper.Instancia.Igual(antiguo.ObtenerObjetoDatos("ReferenciaObjetoDatos2"),
                resumen.ObtenerValorAntiguo(nuevo, propiedadesCambiadas[0]) as IObjetoDatos));
        }
    }
}
