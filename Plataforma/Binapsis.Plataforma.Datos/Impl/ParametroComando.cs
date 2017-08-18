using Binapsis.Plataforma.Configuracion;
using System;
//using ParametroDescriptor = Binapsis.Plataforma.Configuracion.Parametro;

namespace Binapsis.Plataforma.Datos.Impl
{
    public class ParametroComando
    {
        Parametro _parametro;

        public ParametroComando(Parametro parametro)
        {
            _parametro = parametro;
        }

        public string Direccion
        {
            get => _parametro.Direccion;            
        }
                
        public string Nombre
        {
            get => _parametro.Nombre;            
        }

        public int Longitud
        {
            get => _parametro.Longitud;
        }

        public int Indice
        {
            get => _parametro.Indice;            
        }

        public Type Type
        {
            get;
            set;
        }

        public object Valor
        {
            get;
            set;
        }
    }
}
