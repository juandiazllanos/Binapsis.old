using Binapsis.Presentacion.Editores;
using DevExpress.XtraEditors.Controls;
using System.Drawing;

namespace Binapsis.Presentacion.Win
{
    public class Boton : IEditorComando
    {
        EditorButton _editorButton;
        
        public Boton()
        {
            _editorButton = new EditorButton();
            _editorButton.Click += (s, a) => Notificar?.Invoke();
        }
        
        internal EditorButton EditorButton
        {
            get { return _editorButton; }            
        }

        public string Nombre { get; set; }

        public Image Image
        {
            get { return _editorButton.Image; }
            set { _editorButton.Image = value; }
        }

        public event NotificarHandler Notificar;

        public void Deshabilitar()
        {            
        }

        public void Habilitar()
        {            
        }
    }
}
