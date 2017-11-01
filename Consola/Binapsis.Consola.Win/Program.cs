using Binapsis.Consola.Definicion;
using Binapsis.Consola.Graphics;
using Binapsis.Consola.Win.Builder;
using DevExpress.Skins;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assembly = System.Reflection.Assembly;
using AssemblyName = System.Reflection.AssemblyName;

namespace Binapsis.Consola.Win
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string url = "http://localhost:24340/configuracion";

            ConsolaInfo consolaInfo = new ConsolaInfo();
            BuilderConsolaInfo builderConsolaInfo = new BuilderConsolaInfo(consolaInfo);
            builderConsolaInfo.Construir();

            Main main = new Main(consolaInfo, url);            
            Navegador navegador = new Navegador();
            BuilderNavegador builderNavegador = new BuilderNavegador(navegador);
            builderNavegador.Construir();

            main.Galeria = new Fichero("D:\\Desarrollo\\Binapsis\\Consola\\Binapsis.Consola.Galeria");
            main.EstablecerContexto("default");

            AssemblyLoader assemblyLoader = new AssemblyLoader(AppDomain.CurrentDomain, consolaInfo);

            SkinManager.EnableFormSkins();
            SkinManager.EnableMdiFormSkins();
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new WinMain(main, navegador));
        }
    }
}
