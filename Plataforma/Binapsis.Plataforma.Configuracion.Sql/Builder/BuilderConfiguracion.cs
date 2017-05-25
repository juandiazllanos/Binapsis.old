using Binapsis.Plataforma.Configuracion.Sql.Comandos;
using Binapsis.Plataforma.Configuracion.Sql.Helper;
using Binapsis.Plataforma.Estructura.Impl;

namespace Binapsis.Plataforma.Configuracion.Sql.Builder
{
    internal abstract class BuilderConfiguracion<T>  where T : ObjetoBase
    {
        FabricaConfiguracion _fabrica;
        HelperRecuperacion _helper;

        public BuilderConfiguracion(HelperRecuperacion helper)
        {
            _fabrica = FabricaConfiguracion.Instancia;
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

        public abstract void Construir(T objeto, ResultadoLectura lectura);

        protected HelperRecuperacion Helper
        {
            get { return _helper; }
        }
    }
}
