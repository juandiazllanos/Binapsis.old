using Binapsis.Plataforma.Estructura;
using Binapsis.Presentacion.Editores;
using Binapsis.Presentacion.MVVM;
using Binapsis.Presentacion.MVVM.Mapeo;
using Binapsis.Presentacion.Win.Diseñadores;
using System.ComponentModel;
using System.Windows.Forms;

namespace Binapsis.Presentacion.Win
{
    [ToolboxItem(false)]
    [Designer(typeof(ParentControlDesignerEditor))]
    public partial class EditorObjeto : UserControl
    {
        MapeoTipo _mapeo;
        Vista _vista;
        VistaModelo _vistaModelo;

        public EditorObjeto()
        {
            InitializeComponent();            
            Inicializar();
        }
        
        private void Inicializar()
        {
            UsarReflexion = true;
        }

        protected virtual void InicializarVista()
        {
            Establecer(Controls);
        }
        
        protected virtual void InicializarComando()
        {

        }

        private void Establecer(ControlCollection controles)
        {
            foreach (Control control in controles)
                Establecer(control);
        }

        private void Establecer(Control control)
        {
            IEditorAtributo editor = (control as IEditorAtributo);

            if (editor != null)
                Establecer(editor.Nombre, editor);
            else
                Establecer(control.Controls);
        }

        protected void Establecer(string nombre, IEditor editor)
        {
            _mapeo.Establecer(nombre, editor);
        }

        protected void Establecer(string nombre, IEditor editor, MapeoTipo mapeo)
        {
            _mapeo.Establecer(nombre, editor, mapeo);
        }

        protected void EstablecerComando(IEditorComando invocador, IComando comando)
        {
            _mapeo.EstablecerComando(invocador, comando);
        }

        public void Establecer(IObjetoDatos modelo)
        {
            if (_vistaModelo != null) return;

            _mapeo = new MapeoTipo(UsarReflexion);

            InicializarVista();
            InicializarComando();
            
            _vista = new Vista(_mapeo);
            _vistaModelo = new VistaModelo(_vista);
            _vistaModelo.Establecer(modelo);
        }

        [DefaultValue(true)]
        public virtual bool UsarReflexion
        {
            get;
            set;
        } 
    }
}
