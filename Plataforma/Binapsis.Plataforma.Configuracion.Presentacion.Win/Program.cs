using Binapsis.Plataforma.AgenteConfiguracion;
using DevExpress.Skins;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace Binapsis.Plataforma.Configuracion.Presentacion.Win
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {             
            SkinManager.EnableFormSkins();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Entorno.Main);
        }
    }
}
