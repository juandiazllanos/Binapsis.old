using Binapsis.Presentacion.Editores;

namespace Binapsis.Presentacion.Win
{
    public class Celda : IEditorAtributo
    {
        Fila _fila;
        Columna _columna;

        public Celda(Fila fila, Columna columna)
        {
            _fila = fila;
            _columna = columna;
        }
        
        private void Establecer(object value)
        {
            _fila.DataRow[_columna.Indice] = value;
        }

        private object Obtener()
        {
            return _fila.DataRow[_columna.Indice];
        }


        internal Columna Columna
        {
            get { return _columna; }
        }

        internal Fila Fila
        {
            get { return _fila; }
        }

        public string Nombre 
        {
            get { return _columna.Nombre; }
        }

        public object Valor
        {
            get { return Obtener(); }
            set { Establecer(value); }
        }

        public event NotificarHandler Notificar;
    }
}
