using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Serializacion.Interno;
using Binapsis.Plataforma.Test.Serializacion.Helpers;

namespace Binapsis.Plataforma.Test.Serializacion
{
    [TestClass]
    public class EvaluarSerializacionDiagrama
    {
        [TestMethod, TestCategory("Serializacion diagrama")]
        public void CrearDiagramaComposicion()
        {
            IObjetoDatos od = HelperDiagrama.CrearObjetoDatosX();

            Helper.Construir(od, 2, 5);
            HelperDiagrama.EstablecerAtributoRuta(od);

            // establecer referencia2
            od.EstablecerObjetoDatos("ReferenciaObjetoDatosItem2", od.ObtenerColeccion("ReferenciaObjetoDatosItem")[0]);

            BuilderDiagrama helper = new BuilderDiagrama();
            Diagrama diag = helper.Crear(od);

            IPropiedad prop1 = od.Tipo.ObtenerPropiedad("ReferenciaObjetoDatos");
            IPropiedad prop2 = od.Tipo.ObtenerPropiedad("ReferenciaObjetoDatosItem");
            IPropiedad prop3 = od.Tipo.ObtenerPropiedad("ReferenciaObjetoDatos2");
            IPropiedad prop4 = od.Tipo.ObtenerPropiedad("ReferenciaObjetoDatosItem2");

            IObjetoDatos od1 = od.ObtenerObjetoDatos(prop1);            
            IObjetoDatos od4 = od.ObtenerObjetoDatos(prop4);
            IObjetoDatos item1 = od.ObtenerColeccion(prop2)[0];
            IObjetoDatos item2 = od.ObtenerColeccion(prop2)[1];
            IObjetoDatos item3 = od.ObtenerColeccion(prop2)[2];


            NodoReferencia nodoprop1 = (NodoReferencia)diag.Root.Nodos[0];
            NodoReferencia nodoprop2 = (NodoReferencia)diag.Root.Nodos[1];
            NodoReferencia nodoprop3 = (NodoReferencia)diag.Root.Nodos[2];
            NodoReferencia nodoprop4 = (NodoReferencia)diag.Root.Nodos[3];
            
            NodoObjeto nodoobj1 = (NodoObjeto)nodoprop1.Nodos[0];
            NodoObjeto nodoobj4 = (NodoObjeto)nodoprop4.Nodos[0];

            NodoObjeto nodoitem1 = (NodoObjeto)nodoprop2.Nodos[0];
            NodoObjeto nodoitem2 = (NodoObjeto)nodoprop2.Nodos[1];
            NodoObjeto nodoitem3 = (NodoObjeto)nodoprop2.Nodos[2];
            

            Assert.IsNotNull(diag.Root);
            Assert.AreEqual(od, diag.Root.Objeto.ObjetoDatos);

            Assert.IsNotNull(nodoprop1);
            Assert.IsNotNull(prop1);
            Assert.AreEqual(prop1, nodoprop1.Propiedad);

            Assert.IsNotNull(nodoobj1);
            Assert.IsNotNull(od1);
            Assert.AreEqual(od1, nodoobj1.Objeto.ObjetoDatos);
            Assert.AreEqual("/ReferenciaObjetoDatos", nodoobj1.Objeto.Propietario);

            Assert.IsNotNull(prop3);
            Assert.IsNotNull(nodoprop3);
            Assert.AreEqual(prop3, nodoprop3.Propiedad);

            Assert.IsNotNull(nodoitem1);
            Assert.IsNotNull(item1);
            Assert.AreEqual(item1, nodoitem1.Objeto.ObjetoDatos);
            Assert.AreEqual("/ReferenciaObjetoDatosItem[0]", nodoitem1.Objeto.Propietario);

            Assert.IsNotNull(nodoitem2);
            Assert.IsNotNull(item2);
            Assert.AreEqual(item2, nodoitem2.Objeto.ObjetoDatos);
            Assert.AreEqual("/ReferenciaObjetoDatosItem[1]", nodoitem2.Objeto.Propietario);

            Assert.IsNotNull(nodoitem3);
            Assert.IsNotNull(item3);
            Assert.AreEqual(item3, nodoitem3.Objeto.ObjetoDatos);
            Assert.AreEqual("/ReferenciaObjetoDatosItem[2]", nodoitem3.Objeto.Propietario);

            // comprobar referencia agregacion 
            Assert.IsNotNull(prop3);
            Assert.IsNotNull(nodoprop3);
            Assert.AreEqual(prop3, nodoprop3.Propiedad);

            Assert.AreEqual(od4, item1);
            Assert.IsNotNull(nodoobj4);
            Assert.AreEqual(item1, nodoobj4.Objeto.ObjetoDatos);
            Assert.AreEqual("/ReferenciaObjetoDatosItem[0]", nodoobj4.Objeto.Propietario);

        }

        [TestMethod, TestCategory("Serializacion diagrama")]
        public void CrearDiagramaAgregacion()
        {
            IObjetoDatos od = HelperDiagrama.CrearObjetoDatosX();

            Helper.Construir(od, 2, 5);
            HelperDiagrama.EstablecerAtributoRuta(od);

            ITipo tipoagr = od.Tipo.ObtenerPropiedad("ReferenciaObjetoDatos2").Tipo;

            IObjetoDatos odagr = Helper.Crear(tipoagr);
            IObjetoDatos odagr2 = Helper.Crear(tipoagr);

            odagr.CrearObjetoDatos("ReferenciaObjetoDatos");
            odagr.EstablecerObjetoDatos("ReferenciaObjetoDatos2", odagr2);
            odagr2.EstablecerObjetoDatos("ReferenciaObjetoDatos2", odagr); // establecer referencia agregacion apuntando al contenedor (odgr)

            od.EstablecerObjetoDatos("ReferenciaObjetoDatos2", odagr);

            BuilderDiagrama helper = new BuilderDiagrama();
            Diagrama diag = helper.Crear(od);

            NodoReferencia nodoprop1 = (NodoReferencia)diag.Root.Nodos[0];
            NodoReferencia nodoprop3 = (NodoReferencia)diag.Root.Nodos[2];
            NodoObjeto nodoobj1 = (NodoObjeto)nodoprop1.Nodos[0];
            NodoObjeto nodoobj3 = (NodoObjeto)nodoprop3.Nodos[0];

            IPropiedad prop1 = od.Tipo.ObtenerPropiedad("ReferenciaObjetoDatos");
            IPropiedad prop3 = od.Tipo.ObtenerPropiedad("ReferenciaObjetoDatos2");
            IObjetoDatos obj1 = od.ObtenerObjetoDatos(prop1);
            IObjetoDatos obj3 = od.ObtenerObjetoDatos(prop3);

            Assert.IsNotNull(nodoprop1);
            Assert.IsNotNull(nodoprop3);
            Assert.IsNotNull(prop1);
            Assert.IsNotNull(prop3);
            Assert.IsNotNull(obj1);
            Assert.IsNotNull(obj3);

            Assert.AreEqual(prop1, nodoprop1.Propiedad);
            Assert.AreEqual(prop3, nodoprop3.Propiedad);
            Assert.AreEqual(obj1, nodoobj1.Objeto.ObjetoDatos);
            Assert.AreEqual(obj3, nodoobj3.Objeto.ObjetoDatos);

            Assert.AreEqual("/ReferenciaObjetoDatos", nodoobj1.Objeto.Propietario);
            Assert.AreEqual("/ReferenciaObjetoDatos2", nodoobj3.Objeto.Propietario);


            nodoprop1 = (NodoReferencia)nodoobj3.Nodos[0];
            nodoprop3 = (NodoReferencia)nodoobj3.Nodos[1];
            nodoobj1 = (NodoObjeto)nodoprop1.Nodos[0];
            nodoobj3 = (NodoObjeto)nodoprop3.Nodos[0];

            prop1 = odagr.Tipo.ObtenerPropiedad("ReferenciaObjetoDatos");
            prop3 = odagr.Tipo.ObtenerPropiedad("ReferenciaObjetoDatos2");
            obj1 = odagr.ObtenerObjetoDatos(prop1);
            obj3 = odagr.ObtenerObjetoDatos(prop3);

            Assert.IsNotNull(nodoprop1);
            Assert.IsNotNull(nodoprop3);
            Assert.IsNotNull(prop1);
            Assert.IsNotNull(prop3);
            Assert.IsNotNull(obj1);
            Assert.IsNotNull(obj3);

            Assert.AreEqual(prop1, nodoprop1.Propiedad);
            Assert.AreEqual(prop3, nodoprop3.Propiedad);
            Assert.AreEqual(obj1, nodoobj1.Objeto.ObjetoDatos);
            Assert.AreEqual(odagr2, nodoobj3.Objeto.ObjetoDatos);

            Assert.AreEqual("/ReferenciaObjetoDatos2/ReferenciaObjetoDatos", nodoobj1.Objeto.Propietario);
            Assert.AreEqual("/ReferenciaObjetoDatos2/ReferenciaObjetoDatos2", nodoobj3.Objeto.Propietario);

            // verificar la referencia odgr2.ReferenciaObjetoDatos2 => odagr
            nodoprop1 = (NodoReferencia)nodoobj3.Nodos[0];
            nodoobj1 = (NodoObjeto)nodoprop1.Nodos[0];
            obj1 = odagr2.ObtenerObjetoDatos("ReferenciaObjetoDatos2");

            Assert.AreEqual(odagr, obj1);

            Assert.AreEqual("/ReferenciaObjetoDatos2", nodoobj1.Objeto.Propietario);
        }
    }
}
