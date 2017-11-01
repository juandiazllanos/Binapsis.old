using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Drawing.Design;
using Binapsis.Presentacion.Editores.Win.Diseñadores;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using Binapsis.Presentacion.Editores;
using System.Collections.Generic;

namespace Binapsis.Presentacion.Editores.Win
{
    [ToolboxItem(true), Designer(typeof(ControlDesignerEditor))]
    public partial class EditorColeccion : UserControl, IEditorColeccion
    {
        DataTable _tabla;
        Columnas _columnas;
        List<Fila> _filas;

        public EditorColeccion()
        {
            InitializeComponent();
            Inicializar();
        }

        private void Inicializar()
        {
            _tabla = new DataTable();
            editor.DataSource = _tabla;

            _columnas = new Columnas();
            _columnas.DataColumnCollection = _tabla.Columns;
            _columnas.Notificar = CrearColumnas;

            _filas = new List<Fila>();
        }

        private void CrearColumnas()
        {
            ColumnView vista = editor.MainView as ColumnView;
            if (vista == null) return;
            vista.Columns.Clear();

            foreach (Columna columna in _columnas)
                CrearColumna(columna);
        }

        private void CrearColumna(Columna columna)
        {
            GridColumn editor = vista.Columns.AddField(columna.Nombre);
            editor.Visible = true;        
            editor.ColumnEdit = columna.Repositorio;            
        }

        private Fila CrearFila()
        {
            DataRow dataRow = _tabla.Rows.Add();
            Fila fila = new Fila(dataRow);
            _filas.Add(fila);
            return fila;
        }

        private void RemoverFila(Fila fila)
        {
            DataRow dataRow = fila.DataRow;
            _tabla.Rows.Remove(dataRow);
            _filas.Remove(fila);
        }

        #region IEditorColeccion
        IEditorFila IEditorColeccion.Crear()
        {
            return CrearFila();
        }

        void IEditorColeccion.Remover(IEditorFila fila)
        {
            if (fila.GetType() == typeof(Fila) || fila.GetType().IsSubclassOf(typeof(Fila)))
                RemoverFila((Fila)fila);
        }

        void IEditorColeccion.RemoverTodo()
        {
            _tabla.Rows.Clear();
            _filas.Clear();
        }
        #endregion

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor(typeof(CollectionEditorColumnas), typeof(UITypeEditor))]
        public Columnas Columnas
        {
            get { return _columnas; }
        }

        public string Nombre
        {
            get { return Name;}
        }
    }
}
