using Binapsis.Plataforma.Estructura;
using System;

namespace Binapsis.Plataforma.ServicioConfiguracion
{
    public class ConsultaParametro
    {
        public ConsultaParametro(IPropiedad propiedad, string valor)
        {
            Propiedad = propiedad;
            Valor = valor;
        }
        
        public IPropiedad Propiedad
        {
            get;
        }

        public object Valor
        {
            get;
        }
    }
}
