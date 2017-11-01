using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Binapsis.Presentacion.Editores.Win
{
    [ToolboxItem(true)]
    public partial class EditorBoolean : EditorBase
    {
        public EditorBoolean()
        {
            InitializeComponent();
        }

        protected override void Inicializar()
        {
            Estilo = Estilo.CheckEdit;
            Texto = "";
        }

        protected override void DesenlazarControlador(EventHandler handler)
        {
            if (Editor is CheckEdit checkEdit)
                checkEdit.CheckedChanged -= handler;
            else
                base.DesenlazarControlador(handler);
        }

        protected override void EnlazarControlador(EventHandler handler)
        {
            if (Editor is CheckEdit checkEdit)
                checkEdit.CheckedChanged += handler;
            else
                base.EnlazarControlador(handler);
        }

        [DefaultValue("")]
        public string Texto
        {
            get => Editor.Text;
            set => Editor.Text = value;
        }
    }
}
