
using Binapsis.Plataforma.Cambios;
using Binapsis.Plataforma.Cambios.Builder;
using Binapsis.Plataforma.Cambios.Impl;
using Binapsis.Plataforma.Datos;
using Binapsis.Plataforma.Datos.Impl;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Helper;
using Binapsis.Plataforma.Helper.Impl;

namespace Binapsis.Plataforma.ServicioDatos.Operaciones
{
    class Operacion
    {
        #region Constructores
        public Operacion(IConfiguracion configuracion, IContexto contexto)
        {
            Contexto = contexto;
            Configuracion = configuracion;
        }
        #endregion


        #region Metodos        
        public virtual void Ejecutar(IDiagramaDatos dd)
        {
            IDAS das = new DAS(Configuracion, Contexto);
            das.AplicarCambios(dd);
        }

        public virtual void Ejecutar(IDiagramaDatos[] dd)
        {
            IDAS das = new DAS(Configuracion, Contexto);
            das.AplicarCambios(dd);
        }

        protected virtual IDiagramaDatos CrearDiagramaDatos(IObjetoDatos od)
        {
            return CrearDiagramaDatos(od, null);
        }

        protected virtual IDiagramaDatos CrearDiagramaDatos(IObjetoDatos nuevo, IObjetoDatos antiguo)
        {
            ITipo tipo = nuevo?.Tipo ?? antiguo?.Tipo;
            if (tipo == null) return null;

            IDiagramaDatos dd = new DiagramaDatos(tipo);
            BuilderDiagramaDatos builder = new BuilderDiagramaDatos(dd);
            builder.Construir(nuevo, antiguo);

            return dd;
        }

        protected virtual IObjetoDatos RecuperarAntiguo(IObjetoDatos nuevo)
        {
            IKey key = KeyHelper.Instancia.GetKey(nuevo);

            if (key != null)
                return RecuperarAntiguo(nuevo.Tipo, key);
            else 
                return null;
        }

        protected virtual IObjetoDatos RecuperarAntiguo(ITipo tipo, IKey key)
        {
            Recuperar recuperar = new Recuperar(Contexto, Configuracion, tipo);

            for (int i = 0; i < key.Longitud; i++)
                recuperar.Establecer(key.Properties[i], key.Values[0]);

            return recuperar.EjecutarConsultaSimple();            
        }
        #endregion


        #region Propiedades
        public IConfiguracion Configuracion
        {
            get;
        }

        public IContexto Contexto
        {
            get;
        }
        #endregion
    }
}
