using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Test.Modelo
{
    class ItemPedido : ObjetoId
    {
        protected internal ItemPedido(IImplementacion impl) 
            : base(impl)
        {
        }

        public int Cantidad
        {
            get => ObtenerInteger("Cantidad");
            set
            {
                EstablecerInteger("Cantidad", value);
                CalcularTotal();
            }
        }

        public string Descripcion
        {
            get => ObtenerString("Descripcion");
            set => EstablecerString("Descripcion", value);
        }

        public double Precio
        {
            get => ObtenerDouble("Precio");
            set
            {
                EstablecerDouble("Precio", value);
                CalcularTotal();
            }
        }

        public double Total
        {
            get => ObtenerDouble("Total");
            private set => EstablecerDouble("Total", value);
        }

        private void CalcularTotal()
        {
            double totalItem = Total;

            Total = Cantidad * Precio;

            Pedido pedido = Propietario as Pedido;
            if (pedido == null) return;

            pedido.Total += Total - totalItem;
        }                
    }
}
