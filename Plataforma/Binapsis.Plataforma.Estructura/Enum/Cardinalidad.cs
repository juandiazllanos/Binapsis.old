namespace Binapsis.Plataforma.Estructura
{
	public enum Cardinalidad : byte
    {
        Ninguna = 0,
        Cero = 1,        
        CeroAUno = 2,
        CeroAMuchos = 5,
        Uno = 3,
        UnoAMuchos = 6,
        Muchos = 4,
	}
}