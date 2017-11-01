using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Binapsis.Consola.Graphics
{
    public class Fichero : Galeria
    {   
        Dictionary<string, FicheroImagen> _items = new Dictionary<string, FicheroImagen>();
        string _carpeta;

        public Fichero(string carpeta)
        {
            _carpeta = carpeta;            
        }

        public override Image Obtener(string nombre, sbyte size)
        {
            return Obtener(null, nombre, size);
        }

        public override Image Obtener(string ruta, string nombre, sbyte size)
        {   
            string rutafichero = null;

            // determinar ruta 
            if (!string.IsNullOrEmpty(ruta))
                rutafichero = string.Join("\\", _carpeta, ruta, nombre);
            else
                rutafichero = string.Join("\\", _carpeta, nombre);

            // determinar clave
            string clave =   $"{rutafichero}\\{size}";

            // determinar ruta de fichero
            if (!string.IsNullOrEmpty(Extension))
                rutafichero += $"\\{size}.{Extension}";
            else if (Directory.Exists(rutafichero))
                rutafichero = Directory.GetFiles(rutafichero, $"{size}*").FirstOrDefault();

            // determinar fichero imagen
            if (_items.ContainsKey(clave))
                return _items[clave].Image;
            else
                return Agregar(clave, Crear(nombre, size, rutafichero)).Image;            
        }

        private FicheroImagen Crear(string nombre, sbyte size, string fichero)
        {
            return new FicheroImagen
            {
                Nombre = nombre,
                Carpeta = fichero.Substring(0, fichero.IndexOf("\\")),
                Fichero = fichero,
                Size = size,
                Image = File.Exists(fichero) ? Image.FromFile(fichero) : null
            };
        }

        private FicheroImagen Agregar(string clave, FicheroImagen ficheroImagen)
        {
            _items.Add(clave, ficheroImagen);
            return ficheroImagen;
        }

        public string Extension
        {
            get;
            set;
        }
    }
}
