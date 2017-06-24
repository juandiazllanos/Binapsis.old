using System;
using Binapsis.Plataforma.Cambios;
using Binapsis.Plataforma.Serializacion.Interno;
using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Serializacion.Estrategia
{
    class SerializarObjetoCambios : SerializarObjetoDatos
    {
        public SerializarObjetoCambios(IObjetoCambios cambios, IEscritor escritor) 
            : base(cambios, escritor)
        {
        }

        public override void Escribir(NodoObjetoDatos nod)
        {
            IObjetoCambios cambios = nod.ObjetoDatos as IObjetoCambios;
            if (cambios == null) return;

            EscribirObjetoCambios(nod.Tipo, nod.Id, cambios.Referencia, cambios.Cambio);
            EscribirObjetoDatos(nod);
            EscribirObjetoDatosCierre();
        }

        private void EscribirObjetoCambios(ITipo tipo, int id, string referencia, Cambio cambio)
        {
            Escritor.EscribirObjetoDatos(tipo, id, referencia, cambio);
        }

        //protected override void EscribirObjetoDatos(ITipo tipo, int id)
        //{
        //    if (ObjetoDatos is IObjetoCambios cambios)
        //        Escritor.EscribirObjetoDatos(tipo, id, cambios.Referencia, cambios.Cambio);
        //    else
        //        base.EscribirObjetoDatos(tipo, id);
        //}

        protected override void EscribirObjetoDatos(IPropiedad propiedad, NodoObjetoDatos valor)
        {
            EscribirObjetoDatos(propiedad, valor.Id, valor.ObjetoDatos as IObjetoCambios);
            EscribirObjetoDatos(valor);
            EscribirObjetoDatosCierre();
        }

        private void EscribirObjetoDatos(IPropiedad propiedad, int id, IObjetoCambios cambios)
        {
            if (cambios != null)
                Escritor.EscribirObjetoDatos(propiedad, id, cambios.Referencia, cambios.Cambio);
            else
                EscribirObjetoDatos(propiedad, id);
        }
        
    }
}
