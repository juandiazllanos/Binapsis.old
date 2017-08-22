using Binapsis.Plataforma.Cambios;
using Binapsis.Plataforma.Cambios.Builder;
using Binapsis.Plataforma.Cambios.Impl;
using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Datos;
using Binapsis.Plataforma.Datos.Helper;
using Binapsis.Plataforma.Datos.Impl;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.Helper;
using Binapsis.Plataforma.Helper.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;

namespace Binapsis.Plataforma.Test.Datos
{
    public abstract class EvaluarDAS
    {
        IConfiguracion _configuracion = new Impl.Configuracion();
        
        public abstract IContexto ObtenerContexto();
                
        public virtual void EvaluarDASComando()
        {
            IContexto contexto = ObtenerContexto();
            IDAS das = new DAS(_configuracion, contexto);
            IComando comando = das.ObtenerComando("CrearId");
            comando.EstablecerParametro("clave", "Distrito");
            comando.EstablecerParametro("id", 0);
            comando.Ejecutar();

            int id = (int)comando.ObtenerParametro("id");

            Assert.AreNotEqual(0, id);
        }

        public virtual void EvaluarDASConsultaComando()
        {
            List<IDiagramaDatos> items = new List<IDiagramaDatos>();

            IFabrica fabrica = FabricaDatos.Instancia;
            IContexto contexto = ObtenerContexto();
            IDAS das = new DAS(_configuracion, contexto);

            ITipo tipo = _configuracion.ObtenerTipo("Binapsis.Plataforma.Test.Modelo", "Distrito");
            IObjetoDatos od = fabrica.Crear(tipo);

            od.Establecer("Id", 1);
            od.Establecer("Nombre", "LIMA");
            items.Add(CrearDiagramaDatos(tipo, od, null));

            od = fabrica.Crear(tipo);
            od.Establecer("Id", 2);
            od.Establecer("Nombre", "CHORRILLOS");
            items.Add(CrearDiagramaDatos(tipo, od, null));

            od = fabrica.Crear(tipo);
            od.Establecer("Id", 3);
            od.Establecer("Nombre", "SAN JUAN DE MIRAFLORES");
            items.Add(CrearDiagramaDatos(tipo, od, null));

            od = fabrica.Crear(tipo);
            od.Establecer("Id", 4);
            od.Establecer("Nombre", "SAN JUAN DE LURIGANCHO");
            items.Add(CrearDiagramaDatos(tipo, od, null));
            
            od = fabrica.Crear(tipo);
            od.Establecer("Id", 5);
            od.Establecer("Nombre", "SAN BORJA");
            items.Add(CrearDiagramaDatos(tipo, od, null));
            
            od = fabrica.Crear(tipo);
            od.Establecer("Id", 6);
            od.Establecer("Nombre", "LINCE");
            items.Add(CrearDiagramaDatos(tipo, od, null));

            od = fabrica.Crear(tipo);
            od.Establecer("Id", 7);
            od.Establecer("Nombre", "MIRAFLORES");
            items.Add(CrearDiagramaDatos(tipo, od, null));

            das.AplicarCambios(items);

            // consultar
            Comando consulta = Fabrica.Instancia.Crear<Comando>();
            consulta.Nombre = "DistritoPorNombre";
            consulta.Sql = "SELECT DISTRITO.NOMBRE as Nombre FROM Distrito WHERE DISTRITO.NOMBRE LIKE @Nombre";

            consulta.CrearParametro("Nombre", typeof(string));
            consulta.CrearResultadoDescriptor("Nombre", typeof(string));

            IComando comando = das.CrearComando(consulta);

            // consulta Distrito.Nombre LIKE SAN%
            comando.EstablecerParametro(0, "SAN%");
            IColeccion resultado1 = comando.EjecutarConsulta();

            // consulta Distrito.Nombre LIKE %MIRAFLORES
            comando.EstablecerParametro(0, "%MIRAFLORES");
            IColeccion resultado2 = comando.EjecutarConsulta();

            // consulta Distrito.Nombre LIKE LINCE%
            comando.EstablecerParametro(0, "LINCE%");
            IColeccion resultado3 = comando.EjecutarConsulta();

            // eliminar
            IList eliminar = new List<IDiagramaDatos>();

            for (int i = 0; i < items.Count; i++)
                eliminar.Add(CrearDiagramaDatos((items[i] as IDiagramaDatos).Tipo, null, (items[i] as IDiagramaDatos).ObjetoDatos));

            das.AplicarCambios(eliminar);

            // evaluar
            Assert.AreEqual(3, resultado1.Longitud);
            Assert.AreEqual(2, resultado2.Longitud);
            Assert.AreEqual(1, resultado3.Longitud);

        }
                
        public virtual void EvaluarDASConsultaColeccion()
        {
            List<IDiagramaDatos> items = new List<IDiagramaDatos>();

            IFabrica fabrica = FabricaDatos.Instancia;            
            IContexto contexto = ObtenerContexto();
            IDAS das = new DAS(_configuracion, contexto);

            ITipo tipo = _configuracion.ObtenerTipo("Binapsis.Plataforma.Test.Modelo", "Distrito");
            IObjetoDatos od = fabrica.Crear(tipo);

            od.Establecer("Id", 1);
            od.Establecer("Nombre", "LIMA");
            items.Add(CrearDiagramaDatos(tipo, od, null));

            od = fabrica.Crear(tipo);
            od.Establecer("Id", 2);
            od.Establecer("Nombre", "CHORRILLOS");
            items.Add(CrearDiagramaDatos(tipo, od, null));

            od = fabrica.Crear(tipo);
            od.Establecer("Id", 3);
            od.Establecer("Nombre", "SAN JUAN DE MIRAFLORES");
            items.Add(CrearDiagramaDatos(tipo, od, null));

            tipo = _configuracion.ObtenerTipo("Binapsis.Plataforma.Test.Modelo", "Provincia");

            od = fabrica.Crear(tipo);
            od.Establecer("Id", 1);
            od.Establecer("Nombre", "LIMA");
            items.Add(CrearDiagramaDatos(tipo, od, null));

            tipo = _configuracion.ObtenerTipo("Binapsis.Plataforma.Test.Modelo", "Departamento");

            od = fabrica.Crear(tipo);
            od.Establecer("Id", 1);
            od.Establecer("Nombre", "LIMA");
            items.Add(CrearDiagramaDatos(tipo, od, null));

            tipo = _configuracion.ObtenerTipo("Binapsis.Plataforma.Test.Modelo", "Ubigeo");

            od = fabrica.Crear(tipo);
            od.Establecer("Id", 1);
            od.Establecer("Codigo", "151501");
            od.Establecer("Departamento", (items[4] as IDiagramaDatos).ObjetoDatos);
            od.Establecer("Provincia", (items[3] as IDiagramaDatos).ObjetoDatos);
            od.Establecer("Distrito", (items[0] as IDiagramaDatos).ObjetoDatos);
            items.Add(CrearDiagramaDatos(tipo, od, null));

            od = fabrica.Crear(tipo);
            od.Establecer("Id", 2);
            od.Establecer("Codigo", "151502");
            od.Establecer("Departamento", (items[4] as IDiagramaDatos).ObjetoDatos);
            od.Establecer("Provincia", (items[3] as IDiagramaDatos).ObjetoDatos);
            od.Establecer("Distrito", (items[1] as IDiagramaDatos).ObjetoDatos);
            items.Add(CrearDiagramaDatos(tipo, od, null));

            od = fabrica.Crear(tipo);
            od.Establecer("Id", 3);
            od.Establecer("Codigo", "151503");
            od.Establecer("Departamento", (items[4] as IDiagramaDatos).ObjetoDatos);
            od.Establecer("Provincia", (items[3] as IDiagramaDatos).ObjetoDatos);
            od.Establecer("Distrito", (items[2] as IDiagramaDatos).ObjetoDatos);
            items.Add(CrearDiagramaDatos(tipo, od, null));

            das.AplicarCambios(items);

            IComando comando = das.CrearComando(tipo, new IPropiedad[] { tipo.ObtenerPropiedad("Departamento") });
            ComandoHelper comandoHelper = new ComandoHelper(comando);
            comandoHelper.EstablecerParametro(tipo.ObtenerPropiedad("Departamento"), (items[4] as IDiagramaDatos).ObjetoDatos);

            IColeccion coleccion1 = comando.EjecutarConsulta();
            
            comando = das.CrearComando(tipo, new IPropiedad[] { tipo.ObtenerPropiedad("Distrito") });
            comandoHelper = new ComandoHelper(comando);
            comandoHelper.EstablecerParametro(tipo.ObtenerPropiedad("Distrito"), (items[2] as IDiagramaDatos).ObjetoDatos);

            IColeccion coleccion2 = comando.EjecutarConsulta();

            // eliminar
            IList eliminar = new List<IDiagramaDatos>();

            for (int i = 0; i < items.Count; i++)
                eliminar.Add(CrearDiagramaDatos((items[i] as IDiagramaDatos).Tipo, null, (items[i] as IDiagramaDatos).ObjetoDatos));

            das.AplicarCambios(eliminar);
            
            Assert.AreEqual(1, coleccion2.Longitud);
            Assert.AreEqual(3, coleccion1.Longitud);

        }
                
        public virtual void EvaluarDASDistrito()
        {
            IFabrica fabrica = FabricaDatos.Instancia;
            ITipo tipo = _configuracion.ObtenerTipo("Binapsis.Plataforma.Test.Modelo", "Distrito");
            IContexto contexto = ObtenerContexto();
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

            // recuperar
            IComando comando = das.CrearComando(tipo);
            comando.EstablecerParametro(0, 1);

            IObjetoDatos od3 = comando.EjecutarConsultaSimple(); //das.RecuperarObjetoDatos(tipo, tipo.ObtenerPropiedad("Id"), 1);
            
            // eliminar
            dd = CrearDiagramaDatos(tipo, null as IObjetoDatos, od2);
            das.AplicarCambios(dd);

            IEqualityHelper igualHelper = EqualityHelper.Instancia;

            Assert.IsTrue(igualHelper.Igual(od2, od3));
        }
                
        public virtual void EvaluarDASProvincia()
        {
            IFabrica fabrica = FabricaDatos.Instancia;
            ITipo tipo = _configuracion.ObtenerTipo("Binapsis.Plataforma.Test.Modelo", "Provincia");
            IContexto contexto = ObtenerContexto();
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

            // recuperar
            IComando comando = das.CrearComando(tipo);
            comando.EstablecerParametro(0, 1);
            IObjetoDatos od3 = comando.EjecutarConsultaSimple();

            // eliminar
            dd = CrearDiagramaDatos(tipo, null as IObjetoDatos, od2);
            das.AplicarCambios(dd);


            IEqualityHelper igualHelper = EqualityHelper.Instancia;

            Assert.IsTrue(igualHelper.Igual(od2, od3));
        }
                
        public virtual void EvaluarDASDepartamento()
        {
            IFabrica fabrica = FabricaDatos.Instancia;
            ITipo tipo = _configuracion.ObtenerTipo("Binapsis.Plataforma.Test.Modelo", "Departamento");
            IContexto contexto = ObtenerContexto();
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

            // recuperar
            IComando comando = das.CrearComando(tipo);
            comando.EstablecerParametro(0, 1);
            IObjetoDatos od3 = comando.EjecutarConsultaSimple(); //das.RecuperarObjetoDatos(tipo, tipo.ObtenerPropiedad("Id"), 1);

            // eliminar
            dd = CrearDiagramaDatos(tipo, null as IObjetoDatos, od2);
            das.AplicarCambios(dd);


            IEqualityHelper igualHelper = EqualityHelper.Instancia;

            Assert.IsTrue(igualHelper.Igual(od2, od3));

        }
                
        public virtual void EvaluarDASUbigeo()
        {
            IFabrica fabrica = FabricaDatos.Instancia;
            ITipo tipo = _configuracion.ObtenerTipo("Binapsis.Plataforma.Test.Modelo", "Ubigeo");
            IContexto contexto = ObtenerContexto();
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

            // ejecutar
            das.AplicarCambios(items);

            // recuperar
            IComando comando = das.CrearComando(tipo);
            comando.EstablecerParametro(0, 1);
            IObjetoDatos od3 = comando.EjecutarConsultaSimple(); //das.RecuperarObjetoDatos(tipo, tipo.ObtenerPropiedad("Id"), 1);

            // eliminar
            items = new List<IDiagramaDatos>();
            items.Add(CrearDiagramaDatos(tipo, null, od2));
            items.Add(CrearDiagramaDatos(distrito2.Tipo, null, distrito2));
            items.Add(CrearDiagramaDatos(distrito.Tipo, null, distrito));
            items.Add(CrearDiagramaDatos(provincia.Tipo, null, provincia));
            items.Add(CrearDiagramaDatos(departamento.Tipo, null, departamento));


            das.AplicarCambios(items);
            

            Assert.IsTrue(EqualityHelper.Instancia.Igual(od2, od3));

        }
                
        public virtual void EvaluarDASCliente()
        {
            IFabrica fabrica = FabricaDatos.Instancia;
            ITipo tipo = _configuracion.ObtenerTipo("Binapsis.Plataforma.Test.Modelo", "Cliente");
            IContexto contexto = ObtenerContexto();
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

            // ejecutar
            das.AplicarCambios(items);
            items = new List<IDiagramaDatos>();

            // recuperar
            IComando comando = das.CrearComando(tipo);
            comando.EstablecerParametro(0, 1);
            IObjetoDatos odr2 = comando.EjecutarConsultaSimple(); //das.RecuperarObjetoDatos(tipo, tipo.ObtenerPropiedad("Id"), 1);

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

            // ejecutar
            das.AplicarCambios(items);
            items = new List<IDiagramaDatos>();


            // recuperar
            comando = das.CrearComando(tipo);
            comando.EstablecerParametro(0, 1);
            IObjetoDatos odr3 = comando.EjecutarConsultaSimple(); //das.RecuperarObjetoDatos(tipo, tipo.ObtenerPropiedad("Id"), 1);
            

            // eliminar            
            items.Add(CrearDiagramaDatos(tipo, null, od3));
            items.Add(CrearDiagramaDatos(ubigeo.Tipo, null, ubigeo));
            items.Add(CrearDiagramaDatos(ubigeo2.Tipo, null, ubigeo2));
            items.Add(CrearDiagramaDatos(distrito2.Tipo, null, distrito2));
            items.Add(CrearDiagramaDatos(distrito.Tipo, null, distrito));
            items.Add(CrearDiagramaDatos(provincia.Tipo, null, provincia));
            items.Add(CrearDiagramaDatos(departamento.Tipo, null, departamento));


            das.AplicarCambios(items);


            // evaluar
            Assert.IsTrue(EqualityHelper.Instancia.Igual(od2, odr2));
            Assert.AreEqual(odr2.ObtenerObjetoDatos("Direcciones[0]/Ubigeo/Departamento"), odr2.ObtenerObjetoDatos("Direcciones[1]/Ubigeo/Departamento"));
            Assert.IsTrue(EqualityHelper.Instancia.Igual(od3, odr3));

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
