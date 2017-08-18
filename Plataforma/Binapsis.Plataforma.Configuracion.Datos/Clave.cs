using Binapsis.Plataforma.Datos;
using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Configuracion.Datos
{
    internal class Clave : IClave
    {
        ITipo _tipo;
        
        public Clave(ITipo tipo)
        {
            _tipo = tipo;
        }

        public object Obtener(IObjetoDatos od, string columna)
        {
            if (columna?.Substring(0, 2) != "PK") return null;

            // todas las claves deben de ser tipo string
            if (od == null) return string.Empty;

            switch (_tipo.Nombre)
            {
                case "Ensamblado":
                case "Uri":
                case "Conexion":
                case "Tabla":
                case "Relacion":
                    return od.ObtenerString("Nombre");

                case "Tipo":
                    return $"{od.ObtenerString("Uri/Nombre")}.{od.ObtenerString("Nombre")}";

                case "Propiedad":
                case "Columna":
                    return $"{new Clave(od.Propietario.Tipo)}.{od.ObtenerString("Nombre")}";

                default:
                    return null;

            }
        }

        //public override string ToString()
        //{
        //    return Obtener(null)?.ToString();
        //}
    }
}