using System.Drawing;

namespace Binapsis.Consola.Graphics
{
    public abstract class Galeria
    {
        public abstract Image Obtener(string nombre, sbyte size);
        public abstract Image Obtener(string ruta, string nombre, sbyte size);
    }
}
