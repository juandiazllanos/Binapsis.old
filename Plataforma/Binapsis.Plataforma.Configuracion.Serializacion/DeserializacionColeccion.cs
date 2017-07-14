using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Serializacion;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Binapsis.Plataforma.Configuracion.Serializacion
{
    public class DeserializacionColeccion : IDeserializador
    {
        public DeserializacionColeccion(Type type)
            : this(type, new List<IObjetoDatos>())
        {            
        }

        public DeserializacionColeccion(Type type, IList items)
        {
            Type = type;
            Items = items;
        }

        public void Deserializar(byte[] contenido)
        {
            Deserializar(new Secuencia(contenido));
        }

        public void Deserializar(string contenido)
        {
            Deserializar(new Secuencia(contenido));
        }

        public void Deserializar(Stream contenido)
        {
            Deserializar(new Secuencia(contenido));
        }

        private void Deserializar(Secuencia secuencia)
        {
            if (Lector == null) return;

            ITipo tipo = Fabrica.Instancia.Crear(Type).Tipo;

            Deserializador helper = new DeserializadorObjetoDatos(secuencia, Lector);
            helper.Fabrica = Fabrica.Instancia;
            helper.Deserializar(tipo, Items);
        }

        public IList Items
        {
            get;
        }

        public ILector Lector
        {
            get;
            set;
        }

        public Type Type
        {
            get;
        }

    }
}
