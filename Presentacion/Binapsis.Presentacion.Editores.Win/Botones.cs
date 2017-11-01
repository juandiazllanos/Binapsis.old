using DevExpress.XtraEditors.Controls;
using System.Collections.ObjectModel;

namespace Binapsis.Presentacion.Editores.Win
{
    public class Botones : Collection<Boton>
    {        
        EditorButtonCollection _buttons;
               
        internal EditorButtonCollection ButtonCollection
        {
            get { return _buttons; }
            set { _buttons = value; }
        }

        //private void EstablecerButtonCollecion(EditorButtonCollection buttons)
        //{
        //    _buttons = buttons;
        //    Items.Clear();
        //}
        
        private void CrearEditorButton(Boton item)
        {            
            _buttons.Add(item.EditorButton);           
        }

        private void EliminarEditorButton(Boton item)
        {
            _buttons.RemoveAt(_buttons.IndexOf(item.EditorButton));            
        }

        protected override void ClearItems()
        {
            for (int i = Count - 1; i >= 0; i--)
                RemoveItem(i);
        }

        protected override void InsertItem(int index, Boton item)
        {
            base.InsertItem(index, item);
            CrearEditorButton(item);            
        }

        protected override void RemoveItem(int index)
        {
            Boton item = Items[index];
            EliminarEditorButton(item);
            base.RemoveItem(index);            
        }

        protected override void SetItem(int index, Boton item)
        {
            base.SetItem(index, item);
        }

    }
}
