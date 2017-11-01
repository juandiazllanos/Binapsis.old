using Binapsis.Plataforma.Configuracion.Presentacion.Win.Vistas;
using Binapsis.Presentacion.Editores;
using Binapsis.Presentacion.Editores.Win;
using System;

namespace Binapsis.Plataforma.Configuracion.Presentacion.Win
{
    class ControladorVistaSeleccionar : IFabrica, IVista
    {
        public object Crear()
        {
            return new ControladorVistaSeleccionar();
        }

        public object Crear(params object[] param)
        {
            throw new NotImplementedException();
        }
        
        public void Resolver(object item)
        {
            if (item != null)
                ((IVista)this).Resultado?.OK(item);
            else
                ((IVista)this).Resultado?.Cancelar();
        }

        #region IVista
        void IVista.Mostrar(object obj)
        {
            VistaSeleccionar editor = new VistaSeleccionar();
            Dialogo dialogo = new Dialogo() { Editor = editor };
            // asignar modelo
            editor.Establecer(obj);
            // asignar controlador seleccionar item
            editor.SeleccionarItem += () => dialogo.Cerrar(ResultadoDialogo.OK);
            // mostrar dialogo
            dialogo.Mostrar();

            Resolver(editor.Item);
        }

        IResultado IVista.Resultado
        {
            get;
            set;
        }
        #endregion

    }
}
