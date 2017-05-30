using Binapsis.Plataforma.Configuracion.Sql.Comandos;
using Binapsis.Plataforma.Configuracion.Sql.Helper;

namespace Binapsis.Plataforma.Configuracion.Sql.Builder
{
    class BuilderColumna : BuilderConfiguracion<Columna>
    {        
        public BuilderColumna(HelperRecuperacion helper, Tabla tabla) 
            : base(helper)
        {
            Tabla = tabla;
        }

        public override Columna Construir(ResultadoLectura lectura)
        {
            Columna columna = Tabla.CrearColumna();
            Construir(columna, lectura);
            return columna;
        }

        public Tabla Tabla
        {
            get;
        }
    }
}
