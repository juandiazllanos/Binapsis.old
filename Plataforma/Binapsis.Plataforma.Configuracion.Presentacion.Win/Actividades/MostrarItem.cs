using Binapsis.Plataforma.Configuracion.Presentacion.Actividades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binapsis.Plataforma.Configuracion.Presentacion.Win.Actividades
{
    class MostrarItem : Mostrar
    {
        public MostrarItem(string vista) 
            : base(vista)
        {
        }

        public override void Iniciar()
        {
            ConfiguracionBase item = Parametros["item"] as ConfiguracionBase;
            IVista vista = Contexto.ObtenerFabrica(Vista)?.Crear() as IVista;

            if (vista != null && item != null)
            {
                vista.Resultado = this;
                vista.Mostrar(item);
            }
            else
                Cancelar();
        }
    }
}
