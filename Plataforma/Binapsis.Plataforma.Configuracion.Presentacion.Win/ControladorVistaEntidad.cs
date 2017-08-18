using Binapsis.Plataforma.Configuracion.Presentacion.Win.Vistas;
using Binapsis.Plataforma.Estructura;
using Binapsis.Presentacion.Editores;
using Binapsis.Presentacion.Win;
using System;

namespace Binapsis.Plataforma.Configuracion.Presentacion.Win
{
    class ControladorVistaEntidad : IFabrica, IVista
    {       
        
        public object Crear()
        {
            return new ControladorVistaEntidad();
        }

        public object Crear(params object[] param)
        {
            throw new NotImplementedException();
        }
        
        private void Mostrar(IObjetoDatos od)
        {
            Type typeBase = typeof(VistaBase);
            Type type = Type.GetType($"{typeBase.Namespace}.Vista{od.Tipo.Nombre}");

            // crear vista
            EditorObjeto vista = Activator.CreateInstance(type) as EditorObjeto;
            vista.Establecer(od);

            // mostrar en dialogo
            IDialogo dialogo = new Dialogo() { Editor = vista };
            dialogo.Mostrar(new TerminarHandler(Terminar));
        }

        private void Terminar(IDialogo dialogo)
        {
            IVista vista = this;

            if (dialogo.Resultado == ResultadoDialogo.OK)
                vista.Resultado.OK();
            else if (dialogo.Resultado == ResultadoDialogo.Cancelado)
                vista.Resultado.Cancelar();
        }

        #region IVista
        IResultado IVista.Resultado
        {
            get;
            set;
        }

        void IVista.Mostrar(object obj)
        {
            if (obj is IObjetoDatos od)
                Mostrar(od);
        }
        #endregion

    }
}
