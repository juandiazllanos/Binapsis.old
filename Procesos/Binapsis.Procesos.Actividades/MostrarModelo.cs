using Binapsis.Consola.Definicion;
using Binapsis.Consola.Helpers;
using Binapsis.Presentacion.Editores;
using Binapsis.Procesos.Trabajos;

namespace Binapsis.Procesos.Actividades
{
    public class MostrarModelo : Actividad
    {
        public MostrarModelo(ActividadInfo actividadInfo) 
            : base(actividadInfo)
        {
        }

        public override void EjecutarActividad()
        {
            ModeloInfo modeloInfo = Parametros["modeloInfo"] as ModeloInfo;
            object modelo = Parametros["modelo"];
            string vista = modeloInfo?.Nombre;
            VistaInfo vistaInfo = ActividadInfo.TrabajoInfo.ConsolaInfo.Vistas[vista];
            
            IDialogo dialogo = Crear<IDialogo>(ActividadInfo.DialogoInfo);
            IEditorObjeto editor = Crear<IEditorObjeto>(vistaInfo.TypeInfo);

            ResultadoDialogo resultado = ResultadoDialogo.Cancelado;
            
            if (editor != null)
                editor.Establecer(modelo);

            if (dialogo != null)
            {                
                dialogo.Establecer(editor);
                dialogo.Mostrar();
                resultado = dialogo.Resultado;
            }            

            if (resultado == ResultadoDialogo.Cancelado)
                Cancelar();
        }
        
        private T Crear<T>(TypeInfo typeInfo)
        {
            if (typeInfo != null)
                return (T)TypeInfoHelper.Crear(typeInfo);
            else
                return default(T);
        }
        
    }
}
