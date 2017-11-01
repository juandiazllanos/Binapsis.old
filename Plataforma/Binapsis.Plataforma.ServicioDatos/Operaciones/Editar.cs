using Binapsis.Plataforma.Datos;
using Binapsis.Plataforma.Cambios;
using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.ServicioDatos.Operaciones
{
    class Editar : Operacion
    {
        public Editar(IConfiguracion configuracion, IContexto contexto)
            : base(configuracion, contexto)
        {
        }
        
        public void Ejecutar(IObjetoDatos od)
        {
            IDiagramaDatos dd = CrearDiagramaDatos(od, RecuperarAntiguo(od));
            Ejecutar(dd);
        }

        public void Ejecutar(IColeccion col)
        {
            IDiagramaDatos[] dd = new IDiagramaDatos[col.Longitud];

            for (int i = 0; i < col.Longitud; i++)
                dd[i] = CrearDiagramaDatos(col[i], RecuperarAntiguo(col[i]));

            Ejecutar(dd);
        }

        //public void Ejecutar(IObjetoDatos obj, object id)
        //{
        //    IDiagramaDatos dd = new DiagramaDatos(obj.Tipo);
        //    BuilderDiagramaDatos builder = new BuilderDiagramaDatos(dd);            
        //    // obtener datos antiguos
        //    IObjetoDatos antiguo = RecuperarAntiguo(obj.Tipo, id);
        //    // construir cambios            
        //    builder.Construir(obj, antiguo);            
        //    // ejecutar cambios
        //    Ejecutar(dd);
        //}

        //private IObjetoDatos RecuperarAntiguo(ITipo tipo, object id)
        //{
        //    Recuperar recuperar = new Recuperar(Contexto, Configuracion, tipo);
        //    recuperar.Establecer(0, id);
        //    return recuperar.EjecutarConsultaSimple();
        //}
        
    }
}
