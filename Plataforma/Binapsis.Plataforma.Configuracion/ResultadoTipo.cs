using Binapsis.Plataforma.Estructura;
using System.Collections.Generic;

namespace Binapsis.Plataforma.Configuracion
{
    public class ResultadoTipo : ITipo
    {
        Comando _comando;
        List<IPropiedad> _propiedades;

        public ResultadoTipo(Comando comando)
        {
            _comando = comando;
            _propiedades = new List<IPropiedad>();

            ConstruirPropiedades();
        }

        private void ConstruirPropiedades()
        {
            int i = 0;
            foreach (ResultadoDescriptor resultadoDescriptor in _comando.ResultadoDescriptores)
                _propiedades.Add(new ResultadoPropiedad(resultadoDescriptor) { Indice = i++ });         
        }
        

        public IPropiedad this[int indice]
        {
            get => _propiedades[indice];
        }

        public IPropiedad this[string nombre]
        {
            get => ObtenerPropiedad(nombre);
        }

        public string Alias
        {
            get => string.Empty;
        }

        public ITipo Base
        {
            get => null;
        }

        public bool EsTipoDeDato
        {
            get => false;
        }

        public string Nombre
        {
            get => _comando.Nombre;
        }

        public IReadOnlyList<IPropiedad> Propiedades
        {
            get => _propiedades;
        }

        public string Uri
        {
            get => "Binapsis.Plataforma.Configuracion";
        }

        public bool ContienePropiedad(string nombre)
        {
            return _propiedades.Exists(item => item.Nombre == nombre);
        }

        public IPropiedad ObtenerPropiedad(string nombre)
        {
            return _propiedades.Find(item => item.Nombre == nombre);
        }

        public IPropiedad ObtenerPropiedad(int indice)
        {
            return _propiedades[indice];
        }
    }
}
