using System.Collections;

namespace Binapsis.Consola.Win.Vistas
{
    public partial class VistaGrid : VistaBase
    {
        Grid _grid;

        public VistaGrid()
        {
            InitializeComponent();
            Inicializar();

            gridControl.MouseClick += (s, e) => OnMouseClick(e.Button);
        }

        public override void Actualizar()
        {
            IEnumerable ds = _grid?.Consultar();
            EstablecerDataSource(ds);
        }

        public override void EstablecerContenido(Contenido contenido)
        {
            if (contenido is Grid grid)
                EstablecerGrid(_grid = grid);
        }

        private void Inicializar()
        {
            gridView.OptionsBehavior.Editable = false;
            gridView.OptionsView.ShowIndicator = true;

            gridView.IndicatorWidth = 35;
            gridView.CustomDrawRowIndicator += (s, e) =>
            {
                if (e.Info.Kind == DevExpress.Utils.Drawing.IndicatorKind.Row) e.Info.DisplayText = (e.RowHandle + 1).ToString();
            };
        }
        
        private void EstablecerGrid(Grid grid)
        {
            IEnumerable ds = _grid?.Consultar();
            EstablecerDataSource(ds);
        }

        private void EstablecerDataSource(IEnumerable ds)
        {
            gridControl.DataSource = ds;
        }

        private object[] ObtenerItems()
        {
            int[] rows = gridView.GetSelectedRows();
            if (rows.Length == 0) return null;

            object[] items = new object[rows.Length];

            for (int i = 0; i < rows.Length; i++)
            {
                items[i] = gridView.GetRow(rows[i]);
            }
                        
            return items;
        }

        public override object[] ItemSeleccionado
        {
            get => ObtenerItems();
        }
    }
}
