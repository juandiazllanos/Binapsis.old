using Binapsis.Presentacion.Editores;
using System.Data;

namespace Binapsis.Presentacion.Win
{
    public class Fila : IEditorFila
    {
        Celda[] _celdas;
        DataRow _dataRow;

        public Fila(DataRow dataRow)             
        {
            _dataRow = dataRow;
            _celdas = new Celda[_dataRow.Table.Columns.Count];
        }

        public IEditorAtributo Crear(IEditorColumna col)
        {
            if (col.GetType().IsSubclassOf(typeof(Columna)) || col.GetType() == typeof(Columna))
                return Crear((Columna)col);
            else
                return null;
        }

        private Celda Crear(Columna columna)
        {
            return _celdas[columna.Indice] = new Celda(this, columna);
        }

        internal DataRow DataRow
        {
            get { return _dataRow; }
        }
    }
}
