using System;

namespace Binapsis.Plataforma.Configuracion.Presentacion.Navegacion
{
    public class NodoInfo
    {
        #region Constructores
        public NodoInfo(Consola consola, Nodo nodo)
        {
            Consola = consola;
            Nodo = nodo;
        }
        #endregion


        #region Metodos
        private Type ObtenerType()
        {   
            Categoria categoria = Nodo.Elemento as Categoria;
            return categoria != null ? Consola.Recursos[Consola.RECURSO_TYPE][categoria.Nombre] as Type : null;
        }
        #endregion


        #region Propiedades
        private Consola Consola
        {
            get;
        }

        public Elemento Elemento
        {
            get => Nodo?.Elemento;
        }

        public Nodo Nodo
        {
            get;
        }

        public Type Type
        {
            get => ObtenerType();
        }
        #endregion

    }
}
