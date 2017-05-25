using System.ComponentModel;
using System.Drawing;

namespace Binapsis.Presentacion.Win
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
     
        [DefaultValue("")]
        public string Texto
        {
            get => Editor.Text;
            set => Editor.Text = value;
        }
    }
}
