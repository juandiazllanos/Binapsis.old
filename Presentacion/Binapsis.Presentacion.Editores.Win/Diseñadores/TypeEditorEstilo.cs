using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Binapsis.Presentacion.Editores.Win.Diseñadores
{
    internal class TypeEditorEstilo : UITypeEditor
    {
        Estilo[] _estilos;

        public TypeEditorEstilo(Estilo[] estilos)
        {
            _estilos = estilos;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            var edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

            ListBox lb = new ListBox();
                        
            lb.BorderStyle = BorderStyle.FixedSingle;
            lb.Click += (s, a) => edSvc.CloseDropDown();

            foreach (var item in _estilos)
                lb.Items.Add(item);

            if (value != null)            
                lb.SelectedItem = value;
            
            edSvc.DropDownControl(lb);
            
            value = lb.SelectedItem;
            
            return value;
        }
    }
}
