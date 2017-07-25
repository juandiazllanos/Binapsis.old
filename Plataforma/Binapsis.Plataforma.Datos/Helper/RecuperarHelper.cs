using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Datos.Builder;
using Binapsis.Plataforma.Datos.Heap;
using Binapsis.Plataforma.Datos.Impl;
using Binapsis.Plataforma.Datos.Mapeo;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Estructura.Impl;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Binapsis.Plataforma.Datos.Helper
{
    class RecuperarHelper
    {
        public RecuperarHelper(MapeoCatalogo mapeoCatalogo)
        {
            ConsultaHelper = new ConsultaHelper(mapeoCatalogo);
            MapeoCatalogo = mapeoCatalogo;            
        }

        #region Metodos
        //public ComandoLectura CrearConsulta(ITipo tipo)
        //{
        //    MapeoTabla mapeoTabla = MapeoCatalogo.ObtenerMapeoTabla(tipo);
        //    return CrearConsulta(mapeoTabla);
        //}

        //public ComandoLectura CrearConsulta(ITipo tipo, IPropiedad propiedad)
        //{
        //    MapeoTabla mapeoTabla = MapeoCatalogo.ObtenerMapeoTabla(tipo);
        //    if (mapeoTabla == null) throw new Exception($"El tipo '{tipo.Nombre}' no esta asociado a una tabla");

        //    if (propiedad.Tipo.EsTipoDeDato)
        //        return CrearConsultaAtributo(mapeoTabla, propiedad);
        //    else
        //        return CrearConsultaReferencia(mapeoTabla, propiedad);
        //}

        //private ComandoLectura CrearConsultaAtributo(MapeoTabla mapeoTabla, IPropiedad propiedad)
        //{
        //    MapeoColumna mapeoColumna = mapeoTabla?.ObtenerMapeoColumnaPorPropiedad(propiedad.Nombre);
        //    if (mapeoColumna == null) throw new Exception($"La propiedad '{propiedad.Nombre}' no esta asociado a una columna.");

        //    return CrearConsulta(mapeoTabla, mapeoColumna);
        //}

        //private ComandoLectura CrearConsultaReferencia(MapeoTabla mapeoTabla, IPropiedad propiedad)
        //{
        //    MapeoRelacion mapeoRelacion = mapeoTabla.ObtenerMapeoRelacionPorPropiedad(propiedad);
        //    if (mapeoRelacion == null) throw new Exception($"La propiedad '{propiedad.Nombre}' no está asociada a una relación.");

        //    IList<MapeoColumna> mapeoColumnas = mapeoRelacion.Claves.Select(item => item.ClaveSecundaria).ToList();

        //    return CrearConsulta(mapeoTabla, mapeoColumnas);
        //}

        //public ComandoLectura CrearConsulta(MapeoTabla mapeoTabla)
        //{
        //    IList<MapeoColumna> columnas = mapeoTabla.Columnas.Where(item => item.Columna.ClavePrimaria).ToList();
        //    if (columnas.Count == 0) throw new Exception($"La tabla '{mapeoTabla.Tabla.Nombre}' no tiene claves primarias.");

        //    return CrearConsulta(mapeoTabla, columnas);
        //}

        //private ComandoLectura CrearConsulta(MapeoTabla mapeoTabla, MapeoColumna mapeoColumna)
        //{
        //    IList<MapeoColumna> columnas = new List<MapeoColumna> { mapeoColumna };
        //    return CrearConsulta(mapeoTabla, mapeoColumna);
        //}

        //private ComandoLectura CrearConsulta(MapeoTabla mapeoTabla, IList<MapeoColumna> mapeoColumnas)
        //{
        //    Comando comando = Configuracion.Fabrica.Instancia.Crear<Comando>();
        //    BuilderComandoSelect builder = new BuilderComandoSelect(comando);

        //    builder.MapeoTabla = mapeoTabla;
        //    builder.ParametroColumnas = mapeoColumnas;
        //    // construir comando
        //    builder.Construir();

        //    return new ComandoLectura(comando, mapeoTabla);
        //}

        //public ComandoLectura CrearConsultaTablaSecundaria(MapeoRelacion mapeoRelacion)
        //{
        //    IList<MapeoColumna> mapeoColumnas = mapeoRelacion.Claves.Select(item => item.ClaveSecundaria).ToList();
        //    return CrearConsulta(mapeoRelacion.TablaSecundaria, mapeoColumnas);
        //}

        //public ComandoLectura CrearConsultaTablaPrincipal(MapeoRelacion mapeoRelacion)
        //{
        //    IList<MapeoColumna> mapeoColumnas = mapeoRelacion.Claves.Select(item => item.ClavePrincipal).ToList();
        //    return CrearConsulta(mapeoRelacion.TablaPrincipal, mapeoColumnas);
        //}
        
        public IObjetoDatos Recuperar(ComandoLectura consulta)
        {   
            IObjetoDatos od = Fabrica.Crear(consulta.MapeoTabla.Tipo);
            Func<IObjetoDatos> fabrica = () => od;
            Recuperar(consulta, fabrica, 1);
            return od;

            //int i = 0;
            
            //// ejecutar consulta
            //IResultado resultado = Contexto.EjecutarConsulta(consulta);
            //ResultadoTabla resultadoTabla = new ResultadoTabla(consulta.MapeoTabla, resultado);

            //while (resultadoTabla.Siguiente())
            //{
            //    // validar referencia simple
            //    if (i++ > 0) throw new Exception($"La consulta produjo {i} filas para el tipo '{consulta.MapeoTabla.Tipo.Nombre}'.");
            //    // instanciar od
            //    od = Fabrica.Crear(consulta.MapeoTabla.Tipo);
            //    // agregar al monton
            //    Heap.Agregar(od, resultadoTabla.ObtenerClavePrincipal());
            //    // construir
            //    ConstruirObjetoDatos(od, resultadoTabla);
            //}

            //return od;
        }

        public IColeccion RecuperarColeccion(ComandoLectura consulta)
        {
            Coleccion coleccion = new Coleccion();
            Func<IObjetoDatos> fabrica = () => coleccion.Agregar(Fabrica.Crear(consulta.MapeoTabla.Tipo));

            Recuperar(consulta, fabrica);

            return coleccion;
        }

        public void Recuperar(IObjetoDatos propietario, IPropiedad propiedad, ComandoLectura consulta)
        {
            Func<IObjetoDatos> fabrica = () => propietario.CrearObjetoDatos(propiedad);
            int maximoItems = propiedad.EsColeccion ? 0 : 1;
            Recuperar(consulta, fabrica, maximoItems);

            //IObjetoDatos od = null;
            //int i = 0;

            //// ejecutar consulta
            //IResultado resultado = Contexto.EjecutarConsulta(consulta);
            //ResultadoTabla resultadoTabla = new ResultadoTabla(consulta.MapeoTabla, resultado);

            //while (resultadoTabla.Siguiente())
            //{
            //    // validar referencia simple
            //    if (!propiedad.EsColeccion && i++ > 0) throw new Exception($"La consulta produjo {i} filas para la propiedad '{propiedad.Nombre}'.");
            //    // instanciar od
            //    od = propietario.CrearObjetoDatos(propiedad);
            //    // agregar al monton
            //    Heap.Agregar(od, resultadoTabla.ObtenerClavePrincipal());
            //    // construir
            //    ConstruirObjetoDatos(od, resultadoTabla);
            //}
        }


        public void Recuperar(ComandoLectura consulta, Func<IObjetoDatos> fabrica, int maximoItems = 0)
        {
            IObjetoDatos od = null;
            int i = 0;

            // ejecutar consulta
            IResultado resultado = Contexto.EjecutarConsulta(consulta);
            ResultadoTabla resultadoTabla = new ResultadoTabla(consulta.MapeoTabla, resultado);

            while (resultadoTabla.Siguiente())
            {
                // validar referencia simple                
                if (maximoItems > 0 && maximoItems <= i++) throw new Exception($"La consulta produjo {i} filas de la tabla '{consulta.MapeoTabla?.Tabla.Nombre}'.");                
                // instanciar od
                od = fabrica.Invoke();
                // agregar al monton
                Heap?.Agregar(od, resultadoTabla.ObtenerClavePrincipal());
                // construir
                ConstruirObjetoDatos(od, resultadoTabla);
            }
        }


        private void ConstruirObjetoDatos(IObjetoDatos od, ResultadoTabla resultadoTabla)
        {
            BuilderObjetoDatos builder = new BuilderObjetoDatos(od);
            
            builder.Datos = resultadoTabla;
            builder.ConsultaHelper = ConsultaHelper;
            builder.RecuperarHelper = this;
            builder.MapeoCatalogo = MapeoCatalogo;
            builder.MapeoTabla = resultadoTabla.MapeoTabla;

            builder.Construir();
        }        
        #endregion


        #region Propiedades
        public ConsultaHelper ConsultaHelper
        {
            get;
        }

        public IContexto Contexto
        {
            get;
            set;
        }

        public IFabrica Fabrica
        {
            get;
            set;
        }

        public HeapObjetoDatos Heap
        {
            get;
            set;
        }

        public MapeoCatalogo MapeoCatalogo
        {
            get;
            //set;
        }
        #endregion 
    }
}
