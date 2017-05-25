using Binapsis.Plataforma.Estructura.Impl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Binapsis.Plataforma.Configuracion.Win.Vistas
{
    public partial class VistaBase : Form, IVista
    {
        public VistaBase()
        {
            InitializeComponent();
        }
        
        public IActividad Actividad { get; set; }
        public bool EstiloDialogo { get; set; }
        public virtual ObjetoBase Estado { get; set; }
        public bool ConfirmarCancelar { get; set; }
        public Resultado Resultado { get; private set; }
        
        private void InicializarBase()
        {
            btnAceptar.Click += (s, e) => ResolverOk();
            btnCancelar.Click += (s, e) => ResolverCancel();

            Inicializar();
        }

        public void MostrarBase()
        {
            if (EstiloDialogo)
                ShowDialog();
            else
                Show();
        }       
        
        protected virtual void Inicializar()
        {

        }
        
        private void ResolverOk()
        {
            Resultado = Resultado.OK;
            Close();

            Actividad?.Terminar();
        }

        private void ResolverCancel()
        {
            if (ConfirmarCancelar &&
                MessageBox.Show(this, "Confirmar para salir.", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            Resultado = Resultado.Cancel;
            Close();

            Actividad?.Cancelar();
        }
                

        #region IVista
        Resultado IVista.Resultado
        {
            get { return Resultado; }
        }

        void IVista.Mostrar()
        {
            InicializarBase();
            MostrarBase();
        }
        #endregion  
    }
}
