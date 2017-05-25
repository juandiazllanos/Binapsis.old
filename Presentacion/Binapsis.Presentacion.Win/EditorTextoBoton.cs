using System.ComponentModel;

namespace Binapsis.Presentacion.Win
{
    [ToolboxItem(true)]
    public partial class EditorTextoBoton : EditorBoton
    {
        public EditorTextoBoton()
        {
            InitializeComponent();
        }

        protected override void Inicializar()
        {
            Estilo = Estilo.TextButtonEdit;

            if (Botones.Count == 0 && Botones.ButtonCollection.Count != 0)
                Botones.ButtonCollection.Clear();

            //Botones.Add(new Boton() { Nombre = "Boton" });
        }        
    }
}
