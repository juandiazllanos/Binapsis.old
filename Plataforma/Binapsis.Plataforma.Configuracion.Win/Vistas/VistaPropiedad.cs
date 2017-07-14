﻿using Binapsis.Plataforma.Configuracion.Win.Comandos;

namespace Binapsis.Plataforma.Configuracion.Win.Vistas
{
    public partial class VistaPropiedad : VistaBase
    {
        public VistaPropiedad()
        {
            InitializeComponent();
        }

        protected override void InicializarVista()
        {
            Establecer("Tipo.Nombre", Tipo);
            Establecer("Alias", Alias);
            Establecer("Asociacion", Asociacion);
            Establecer("Cardinalidad", Cardinalidad);
            Establecer("Indice", Indice);
            Establecer("Nombre", Nombre);
            Establecer("ValorInicial", ValorInicial);
        }

        protected override void InicializarComando()
        {
            EstablecerComando(Tipo.Botones[0], new ComandoEstablecerElemento("TipoAsociado", Tipo, Actividad.Controlador.Contexto));
        }
    }
}
