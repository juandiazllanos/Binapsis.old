using Binapsis.Plataforma.Cambios;
using Binapsis.Plataforma.Cambios.Builder;
using Binapsis.Plataforma.Cambios.Impl;
using Binapsis.Plataforma.Datos;
using Binapsis.Plataforma.Datos.Impl;
using Binapsis.Plataforma.Datos.SQLite;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.Helper;
using Binapsis.Plataforma.Helper.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;

namespace Binapsis.Plataforma.Test.Datos
{
    [TestClass]
    public class EvaluarDAS
    {
        IConfiguracion _configuracion = new Impl.Configuracion();
        string _cadenaConexion = "Filename=D:\\Data\\Binapsis\\test.db";

        [TestMethod, TestCategory("Evaluar Servicio de acceso de datos")]
        public void EvaluarDASDistrito()
        {
            IFabrica fabrica = FabricaDatos.Instancia;
            ITipo tipo = _configuracion.ObtenerTipo("Binapsis.Plataforma.Test.Modelo", "Distrito");
            IContexto contexto = new ContextoSQLite(_cadenaConexion);
            IDAS das = new DAS(_configuracion, contexto);

            IDiagramaDatos dd ;
            IObjetoDatos od;
            IObjetoDatos od2;

            // crear
            od = fabrica.Crear(tipo);
            od.Establecer("Id", 1);
            od.Establecer("Nombre", "CHORRILLOS");

            dd = CrearDiagramaDatos(tipo, od, null);
            das.AplicarCambios(dd);

            // modificar
            ICopyHelper copiaHelper = new CopyHelper(fabrica);
            od2 = copiaHelper.Copiar(od);
            od2.Establecer("Nombre", "CHORRILLOS2");

            dd = CrearDiagramaDatos(tipo, od2, od);
            das.AplicarCambios(dd);

            // eliminar
            dd = CrearDiagramaDatos(tipo, null as IObjetoDatos, od2);
            das.AplicarCambios(dd);


            Assert.IsTrue(true);
        }

        [TestMethod, TestCategory("Evaluar Servicio de acceso de datos")]
        public void EvaluarDASProvincia()
        {
            IFabrica fabrica = FabricaDatos.Instancia;
            ITipo tipo = _configuracion.ObtenerTipo("Binapsis.Plataforma.Test.Modelo", "Provincia");
            IContexto contexto = new ContextoSQLite(_cadenaConexion);
            IDAS das = new DAS(_configuracion, contexto);

            IDiagramaDatos dd;
            IObjetoDatos od;
            IObjetoDatos od2;

            // crear
            od = fabrica.Crear(tipo);
            od.Establecer("Id", 1);
            od.Establecer("Nombre", "LIMA");

            dd = CrearDiagramaDatos(tipo, od, null);
            das.AplicarCambios(dd);

            // modificar
            ICopyHelper copiaHelper = new CopyHelper(fabrica);
            od2 = copiaHelper.Copiar(od);
            od2.Establecer("Nombre", "LIMA2");

            dd = CrearDiagramaDatos(tipo, od2, od);
            das.AplicarCambios(dd);

            // eliminar
            dd = CrearDiagramaDatos(tipo, null as IObjetoDatos, od2);
            das.AplicarCambios(dd);
            
            Assert.IsTrue(true);
        }

        [TestMethod, TestCategory("Evaluar Servicio de acceso de datos")]
        public void EvaluarDASDepartamento()
        {
            IFabrica fabrica = FabricaDatos.Instancia;
            ITipo tipo = _configuracion.ObtenerTipo("Binapsis.Plataforma.Test.Modelo", "Departamento");
            IContexto contexto = new ContextoSQLite(_cadenaConexion);
            IDAS das = new DAS(_configuracion, contexto);

            IDiagramaDatos dd;
            IObjetoDatos od;
            IObjetoDatos od2;

            // crear
            od = fabrica.Crear(tipo);
            od.Establecer("Id", 1);
            od.Establecer("Nombre", "LIMA");

            dd = CrearDiagramaDatos(tipo, od, null);
            das.AplicarCambios(dd);

            // modificar
            ICopyHelper copiaHelper = new CopyHelper(fabrica);
            od2 = copiaHelper.Copiar(od);
            od2.Establecer("Nombre", "LIMA2");

            dd = CrearDiagramaDatos(tipo, od2, od);
            das.AplicarCambios(dd);

            // eliminar
            dd = CrearDiagramaDatos(tipo, null as IObjetoDatos, od2);
            das.AplicarCambios(dd);

            Assert.IsTrue(true);
        }

        [TestMethod, TestCategory("Evaluar Servicio de acceso de datos")]
        public void EvaluarDASUbigeo()
        {
            IFabrica fabrica = FabricaDatos.Instancia;
            ITipo tipo = _configuracion.ObtenerTipo("Binapsis.Plataforma.Test.Modelo", "Ubigeo");
            IContexto contexto = new ContextoSQLite(_cadenaConexion);
            IDAS das = new DAS(_configuracion, contexto);
            IList items = new List<DiagramaDatos>();
                        
            IObjetoDatos od;            

            IObjetoDatos distrito = fabrica.Crear(_configuracion.ObtenerTipo("Binapsis.Plataforma.Test.Modelo", "Distrito"));
            distrito.Establecer("Id", 1);
            distrito.Establecer("Nombre", "LIMA");
            items.Add(CrearDiagramaDatos(distrito.Tipo, distrito, null));

            IObjetoDatos provincia = fabrica.Crear(_configuracion.ObtenerTipo("Binapsis.Plataforma.Test.Modelo", "Provincia"));
            provincia.Establecer("Id", 1);
            provincia.Establecer("Nombre", "LIMA");
            items.Add(CrearDiagramaDatos(provincia.Tipo, provincia, null));

            IObjetoDatos departamento = fabrica.Crear(_configuracion.ObtenerTipo("Binapsis.Plataforma.Test.Modelo", "Departamento"));
            departamento.Establecer("Id", 1);
            departamento.Establecer("Nombre", "LIMA");
            items.Add(CrearDiagramaDatos(departamento.Tipo, departamento, null));
            
            // crear
            od = fabrica.Crear(tipo);

            od.Establecer("Id", 1);
            od.Establecer("Codigo", "151501");
            od.Establecer("Departamento", departamento);
            od.Establecer("Provincia", provincia);
            od.Establecer("Distrito", distrito);

            items.Add(CrearDiagramaDatos(tipo, od, null));

            // modificar
            ICopyHelper copiaHelper = new CopyHelper(fabrica);
            IObjetoDatos od2 = copiaHelper.Copiar(od);

            IObjetoDatos distrito2 = fabrica.Crear(_configuracion.ObtenerTipo("Binapsis.Plataforma.Test.Modelo", "Distrito"));
            distrito2.Establecer("Id", 2);
            distrito2.Establecer("Nombre", "CHORRILLOS");

            od2.Establecer("Codigo", "151502");
            od2.Establecer("Distrito", distrito2);

            items.Add(CrearDiagramaDatos(distrito2.Tipo, distrito2, null));
            items.Add(CrearDiagramaDatos(tipo, od2, od));

            // eliminar
            items.Add(CrearDiagramaDatos(tipo, null, od2));
            items.Add(CrearDiagramaDatos(distrito2.Tipo, null, distrito2));
            items.Add(CrearDiagramaDatos(distrito.Tipo, null, distrito));
            items.Add(CrearDiagramaDatos(provincia.Tipo, null, provincia));
            items.Add(CrearDiagramaDatos(departamento.Tipo, null, departamento));


            das.AplicarCambios(items);


            Assert.IsTrue(true);

        }

        [TestMethod, TestCategory("Evaluar Servicio de acceso de datos")]
        public void EvaluarDASCliente()
        {
            IFabrica fabrica = FabricaDatos.Instancia;
            ITipo tipo = _configuracion.ObtenerTipo("Binapsis.Plataforma.Test.Modelo", "Cliente");
            IContexto contexto = new ContextoSQLite(_cadenaConexion);
            IDAS das = new DAS(_configuracion, contexto);
            IList items = new List<DiagramaDatos>();
                       

            IObjetoDatos distrito = fabrica.Crear(_configuracion.ObtenerTipo("Binapsis.Plataforma.Test.Modelo", "Distrito"));
            distrito.Establecer("Id", 1);
            distrito.Establecer("Nombre", "LIMA");
            items.Add(CrearDiagramaDatos(distrito.Tipo, distrito, null));

            IObjetoDatos provincia = fabrica.Crear(_configuracion.ObtenerTipo("Binapsis.Plataforma.Test.Modelo", "Provincia"));
            provincia.Establecer("Id", 1);
            provincia.Establecer("Nombre", "LIMA");
            items.Add(CrearDiagramaDatos(provincia.Tipo, provincia, null));

            IObjetoDatos departamento = fabrica.Crear(_configuracion.ObtenerTipo("Binapsis.Plataforma.Test.Modelo", "Departamento"));
            departamento.Establecer("Id", 1);
            departamento.Establecer("Nombre", "LIMA");
            items.Add(CrearDiagramaDatos(departamento.Tipo, departamento, null));
            
            IObjetoDatos ubigeo = fabrica.Crear(_configuracion.ObtenerTipo("Binapsis.Plataforma.Test.Modelo", "Ubigeo"));
            ubigeo.Establecer("Id", 1);
            ubigeo.Establecer("Codigo", "151501");
            ubigeo.Establecer("Departamento", departamento);
            ubigeo.Establecer("Provincia", provincia);
            ubigeo.Establecer("Distrito", distrito);
            items.Add(CrearDiagramaDatos(ubigeo.Tipo, ubigeo, null));

            // crear
            IObjetoDatos od = fabrica.Crear(tipo);
            od.Establecer("Id", 1);
            od.Establecer("Nombres", "JUAN PEREZ");

            IObjetoDatos direccion = od.CrearObjetoDatos("Direcciones");
            direccion.Establecer("Id", 1);
            direccion.Establecer("Descripcion", "JR. ILO 125");
            direccion.Establecer("Ubigeo", ubigeo);

            items.Add(CrearDiagramaDatos(tipo, od, null));

            // modificar agregar direccion
            ICopyHelper copyHelper = new CopyHelper(fabrica);
            IObjetoDatos od2 = copyHelper.Copiar(od);

            IObjetoDatos direccion2 = od2.CrearObjetoDatos("Direcciones");
            direccion2.Establecer("Id", 2);
            direccion2.Establecer("Descripcion", "AV. WILSON 556");
            direccion2.Establecer("Ubigeo", ubigeo);

            items.Add(CrearDiagramaDatos(tipo, od2, od));

            // modificar direccion
            IObjetoDatos distrito2 = fabrica.Crear(_configuracion.ObtenerTipo("Binapsis.Plataforma.Test.Modelo", "Distrito"));
            distrito2.Establecer("Id", 2);
            distrito2.Establecer("Nombre", "CHORRILLOS");
            items.Add(CrearDiagramaDatos(distrito2.Tipo, distrito2, null));

            IObjetoDatos ubigeo2 = fabrica.Crear(_configuracion.ObtenerTipo("Binapsis.Plataforma.Test.Modelo", "Ubigeo"));
            ubigeo2.Establecer("Id", 2);
            ubigeo2.Establecer("Codigo", "151502");
            ubigeo2.Establecer("Departamento", departamento);
            ubigeo2.Establecer("Provincia", provincia);
            ubigeo2.Establecer("Distrito", distrito2);
            items.Add(CrearDiagramaDatos(ubigeo2.Tipo, ubigeo2, null));

            IObjetoDatos od3 = copyHelper.Copiar(od2);
            od3.RemoverObjetoDatos("Direcciones", od3.ObtenerObjetoDatos("Direcciones[1]"));
            od3.Establecer("Direcciones[0]/Descripcion", "AV. SAN JUAN 7844");
            od3.Establecer("Direcciones[0]/Ubigeo", ubigeo2);
            od3.Establecer("Nombres", "JUAN DIAZ");
                        
            items.Add(CrearDiagramaDatos(tipo, od3, od2));

            // eliminar
            items.Add(CrearDiagramaDatos(tipo, null, od3));
            items.Add(CrearDiagramaDatos(ubigeo.Tipo, null, ubigeo));
            items.Add(CrearDiagramaDatos(ubigeo2.Tipo, null, ubigeo2));
            items.Add(CrearDiagramaDatos(distrito2.Tipo, null, distrito2));
            items.Add(CrearDiagramaDatos(distrito.Tipo, null, distrito));
            items.Add(CrearDiagramaDatos(provincia.Tipo, null, provincia));
            items.Add(CrearDiagramaDatos(departamento.Tipo, null, departamento));


            das.AplicarCambios(items);


            Assert.IsTrue(true);

        }

        private IDiagramaDatos CrearDiagramaDatos(ITipo tipo, IObjetoDatos nuevo, IObjetoDatos antiguo)
        {
            IDiagramaDatos dd = new DiagramaDatos(tipo);
            BuilderDiagramaDatos builder = new BuilderDiagramaDatos(dd);
            builder.Construir(nuevo, antiguo);
            return dd;
        }
    }
}
