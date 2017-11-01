namespace Binapsis.Consola.Navegacion
{
    public class Ruta
    {
        Elemento _elemento;

        public Ruta(Elemento elemento)
        {
            _elemento = elemento;
        }

        public override string ToString()
        {
            Elemento padre = _elemento;
            string ruta = null;

            while (padre != null)
            {
                if (!string.IsNullOrEmpty(ruta))
                    ruta = padre.Nombre + "\\" + ruta;
                else
                    ruta = padre.Nombre;

                padre = padre.Padre;
            }                

            return ruta;
        }
    }
}
