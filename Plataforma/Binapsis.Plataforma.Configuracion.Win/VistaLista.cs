using Binapsis.Plataforma.Configuracion.Win.Modelo;
using System.Windows.Forms;

namespace Binapsis.Plataforma.Configuracion.Win
{
    class VistaLista : VistaElemento
    {
        ListView _lista;
        Elemento _elemento;

        public VistaLista(ListView lista, Elemento elemento)
        {
            _lista = lista;
            _elemento = elemento;
        }

        public override void Mostrar()
        {
            _lista.BeginUpdate();

            try
            {
                _lista.Items.Clear();

                if (_elemento != null) 
                    foreach (Elemento elemento in _elemento.Items)
                        Mostrar(elemento);
            }
            finally
            {
                _lista.EndUpdate();
            }
        }

        private void Mostrar(Elemento item)
        {
            ListViewItem fila = new ListViewItem();

            fila.Text = item.Nombre;
            fila.ImageKey = item.Nombre;

            fila.SubItems.Add(item.Valor);
            fila.SubItems.Add(item.Alias);

            fila.Tag = item;

            _lista.Items.Add(fila);
        }
    }
}
