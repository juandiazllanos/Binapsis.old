using Binapsis.Plataforma.Configuracion.Presentacion.Navegacion;
using System;
using System.Threading.Tasks;

namespace Binapsis.Plataforma.Configuracion.Presentacion
{
    public class Consola : IContexto
    {
        internal const string RECURSO_CONSULTA = "CONSULTA";
        internal const string RECURSO_FABRICA = "FABRICA";
        internal const string RECURSO_TYPE = "TYPE";


        public delegate void AccionTerminarHandler(object sender, AccionResultadoEventArgs args);
        public delegate void AccionIniciarHandler(object sender, AccionEventArgs args);

        public event AccionTerminarHandler AccionTerminar;
        public event AccionIniciarHandler AccionIniciar;
        
        #region Constructores
        public Consola(Repositorio repositorio)
        {
            Repositorio = repositorio;

            // inicializar           
            Recursos = new Recursos();
            Controlador = new Controlador(this);
            Navegador = new Navegador(this);

            InicializarRecursos();

        }
        #endregion


        #region Metodos
        private void InicializarRecursos()
        {
            Recursos.Crear<string>(RECURSO_CONSULTA);
            Recursos.Crear<IFabrica>(RECURSO_FABRICA);            
            Recursos.Crear<Type>(RECURSO_TYPE);
        }

        public void Agregar(string nombre, IFabrica fabrica)
        {
            Recursos[RECURSO_FABRICA][nombre] = fabrica;            
        }

        public void Agregar(Accion accion, Secuencia secuencia)
        {
            Controlador.Agregar(accion, secuencia);
        }
        
        public void Agregar(string nombre, string consulta)
        {
            Recursos[RECURSO_CONSULTA][nombre] = consulta;         
        }

        public void Agregar(string nombre, Type type)
        {
            Recursos[RECURSO_TYPE][nombre] = type;
        }

        public void Seleccionar(Nodo nodo)
        {
            CategoriaActual = nodo.Elemento as Categoria;
            NodoActual = nodo;

            if (CategoriaActual == null)
                ClaveActual = null;
        }

        public void Seleccionar(Clave clave)
        {            
            ClaveActual = clave;

            if (clave != null && clave.Padre is Categoria categoria)
                CategoriaActual = categoria;
        }

        public async void EjecutarAsync(string accion)
        {            
            await Task.Run(() => Ejecutar(accion));
        }

        public void Ejecutar(string accion)
        {
            Controlador.Ejecutar(accion);
        }

        public void Ejecutar(string accion, IResultado resultado)
        {
            Controlador.Ejecutar(accion, resultado);
        }
        
        public void Ejecutar(string accion, Parametros parametros, IResultado resultado)
        {
            Controlador.Ejecutar(accion, parametros, resultado);
        }
        
        internal void NotificarIniciar(Accion accion, Type type, Elemento elemento)
        {
            AccionEventArgs args = new AccionEventArgs();

            args.Accion = accion;
            args.Elemento = elemento;
            args.Type = type;

            if (AccionIniciar != null)
                AccionIniciar.Invoke(this, args);
        }

        internal void NotificarTerminar(Accion accion, Type type, Elemento elemento, string resultado)
        {
            AccionResultadoEventArgs args = new AccionResultadoEventArgs();

            args.Accion = accion;
            args.Elemento = elemento;
            args.Resultado = resultado;
            args.Type = type;
            
            if (AccionTerminar != null)
                AccionTerminar.Invoke(this, args);
        }
        #endregion


        #region Propiedades
        public Categoria CategoriaActual
        {
            get;
            private set;
        }

        public Clave ClaveActual
        {
            get;
            private set;
        }

        internal Controlador Controlador
        {
            get;
        }

        public Navegador Navegador
        {
            get;
        }

        public Nodo NodoActual
        {
            get;
            private set;
        }

        internal Recursos Recursos
        {
            get;
        }
        
        public Repositorio Repositorio
        {
            get;
        }

        public Type Type
        {
            get => CategoriaActual != null ? Recursos[RECURSO_TYPE][CategoriaActual.Nombre] as Type : null;
        }
        #endregion



        #region IContexto
        Repositorio IContexto.Repositorio
        {
            get => Repositorio;
        }

        IFabrica IContexto.ObtenerFabrica(string nombre)
        {
            return Recursos[RECURSO_FABRICA][nombre] as IFabrica;                
        }
        #endregion

    }
}
