using System.Collections.Generic;

namespace Binapsis.Plataforma.Estructura
{
    public interface ITipo
    { 
		string Alias { get; }

		ITipo Base { get; }

		bool EsTipoDeDato { get; }

		string Nombre { get; }
        
        IReadOnlyList<IPropiedad> Propiedades { get; }

		IPropiedad ObtenerPropiedad(string nombre);
        
		IPropiedad ObtenerPropiedad(int indice);

        bool ContienePropiedad(string nombre);

        IPropiedad this[int indice] { get; }

        IPropiedad this[string nombre] { get; }

        string Uri { get; }
	} 
} 