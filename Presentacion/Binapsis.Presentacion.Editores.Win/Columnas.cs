using System;
using System.Collections.ObjectModel;
using System.Data;

namespace Binapsis.Presentacion.Editores.Win
{
    public class Columnas : Collection<Columna>
    {
        DataColumnCollection _dataColumCollection;
        
        void CrearDataColumn(Columna columna)
        {
            if (string.IsNullOrEmpty(columna.Nombre))
                columna.Nombre = string.Format("columna{0}", Count + 1);

            _dataColumCollection.Add(columna.DataColumn);            
        }

        void EliminarDataColumn(Columna columna)
        {
            DataColumn dataColumn = columna.DataColumn;
            if (dataColumn != null && _dataColumCollection.Contains(dataColumn.ColumnName))
                _dataColumCollection.Remove(dataColumn);            
        }

        protected override void InsertItem(int index, Columna item)
        {
            CrearDataColumn(item);
            base.InsertItem(index, item);
            Notificar?.Invoke();
        }

        protected override void RemoveItem(int index)
        {
            EliminarDataColumn(Items[index]);
            base.RemoveItem(index);
            Notificar?.Invoke();
        }

        protected override void SetItem(int index, Columna item)
        {
            base.SetItem(index, item);
        }

        protected override void ClearItems()
        {
            for (int i = Count - 1; i >= 0; i--)
                RemoveItem(i);            
        }

        internal DataColumnCollection DataColumnCollection
        {
            get { return _dataColumCollection; }
            set { _dataColumCollection = value; }
        }

        internal Action Notificar
        {
            get;
            set;
        }
    }
}
