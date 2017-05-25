using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Estructura.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binapsis.Plataforma.Test.Estructura
{
    [TestClass]
    public class EvaluarTypeHelper
    {
        [TestMethod, TestCategory("Evaluar TypeHelper")]
        public void EvaluarBaseTypes()
        {
            //ITipo tipo = TypeHelper.Instancia.Obtener("System", "String");
            //Assert.AreEqual("System", tipo.Uri);
            //Assert.AreEqual("String", tipo.Nombre);

            //tipo = TypeHelper.Instancia.Obtener("System", "Boolean");
            //Assert.AreEqual("System", tipo.Uri);
            //Assert.AreEqual("Boolean", tipo.Nombre);

            //tipo = TypeHelper.Instancia.Obtener("Binapsis.Plataforma.Estructura.Impl", "Tipo");
            //Assert.AreEqual("Binapsis.Plataforma.Estructura.Impl", tipo.Uri);
            //Assert.AreEqual("Tipo", tipo.Nombre);
        }

        //[TestMethod, TestCategory("Evaluar TypeHelper")]
        //public void EvaluarCustomTypes()
        //{
        //    IObjetoDatos tipo = Fabrica.Instancia.Crear(TypeHelper.Instancia.Obtener("Binapsis.Plataforma.Estructura.Impl", "Tipo"));
        //    tipo.EstablecerString("Nombre", "Custom");
        //    tipo.EstablecerString("Uri", "CustomTypes");

        //    IObjetoDatos propiedad = tipo.CrearObjetoDatos("Propiedades");
        //    propiedad.EstablecerString("Nombre", "Property1");
        //    //propiedad.Es

        //}
    }
}
