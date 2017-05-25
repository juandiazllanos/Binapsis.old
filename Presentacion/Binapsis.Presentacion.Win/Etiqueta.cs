using Binapsis.Presentacion.Win.Convertidores;
using DevExpress.XtraEditors;
using System.ComponentModel;
using System.Drawing;

namespace Binapsis.Presentacion.Win
{
    [TypeConverter(typeof(ConvertidorEtiqueta))]
    public class Etiqueta
    {
        LabelControl _label;
                
        public Etiqueta(LabelControl label)
        {
            _label = label;
        }


        private void EstablecerAncho(int value)
        {
            _label.Size = new Size(value, _label.Size.Height);
        }

        private void EstablecerTexto(string value)
        {
            _label.Text = value;
        }

        private void EstablecerVisible(bool value)
        {
            _label.Visible = value;
        }

        [DefaultValue(80)]
        public int Ancho
        {
            get { return _label.Size.Width; }
            set { EstablecerAncho(value); }
        }

        [DefaultValue(null)]
        public string Texto
        {
            get { return _label.Text; }
            set { EstablecerTexto(value); }
        }

        [DefaultValue(true)]
        public bool Visible
        {
            get { return _label.Visible; }
            set { EstablecerVisible(value); }
        }

    }
}
