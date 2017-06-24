using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Serializacion.Interno;

namespace Binapsis.Plataforma.Serializacion.Estrategia
{
    class DeserializarObjetoDatos : Deserializar
    {                
        public DeserializarObjetoDatos(IObjetoDatos od, ILector lector) 
            : this(od?.Tipo, lector)
        {
            ObjetoDatos = od;
        }

        public DeserializarObjetoDatos(ITipo tipo, ILector lector) 
            : base(lector)
        {
            Tipo = tipo;
        }
        
        public IObjetoDatos ObjetoDatos
        {
            get;
            private set;
        }

        public ITipo Tipo
        {
            get;
        }


        public override void Leer()
        {
            LeerObjetoDatos();

            if (ObjetoDatos == null) return;
                        
            IPropiedad propiedad = Lector.Leer(Tipo);

            while (propiedad != null)
            {
                Leer(ObjetoDatos, propiedad);
                propiedad = Lector.Leer(Tipo);
            }

        }

        protected virtual void LeerObjetoDatos()
        {
            if (Tipo == null || HeapId == null || Fabrica == null) return;

            int id = LeerId();

            if (ObjetoDatos != null)
                HeapId.Agregar(ObjetoDatos, id);
            else if (HeapId.Existe(id))
                ObjetoDatos = HeapId.Obtener(id);
            else
                HeapId.Agregar(ObjetoDatos = CrearObjetoDatos(Tipo), id);
        }

        protected virtual IObjetoDatos CrearObjetoDatos(ITipo tipo)
        {
            return Fabrica.Crear(tipo);
        }

        void Leer(IObjetoDatos od, IPropiedad propiedad)
        {
            if (propiedad.Tipo.EsTipoDeDato)
                LeerAtributo(od, propiedad);
            else
                LeerReferencia(od, propiedad);
        }

        void LeerReferencia(IObjetoDatos od, IPropiedad propiedad)
        {            
            DeserializarObjetoDatos deserializar = null;
            IObjetoDatos valor = null;

            // instancia objetoDatos componente
            if (propiedad.Asociacion == Asociacion.Composicion)            
                valor = od.CrearObjetoDatos(propiedad);

            // crear estrategia
            if (valor != null)
                deserializar = CrearEstrategia(valor);
            else
                deserializar = CrearEstrategia(propiedad.Tipo);
            
            // leer referencia
            deserializar.Leer();

            // obtener referencia
            if (valor == null)
                valor = deserializar.ObjetoDatos;

            // establecer referencia agregada
            if (propiedad.Asociacion == Asociacion.Agregacion)
                if (!propiedad.EsColeccion)
                    od.EstablecerObjetoDatos(propiedad, valor);
                else
                    od.AgregarObjetoDatos(propiedad, valor);
        }
        
        protected virtual DeserializarObjetoDatos CrearEstrategia(ITipo tipo)
        {
            return new DeserializarObjetoDatos(tipo, Lector) { HeapId = HeapId, Fabrica = Fabrica };
        }

        protected virtual DeserializarObjetoDatos CrearEstrategia(IObjetoDatos od)
        {
            return new DeserializarObjetoDatos(od, Lector) { HeapId = HeapId, Fabrica = Fabrica };
        }

        void LeerAtributo(IObjetoDatos od, IPropiedad atributo)
        {
            switch (atributo.Tipo.Nombre)
            {
                case "Boolean":
                    od.EstablecerBoolean(atributo, LeerBoolean());
                    break;
                case "Byte":
                    od.EstablecerByte(atributo, LeerByte());
                    break;
                case "Char":
                    od.EstablecerChar(atributo, LeerChar());
                    break;
                case "DateTime":
                    od.EstablecerDateTime(atributo, LeerDateTime());
                    break;
                case "Decimal":
                    od.EstablecerDecimal(atributo, LeerDecimal());
                    break;
                case "Double":
                    od.EstablecerDouble(atributo, LeerDouble());
                    break;
                case "Single":
                    od.EstablecerFloat(atributo, LeerFloat());
                    break;
                case "Int32":
                    od.EstablecerInteger(atributo, LeerInteger());
                    break;
                case "Int64":
                    od.EstablecerLong(atributo, LeerLong());
                    break;
                case "SByte":
                    od.EstablecerSByte(atributo, LeerSByte());
                    break;
                case "Int16":
                    od.EstablecerShort(atributo, LeerShort());
                    break;
                case "String":
                    od.EstablecerString(atributo, LeerString());
                    break;
                case "UInt32":
                    od.EstablecerUInteger(atributo, LeerUInteger());
                    break;
                case "UInt64":
                    od.EstablecerULong(atributo, LeerULong());
                    break;
                case "UInt16":
                    od.EstablecerUShort(atributo, LeerUShort());
                    break;
            }
        }
    }
}
