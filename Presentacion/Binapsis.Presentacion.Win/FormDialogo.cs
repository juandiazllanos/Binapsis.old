using DevExpress.XtraEditors;
using DevExpress.Skins;
using System;
using System.Windows.Forms;
using Binapsis.Presentacion.Editores;

namespace Binapsis.Presentacion.Win
{
    internal partial class FormDialogo : XtraForm
    {
        EditorObjeto _editor;
        Action<FormDialogo> _terminar;

        public FormDialogo()
        {
            InitializeComponent();
            Inicializar();
        }

        protected virtual void Inicializar()
        {
            SkinManager.EnableFormSkins();

            Resultado = ResultadoDialogo.Cancelado;
            botonOk.Tag = ResultadoDialogo.OK;
            botonCancelar.Tag = ResultadoDialogo.Cancelado;

            botonOk.Click += Cerrar;
            botonCancelar.Click += Cerrar;                        
        }
        
        public void Mostrar()
        {
            ShowDialog();
        }

        public void Mostrar(Action<FormDialogo> terminar)
        {
            _terminar = terminar;            
            Show();
        }

        private void Cerrar(object sender, EventArgs arg)
        {
            SimpleButton boton = (sender as SimpleButton);
            ResultadoDialogo resul = Resultado;

            if (boton != null)            
                resul = (ResultadoDialogo)boton.Tag;
            
            if (resul == ResultadoDialogo.Cancelado && ConfirmarDialogo && 
                MessageBox.Show(this, "Confirmar para salir", "Confirmación", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            Resultado = resul;
            Close();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            _terminar?.Invoke(this);
        }

        private void EstablecerEditor(EditorObjeto editor)
        {
            int width = editor.Width;
            int height = editor.Height + botones.Height;

            ClientSize = new System.Drawing.Size(width, height);

            if (_editor != null && Controls.Contains(editor))
                Controls.Remove(editor);

            Controls.Add(editor);
            editor.BringToFront();
            editor.TabStop = true;
            editor.TabIndex = 0;

            _editor = editor;
        }

        public EditorObjeto Editor
        {
            get => _editor;
            set => EstablecerEditor(value);
        }

        public bool ConfirmarDialogo
        {
            get;
            set;
        }

        public ResultadoDialogo Resultado
        {
            get;
            private set;
        }
    }
}