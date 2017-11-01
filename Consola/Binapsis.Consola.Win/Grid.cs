using Binapsis.Consola.Definicion;
using Binapsis.Plataforma.Estructura;
using System.Collections;

namespace Binapsis.Consola.Win
{
    public class Grid : Contenido
    {
        public Grid(ContenidoInfo contenidoInfo) 
            : base(contenidoInfo)
        {
        }

        public override IEnumerable Consultar()
        {
            var resultado = base.Consultar();
                        
            IEnumerator enumerator = resultado?.GetEnumerator();
            ITipo tipo = null;

            if (enumerator != null && enumerator.MoveNext()) 
                tipo = (enumerator.Current as IObjetoDatos)?.Tipo;
            
            Items = new GridTypedList(ContenidoInfo, tipo, resultado);

            return Items;
        }


        
        public GridTypedList Items
        {
            get;
            private set;
        }
    }
}
