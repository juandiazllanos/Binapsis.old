using Binapsis.Plataforma.Estructura.Impl;
using System;
using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Test.Modelo
{
    class Fabrica : FabricaBase<ObjetoId>
    {
        public Fabrica()
            : base()
        {
        }

        public Fabrica(IFabricaImpl fabrica) 
            : base(fabrica)
        {
        }

        public override ObjetoId Crear(IImplementacion impl)
        {
            Type type = Type.GetType($"{impl.Tipo.Uri}.{impl.Tipo.Nombre}");
            ObjetoId obj = Activator.CreateInstance(type, new object[] { impl }) as ObjetoId;

            int id = Claves.CrearId(type);

            (obj as IObjetoDatos)?.EstablecerInteger("Id", id);

            return obj;
        }
        
    }
}
