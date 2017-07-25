using Binapsis.Plataforma.Configuracion;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Binapsis.Plataforma.Datos.Impl
{
    public class Parametros : IEnumerable<ParametroComando>
    {
        List<ParametroComando> _parametros = new List<ParametroComando>();

        #region Constructores
        public Parametros(Comando comando)
        {   
            ConstruirParametros(comando);
        }
        #endregion


        #region Metodos
        protected virtual void ConstruirParametros(Comando comando)
        {
            foreach (Parametro parametro in comando.Parametros)
                AgregarParametro(CrearParametro(parametro));
        }
                
        protected virtual ParametroComando CrearParametro(Parametro parametro)
        {
            return new ParametroComando(parametro);
        }

        protected virtual void AgregarParametro(ParametroComando parametroComando)
        {
            _parametros.Add(parametroComando);
        }

        public bool Existe(string nombre)
        {
            return _parametros.Exists(item => item.Nombre == nombre);
        }
        
        public int Contar()
        {
            return _parametros.Count;
        }

        public ParametroComando Obtener(string nombre)
        {
            return _parametros.FirstOrDefault(item => item.Nombre == nombre);
        }

        public ParametroComando Obtener(int indice)
        {
            if (indice >= 0 && indice < _parametros.Count)
                return _parametros[indice];
            else
                return null;
        }
        #endregion


        #region Indizadores
        public ParametroComando this[string nombre]
        {
            get => Obtener(nombre);
        }

        public ParametroComando this[int indice]
        {
            get => Obtener(indice);
        }
        #endregion


        #region IEnumerable
        public IEnumerator<ParametroComando> GetEnumerator()
        {
            return ((IEnumerable<ParametroComando>)_parametros).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<ParametroComando>)_parametros).GetEnumerator();
        }
        #endregion
    }
}
