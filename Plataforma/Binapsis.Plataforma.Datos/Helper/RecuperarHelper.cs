using Binapsis.Plataforma.Datos.Builder;
using Binapsis.Plataforma.Datos.Heap;
using Binapsis.Plataforma.Datos.Impl;
using Binapsis.Plataforma.Datos.Mapeo;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Estructura.Impl;
using System;

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
        public IObjetoDatos Recuperar(ComandoLectura consulta)
        {
            IObjetoDatos od = null; //Fabrica.Crear(consulta.MapeoTabla.Tipo);
            Func<IObjetoDatos> fabrica = () => od = Fabrica.Crear(consulta.MapeoTabla.Tipo);
            Recuperar(consulta, fabrica, 1);
            return od;
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
