using Binapsis.Plataforma.Configuracion.Sql.Comandos;
using Binapsis.Plataforma.Configuracion.Sql.Helper;
using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Configuracion.Sql.Builder
{
    internal class BuilderConfiguracion<T>  where T : ConfiguracionBase
    {
        Fabrica _fabrica;
        HelperRecuperacion _helper;

        public BuilderConfiguracion(HelperRecuperacion helper)
        {
            _fabrica = Fabrica.Instancia;
            _helper = helper;
        }
        
        public virtual T Construir(ResultadoLectura lectura) 
        {
            T objeto = (T)_fabrica.Crear(typeof(T));
            Construir(objeto, lectura);
            return objeto;
        }

        public T[] Construir(ResultadoLectura[] lectura)
        {
            T[] objetos = new T[lectura.Length];

            for (int item = 0; item < lectura.Length; item++)
                objetos[item] = Construir(lectura[item]);
                
            return objetos;
        }

        public virtual void Construir(T objeto, ResultadoLectura lectura)
        {
            IObjetoDatos od = objeto;

            foreach(IPropiedad propiedad in od.Tipo.Propiedades)
            {
                if (!propiedad.Tipo.EsTipoDeDato) continue;
                od.Establecer(propiedad, lectura[propiedad.Nombre]);
            }
        }

        protected HelperRecuperacion Helper
        {
            get { return _helper; }
        }
    }
}
