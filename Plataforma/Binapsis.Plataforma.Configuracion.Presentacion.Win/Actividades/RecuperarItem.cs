using Binapsis.Plataforma.Configuracion.Presentacion.Navegacion;
using Binapsis.Plataforma.Estructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binapsis.Plataforma.Configuracion.Presentacion.Win.Actividades
{
    class RecuperarItem : Actividad
    {
        public override void Iniciar()
        {
            ConfiguracionBase instancia = Parametros["instancia"] as ConfiguracionBase;            
            string propiedad = Parametros["propiedad"] as string;
            Clave claveItem = Parametros["claveItem"] as Clave;

            ConfiguracionBase item = null;

            if (instancia != null && propiedad != null && claveItem != null)
                item = ObtenerItem(instancia, propiedad, claveItem.Valor) as ConfiguracionBase;

            if (item != null)
            {
                Parametros["item"] = item;
                Terminar();
            }
            else
                Cancelar();
        }

        private IObjetoDatos ObtenerItem(IObjetoDatos instancia, string propiedad, string clave)
        {
            if (!instancia.Tipo.ContienePropiedad(propiedad) || 
                !instancia.Tipo[propiedad].Tipo.ContienePropiedad("Nombre")) return null;

            IObjetoDatos item = null;
            IColeccion coleccion = instancia.ObtenerColeccion(propiedad);
            
            if (clave != null && clave.Contains('.'))
                clave = clave.Substring(clave.LastIndexOf('.') + 1);

            item = coleccion.FirstOrDefault(od => od.ObtenerString("Nombre").Equals(clave));

            return item;
        }
    }
}
