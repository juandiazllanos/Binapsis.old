using Binapsis.Plataforma.Estructura;
using System;
using System.Linq;

namespace Binapsis.Plataforma.Configuracion
{
    public class Comando : ConfiguracionBase
    {
        public Comando(IImplementacion impl) 
            : base(impl)
        {
        }

        #region Metodos
        public virtual Parametro CrearParametro()
        {
            return CrearObjetoDatos("Parametros") as Parametro;
        }

        public virtual Parametro CrearParametro(string nombre)
        {
            Parametro parametro = CrearParametro();
            parametro.Nombre = nombre;
            return parametro;
        }

        public virtual Parametro CrearParametro(string nombre, Type type)
        {
            Parametro parametro = CrearParametro(nombre);
            parametro.TipoDato = type.FullName;
            return parametro;
        }

        public virtual Parametro CrearParametro(string nombre, Type type, string direccion)
        {
            Parametro parametro = CrearParametro(nombre, type);
            parametro.Direccion = direccion;
            return parametro;
        }

        public virtual Parametro CrearParametro(string nombre, Type type, int longitud)
        {
            Parametro parametro = CrearParametro(nombre, type);
            parametro.Longitud = longitud;            
            return parametro;
        }

        public virtual Parametro CrearParametro(string nombre, Type type, int longitud, string direccion)
        {
            Parametro parametro = CrearParametro(nombre, type, longitud);            
            parametro.Direccion = direccion;
            return parametro;
        }

        public virtual Parametro ObtenerParametro(string nombre)
        {
            return Parametros.Cast<Parametro>().FirstOrDefault(item => item.Nombre == nombre);
        }

        public virtual ResultadoDescriptor CrearResultadoDescriptor()
        {
            return CrearObjetoDatos("ResultadoDescriptores") as ResultadoDescriptor;
        }

        public virtual ResultadoDescriptor CrearResultadoDescriptor(string nombre)
        {
            ResultadoDescriptor resultadoDescriptor = CrearResultadoDescriptor();
            resultadoDescriptor.Nombre = nombre;
            return resultadoDescriptor;
        }

        public virtual ResultadoDescriptor CrearResultadoDescriptor(string nombre, Type type)
        {
            ResultadoDescriptor resultadoDescriptor = CrearResultadoDescriptor(nombre);
            resultadoDescriptor.TipoDato = type.FullName;
            return resultadoDescriptor;
        }
        #endregion


        #region Propiedades
        public ComandoTipo ComandoTipo
        {
            get => (ComandoTipo)ObtenerByte("ComandoTipo");
            set => EstablecerByte("ComandoTipo", (byte)value);
        }

        public string Nombre
        {
            get => ObtenerString("Nombre");
            set => EstablecerString("Nombre", value);
        }

        public IColeccion Parametros
        {
            get => ObtenerColeccion("Parametros");
        }

        public IColeccion ResultadoDescriptores
        {
            get => ObtenerColeccion("ResultadoDescriptores");
        }

        public string Sql
        {
            get => ObtenerString("Sql");
            set => EstablecerString("Sql", value);
        }
        #endregion  
    }
}
