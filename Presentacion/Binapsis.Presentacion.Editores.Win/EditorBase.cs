using System.ComponentModel;
using System.Windows.Forms;
using Binapsis.Presentacion.Editores;
using Binapsis.Presentacion.Editores.Win.Diseñadores;
using DevExpress.XtraEditors;
using Binapsis.Presentacion.Editores.Win.Estilos;
using System;
using System.ComponentModel.Design;

namespace Binapsis.Presentacion.Editores.Win
{
    [ToolboxItem(false), Designer(typeof(ControlDesignerEditor))]
    public partial class EditorBase : UserControl, IEditor, IEditorAtributo
    {
        Etiqueta _etiqueta;        
        BaseEdit _editor;
        EstiloEditorBase _estilo;
        Estilo _editorEstilo;
        EventHandler _handler;

        bool _redundancia;

        public EditorBase()
        {
            InitializeComponent();
            _etiqueta = new Etiqueta(etiqueta);
            _handler = new EventHandler((s, e) => OnNotify());
            Inicializar();
        }

        public event NotificarHandler Notificar;

        protected virtual int CalcularAltoMaximo(int alto)
        {
            if (_estilo != null && _estilo.MaximoAlto > 0)
                return _estilo.MaximoAlto;
            else
                return alto;
        }

        protected virtual void Inicializar()
        {
           
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            IComponentChangeService changeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));
            if (changeService == null) return; // not provided at runtime, only design mode

            changeService.ComponentChanged -= OnComponentChanged; // to avoid multiple subscriptions
            changeService.ComponentChanged += OnComponentChanged;

            changeService.ComponentRename -= OnRename;
            changeService.ComponentRename += OnRename;

        }

        private void OnComponentChanged(object sender, ComponentChangedEventArgs e) { }

        private void OnRename(object sender, ComponentRenameEventArgs e)
        {
            if (e.Component == this)
            {
                OnNameChanged(e.OldName, e.NewName);
                Name = e.NewName;                
            }
        }

        protected virtual void OnNameChanged(string oldValue, string newValue)
        {
            if ((_etiqueta.Texto != null && _etiqueta.Texto == oldValue) || string.IsNullOrEmpty(_etiqueta.Texto))
                _etiqueta.Texto = newValue;
        }

        internal virtual EstiloEditorBase CrearEstilo()
        {
            return null;
        }

        private EstiloEditorBase CrearEstilo(Estilo estilo)
        {
            return FabricaEstilo.Instancia.CrearEditor(estilo);
        }

        private void EstablecerEstilo(Estilo editorEstilo)
        {
            if (editorEstilo == _editorEstilo && _estilo != null) return;
            EstablecerEstilo(CrearEstilo(editorEstilo));
            _editorEstilo = editorEstilo;
        }

        internal void EstablecerEstilo(EstiloEditorBase estilo)
        {
            if (_estilo == estilo || estilo == null) return;
            _estilo = estilo;
            EstablecerEditor(_estilo.Editor);
        }

        protected virtual void EstablecerEditor(BaseEdit editor)
        {
            if (_editor != null && Controls.Contains(_editor))
                Controls.Remove(_editor);

            DesenlazarControlador(_handler);

            _editor = editor;
            _editor.Dock = DockStyle.Fill;

            Controls.Add(_editor);

            _editor.BringToFront();

            // enlazar controlador            
            EnlazarControlador(_handler);
        }

        protected virtual void DesenlazarControlador(EventHandler handler)
        {
            if (_editor != null)
                _editor.Validated -= _handler;
        }

        protected virtual void EnlazarControlador(EventHandler handler)
        {
            _editor.Validated += _handler;
        }

        private void Establecer(object valor)
        {
            _redundancia = true;
            try
            {
                _editor.EditValue = valor;
            }
            finally
            {
                _redundancia = false;
            }            
        }

        protected virtual object Obtener()
        {
            return _editor.EditValue;
        }

        private void OnNotify()
        {
            if (_redundancia) return;
            Notificar?.Invoke();
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            height = CalcularAltoMaximo(height);
            base.SetBoundsCore(x, y, width, height, specified);
        }

        protected BaseEdit Editor
        {
            get { return _editor; }
        }
        
        [Browsable(false)]
        public virtual Estilo Estilo
        {
            get { return _editorEstilo; }
            set { EstablecerEstilo(value); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Etiqueta Etiqueta
        {
            get { return _etiqueta; }
        }

        public string Nombre
        {
            get { return Name; }
        }

        [Browsable(false)]
        object IEditorAtributo.Valor
        {
            get { return Obtener(); }
            set { Establecer(value); }
        }
        
    }
}
