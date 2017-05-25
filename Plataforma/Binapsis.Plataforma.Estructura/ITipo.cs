using System.Collections.Generic;

namespace Binapsis.Plataforma.Estructura
{
    public interface ITipo
    {
        IPropiedad ObtenerPropiedad(string nombre);
        IPropiedad ObtenerPropiedad(int indice);
        bool ContienePropiedad(string nombre);

        string Alias { get; }
		ITipo Base { get; }
		bool EsTipoDeDato { get; }
		string Nombre { get; }
        IReadOnlyList<IPropiedad> Propiedades { get; }
        IPropiedad this[int indice] { get; }
        IPropiedad this[string nombre] { get; }
        string Uri { get; }
    } 
} 