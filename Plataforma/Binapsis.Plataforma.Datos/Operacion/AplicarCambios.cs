using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Datos.Operacion
{
    class AplicarCambios : OperacionBase
    {
        public override void Ejecutar()
        {
            // delete
            foreach (OperacionEscritura delete in Cambios.Delete)
                delete.Ejecutar();

            // insert
            foreach (OperacionEscritura insert in Cambios.Insert)
                insert.Ejecutar();

            // update
            foreach (OperacionEscritura update in Cambios.Update)
                update.Ejecutar();                        
        }

        public Cambios Cambios
        {
            get;
            set;
        }        

        //public IObjetoDatos ObjetoDatos
        //{
        //    get;
        //    set;
        //}
    }
}
