using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Serializacion.Interno;
using System.Linq;

namespace Binapsis.Plataforma.Serializacion.Estrategia
{
    class SerializarObjetoDatos : Serializar
    {
        public SerializarObjetoDatos(IObjetoDatos od, IEscritor escritor)
            : base(escritor)
        {
            ObjetoDatos = od;
        }
        
        public IObjetoDatos ObjetoDatos
        {
            get;
        }

        public override void Escribir()
        {
            //Diagrama diagrama = new Diagrama();
            NodoObjetoDatos nod = new NodoObjetoDatos();
            BuilderNodoObjetoDatos builder = new BuilderNodoObjetoDatos(nod);
            builder.Construir(ObjetoDatos);

            Escribir(nod);
        }

        public virtual void Escribir(NodoObjetoDatos nod)
        {
            if (nod == null) return;

            EscribirObjetoDatos(nod.Tipo, nod.Id);
            EscribirObjetoDatos(nod);
            EscribirObjetoDatosCierre();
        }

        protected virtual void EscribirObjetoDatos(ITipo tipo, int id)
        {
            Escritor.EscribirObjetoDatos(tipo, id);
        }

        protected virtual void EscribirObjetoDatos(IPropiedad propiedad, int id)
        {
            Escritor.EscribirObjetoDatos(propiedad, id);
        }

        protected virtual void EscribirObjetoDatos(IPropiedad propiedad, NodoObjetoDatos valor)
        {
            EscribirObjetoDatos(propiedad, valor.Id);
            EscribirObjetoDatos(valor);
            EscribirObjetoDatosCierre();
        }

        public virtual void EscribirObjetoDatos(NodoObjetoDatos nod)
        {
            if (nod.EsProxy) return;

            IObjetoDatos od = nod.ObjetoDatos;

            var atributos = from IPropiedad item in od.Tipo.Propiedades
                            where item.Tipo.EsTipoDeDato && od.Establecido(item)
                            select item;


            var referencias = nod.Nodos.OfType<NodoReferencia>();

            // escribir atributos
            foreach (IPropiedad atrib in atributos)
                EscribirPropiedad(nod.ObjetoDatos, atrib);

            // escribir referencias
            foreach (NodoReferencia refer in referencias)
                EscribirPropiedad(refer);
        }

        protected void EscribirObjetoDatosCierre()
        {
            Escritor.EscribirObjetoDatosCierre();
        }

        protected virtual void EscribirPropiedad(NodoReferencia refer)
        {
            var objetos = refer.Nodos.OfType<NodoObjetoDatos>();

            foreach (NodoObjetoDatos obj in objetos)            
                EscribirObjetoDatos(refer.Propiedad, obj);                
        }
        

        protected virtual void EscribirPropiedad(IObjetoDatos od, IPropiedad propiedad)
        {
            switch (propiedad.Tipo.Nombre)
            {
                case "Boolean":
                    EscribirBoolean(propiedad, od.ObtenerBoolean(propiedad));
                    break;
                case "Byte":
                    EscribirByte(propiedad, od.ObtenerByte(propiedad));
                    break;
                case "Char":
                    EscribirChar(propiedad, od.ObtenerChar(propiedad));
                    break;
                case "DateTime":
                    EscribirDateTime(propiedad, od.ObtenerDateTime(propiedad));
                    break;
                case "Decimal":
                    EscribirDecimal(propiedad, od.ObtenerDecimal(propiedad));
                    break;
                case "Double":
                    EscribirDouble(propiedad, od.ObtenerDouble(propiedad));
                    break;
                case "Single":
                    EscribirFloat(propiedad, od.ObtenerFloat(propiedad));
                    break;
                case "Int32":
                    EscribirInteger(propiedad, od.ObtenerInteger(propiedad));
                    break;
                case "Int64":
                    EscribirLong(propiedad, od.ObtenerLong(propiedad));
                    break;
                case "SByte":
                    EscribirSByte(propiedad, od.ObtenerSByte(propiedad));
                    break;
                case "Int16":
                    EscribirShort(propiedad, od.ObtenerShort(propiedad));
                    break;
                case "String":
                    EscribirString(propiedad, od.ObtenerString(propiedad));
                    break;
                case "UInt32":
                    EscribirUInteger(propiedad, od.ObtenerUInteger(propiedad));
                    break;
                case "UInt64":
                    EscribirULong(propiedad, od.ObtenerULong(propiedad));
                    break;
                case "UInt16":
                    EscribirUShort(propiedad, od.ObtenerUShort(propiedad));
                    break;
            }
        }

    }
}
