using System;
using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Test.Modelo
{
    class Pedido : ObjetoId
    {
        protected internal Pedido(IImplementacion impl) 
            : base(impl)
        {
        }

        public ItemPedido CrearItem(int cantidad, string descripcion, double precio)
        {
            ItemPedido itemPedido = CrearItem();

            itemPedido.Cantidad = cantidad;
            itemPedido.Descripcion = descripcion;
            itemPedido.Precio = precio;

            return itemPedido;
        }

        public void RemoverItem(ItemPedido item)
        {
            RemoverObjetoDatos("Items", item);
        }

        public ItemPedido CrearItem()
        {
            return CrearObjetoDatos("Items") as ItemPedido;
        }

        public Cliente Cliente
        {
            get => ObtenerObjetoDatos("Cliente") as Cliente;
            set => EstablecerObjetoDatos("Cliente", value);
        }

        public DateTime Fecha
        {
            get => ObtenerDateTime("Fecha");
            set => EstablecerDateTime("Fecha", value);
        }

        public IColeccion Items
        {
            get => ObtenerColeccion("Items");
        }

        public double Total
        {
            get => ObtenerDouble("Total");
            set => EstablecerDouble("Total", value);
        }
    }
}
