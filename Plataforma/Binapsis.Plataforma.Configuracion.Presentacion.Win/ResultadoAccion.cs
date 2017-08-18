using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Binapsis.Plataforma.Configuracion.Presentacion.Win
{
    class ResultadoAccion : IResultado
    {
        
        public ResultadoAccion(Main main, TreeNode treeNode)
        {
            Main = main;
            TreeNode = treeNode;
        }

        public void Cancelar()
        {
            
        }

        public void OK()
        {
            Main.Actualizar(TreeNode);
        }

        public void OK(object resultado)
        {
            throw new NotImplementedException();
        }

        Main Main
        {
            get;
        }

        TreeNode TreeNode
        {
            get;
        }

    }
}
