using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.Historial.Impl;

namespace Binapsis.Plataforma.Historial
{
    public class FabricaHistorial : FabricaImplBase
    {
        Log _log;

        public FabricaHistorial()
            : base()
        {
            _log = new Log();
        }

        //public FabricaHistorial(IFabrica fabrica) 
        //    : base(fabrica)
        //{
        //    _log = new Log();
        //}

        public FabricaHistorial(IFabricaImpl fabrica) 
            : base(fabrica)
        {
            _log = new Log();
        }

        public FabricaHistorial(Log log)
            :base()
        {
            _log = log;
        }

        public FabricaHistorial(Log log, IFabricaImpl fabrica)
            : base(fabrica)
        {
            _log = log;
        }
                
        public static FabricaHistorial Instancia { get; } = new FabricaHistorial();

        protected override IImplementacion Crear(IImplementacion impl)
        {
            return new HistorialImpl(impl, _log.Historial);
        }

        //protected override IImplementacion CrearImplementacion(IImplementacion impl)
        //{
        //    return new HistorialImpl(impl, _log.Historial);
        //}

        //public override IImplementacion Crear(ITipo tipo) =>  Crear(base.Crear(tipo));

        //public override IImplementacion Crear(IImplementacion impl) =>  new HistorialImpl(impl);

        //public override IImplementacion Crear(ITipo tipo, params object[] arg)
        //{
        //    if (arg.Length == 1 && (arg[0] is Log))
        //        return Crear(tipo, (Log)arg[0]);
        //    else
        //        return null;            
        //}

        //public override IImplementacion Crear(IImplementacion impl, params object[] arg)
        //{
        //    if (arg.Length == 1 && (arg[0] is Log))
        //        return Crear(impl, (Log)arg[0]);
        //    else
        //        return null;
        //}

        //public IImplementacion Crear(ITipo tipo, Log controlador) => Crear(base.Crear(tipo), controlador);

        //public IImplementacion Crear(IImplementacion impl, Log controlador) => new HistorialImpl(impl, controlador);

    }
}
