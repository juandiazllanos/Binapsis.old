namespace Binapsis.Plataforma.Estructura
{
	public interface IPropiedad
    {
		string Alias { get; }

		Asociacion Asociacion { get; }

		Cardinalidad Cardinalidad { get; }

        bool EsColeccion { get; }

		int Indice { get; }

		string Nombre { get; }

		ITipo Tipo { get; }

		object ValorInicial { get; }
	} 
}