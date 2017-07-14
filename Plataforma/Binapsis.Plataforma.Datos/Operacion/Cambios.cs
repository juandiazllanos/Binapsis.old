using System.Collections.Generic;

namespace Binapsis.Plataforma.Datos.Operacion
{
    class Cambios
    {
        List<OperacionBase> _operaciones;
        List<OperacionCrear> _insert;
        List<OperacionEliminar> _delete;
        List<OperacionEditar> _update;

        public Cambios()
        {
            _operaciones = new List<OperacionBase>();
            _insert = new List<OperacionCrear>();
            _delete = new List<OperacionEliminar>();
            _update = new List<OperacionEditar>();
        }

        public void Agregar(OperacionBase operacion)
        {
            // agregar si el comando ha sido 
            //if (operacion is OperacionEscritura operacionEscritura && 
            //    operacionEscritura.Comando.Parametros.Contar() > 0)
                _operaciones.Add(operacion);

            if (operacion is OperacionCrear crear)
                _insert.Add(crear);
            else if (operacion is OperacionEliminar eliminar)
                _delete.Add(eliminar);
            else if (operacion is OperacionEditar editar)
                _update.Add(editar);
        }

        public IList<OperacionBase> Operaciones
        {
            get => _operaciones;
        }

        public IList<OperacionCrear> Insert
        {
            get => _insert;
        }

        public IList<OperacionEliminar> Delete
        {
            get => _delete;
        }

        public IList<OperacionEditar> Update
        {
            get => _update;
        }
    }
}
